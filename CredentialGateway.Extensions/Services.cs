// <copyright file="Services.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace CredentialGateway.Extensions
{
    using System.Net;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using Api.Services;
    using Api.Services.Model;
    using ApiAudit.Services;
    using ApiAudit.Services.HttpClientSettings;
    using ApiAudit.Services.Interfaces;
    using CredentialGateway.Logging;
    using CredentialGateway.Services;
    using Credentials;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.OAuth.Claims;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.Identity.Web;
    using Microsoft.IdentityModel.Protocols.OpenIdConnect;

    public static class Services
    {
        public static IServiceCollection AddCredentialGateway(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddTransient<ICredentialGatewayService, CredentialGatewayService>();
            services.AddTransient<ICredentialGatewayLoggingService, AuditingCredentialGatewayLoggingService>();
            services.AddTransient<IExternalAuditService, ExternalAuditService>();

            services.Configure<AuditApiSettings>(configuration.GetSection("AuditApiSettings"));

            services.AddHttpClient("AuditApi", (services, httpClient) =>
            {
                var options = services.GetRequiredService<IOptionsMonitor<AuditApiSettings>>().CurrentValue;
                var config = services.GetRequiredService<IConfiguration>();
                httpClient.BaseAddress = new Uri(options.ServiceUri);

                httpClient.DefaultRequestHeaders.Add(
                    "Ocp-Apim-Subscription-Key", options.OcpApimSubscriptionKey);
            });

            services.Configure<CredentialGatewayConfiguration>(configuration.GetSection("CredentialGatewayClients"));

            services.AddTransient<IClientService, PortalService>();
            services.Configure<PortalSettings>(configuration.GetSection("PortalSettings"));
            services.AddHttpClient("CredentialApi", async (services, httpClient) =>
            {
                var options = services.GetRequiredService<IOptionsMonitor<PortalSettings>>().CurrentValue;
                var config = services.GetRequiredService<IConfiguration>();

                var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();

                using var scope = services.CreateScope();
                var tokenAcquisition = scope.ServiceProvider.GetService<ITokenAcquisition>();

                var header = config.GetSection("OcpApimSubscriptionKey").Value;
                httpClient.BaseAddress = new Uri(options.UseGateway.GetValueOrDefault(false) ? options.GatewayUri! : options.ServiceUri!);

                var scopesToAccessDownstreamApi = new string[]
                {
                                "https://SSPDevSSB2C.onmicrosoft.com/creds/cred.issue",
                                "https://SSPDevSSB2C.onmicrosoft.com/creds/cred.verify",
                };

                var accessToken = default(string);

                try
                {
                    accessToken = (tokenAcquisition != null) ?
                    await tokenAcquisition.GetAccessTokenForUserAsync(scopesToAccessDownstreamApi)
                    : await httpContextAccessor.HttpContext!.GetUserAccessTokenAsync();
                }
                catch (Exception)
                {
                }

                if (!string.IsNullOrEmpty(accessToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }

                if (!string.IsNullOrEmpty(header))
                {
                    httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", header);
                }
            });

            // Add services to the container.
            return services.AddOidcCredentialGateway(configuration);
        }

        internal static IServiceCollection AddOidcCredentialGateway(this IServiceCollection services, ConfigurationManager configuration)
        {
            // Add authentication configuration
            return services.AddOidcAuthentication(configuration);
        }

        internal static IServiceCollection AddOidcAuthentication(this IServiceCollection services, ConfigurationManager configuration, OpenIdConnectEvents? events = default)
        {
            var credentialConfig = configuration.GetSection("CredentialGateway") ?? throw new ArgumentException("Authentication section is missing!");

            Func<AuthorizationCodeReceivedContext, Task> onAuthorizationCodeReceived = async context =>
            {
                var service = context.HttpContext.RequestServices.GetRequiredService<ICredentialGatewayService>();
                var configuration = await context.Options.ConfigurationManager!.GetConfigurationAsync(context.HttpContext.RequestAborted);

                var clientId = context.Properties!.Items[OpenIdConnectParameterNames.ClientId];
                var clientSecret = context.Properties.Items[OpenIdConnectParameterNames.ClientSecret];
                var clientAssertion = context.Properties.Items[OpenIdConnectParameterNames.ClientAssertion];

                var message = context.ProtocolMessage;
                message.ClientId = clientId;
                message.ClientSecret = clientSecret;
                message.ClientAssertion = clientAssertion;
                message.ClientAssertionType = IdentityModel.OidcConstants.ClientAssertionTypes.JwtBearer;

                var tokenEndpointRequest = context.TokenEndpointRequest;
                tokenEndpointRequest!.Code = message.Code;
                tokenEndpointRequest!.ClientId = clientId;
                tokenEndpointRequest!.ClientSecret = clientSecret;

                tokenEndpointRequest!.TokenEndpoint = configuration.TokenEndpoint;
                var tokenEndpointResponse = await RedeemAuthorizationCodeAsync(tokenEndpointRequest!, context.Backchannel, context.HttpContext.RequestAborted);

                context.HandleCodeRedemption(tokenEndpointResponse);
            };

            services.AddAuthentication()
             .AddCookie("CredentialGateway.Cookie", options =>
            {
                options.Cookie.Name = "__CG";
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            })
            .AddOpenIdConnect("CredentialGateway", options =>
            {
                // Bind OIDC authentication configuration
                credentialConfig.Bind(options);

                options.SignInScheme = "CredentialGateway.Cookie";

                options.CallbackPath = "/gateway-credentials";

                if (events != null)
                {
                    options.Events = events;
                }

                // Add dynamically scope values from configuration
                var scopes = credentialConfig["Scope"].Split(" ").ToList();
                options.Scope.Clear();
                scopes.ForEach(scope => options.Scope.Add(scope));

                options.ClaimActions.MapAllExcept(options.ClaimActions.Where(c => c is DeleteClaimAction).Select(c => c.ClaimType).ToArray());
                options.TokenValidationParameters.ValidateAudience = false;

                options.Events.OnRedirectToIdentityProviderForSignOut = context =>
                {
                    context.HandleResponse();
                    return Task.CompletedTask;
                };

                options.Events.OnRedirectToIdentityProvider = async context =>
                {
                    var audit = context.HttpContext.RequestServices.GetRequiredService<ICredentialGatewayLoggingService>();

                    try
                    {
                        var requestId = Guid.NewGuid().ToString();
                        context.Properties.Items.Add("requestId", requestId);

                        var info = await context.HttpContext.AuthenticateAsync();
                        var idToken = info?.Properties?.GetTokenValue(OpenIdConnectParameterNames.IdToken);

                        var credentialType = context.Properties.Items["credentialType"];
                        var credentialIssuer = context.Properties.Items["credentialIssuer"];

                        var api = context.HttpContext.RequestServices.GetRequiredService<IClientService>();
                        var service = context.HttpContext.RequestServices.GetRequiredService<ICredentialGatewayService>();

                        await context.HttpContext.SignOutAsync(options.SignInScheme);
                        await audit.IssueBegin(context);

                        var request = new CredentialRequest { CredentialType = credentialType, Authority = options.Authority, Subject = idToken, Issuer = credentialIssuer };
                        var response = await api.ProcessRequest(request);

                        if (string.IsNullOrEmpty(response.ClientId))
                        {
                            throw new ApplicationException("Issuer Api call did not return client details");
                        }

                        context.Properties.Items.Add(OpenIdConnectDefaults.RedirectUriForCodePropertiesKey, context.ProtocolMessage.RedirectUri);
                        context.Properties.Items.Add(OpenIdConnectParameterNames.ClientId, response.ClientId);
                        context.Properties.Items.Add(OpenIdConnectParameterNames.ClientSecret, response.ClientSecret);
                        context.Properties.Items.Add(OpenIdConnectParameterNames.ClientAssertion, response.ClientAssertionToken);

                        await audit.IssueProgress(context);

                        var state = context.Options.StateDataFormat.Protect(context.Properties);

                        var par = await service.RequestPushedAuthorizationAsync(
                            credentialType!,
                            credentialIssuer!,
                            response!.ClientId!,
                            response!.ClientSecret,
                            response!.ClientAssertionAuthorise,
                            response!.Credential!,
                            context.ProtocolMessage.Parameters,
                            state);

                        context.ProtocolMessage.Parameters[OpenIdConnectParameterNames.ClientId] = response.ClientId;
                        context.ProtocolMessage.Parameters[OpenIdConnectParameterNames.RequestUri] = par?.RequestUri;

                        context.Response.StatusCode = (int)HttpStatusCode.Found;
                        context.Response.Headers["Location"] = context.ProtocolMessage.CreateAuthenticationRequestUrl();
                        context.HandleResponse();
                    }
                    catch (Exception e)
                    {
                        await audit.IssueError(e, context);
                        throw;
                    }
                };

                options.Events.OnAuthorizationCodeReceived = async context =>
                {
                    var audit = context.HttpContext.RequestServices.GetRequiredService<ICredentialGatewayLoggingService>();

                    try
                    {
                        await onAuthorizationCodeReceived(context);
                    }
                    catch (Exception e)
                    {
                        await audit.IssueError(e, context);

                        throw;
                    }
                };

                options.Events.OnTicketReceived = async context =>
                {
                    var audit = context.HttpContext.RequestServices.GetRequiredService<ICredentialGatewayLoggingService>();
                    await audit.IssueSuccess(context);
                };

                options.Events.OnRemoteFailure = async context =>
                {
                    var audit = context.HttpContext.RequestServices.GetRequiredService<ICredentialGatewayLoggingService>();
                    await audit.IssueFailure(context);

                    var redirectUri = string.IsNullOrEmpty(context.Properties?.RedirectUri) ? "/" : context.Properties.RedirectUri;
                    context.Response.Redirect(redirectUri);
                    context.HandleResponse();
                };
            });

            services.AddAuthentication()
             .AddCookie("CredentialVerify.Cookie", options =>
             {
                 options.Cookie.Name = "__CV";
                 options.Cookie.SameSite = SameSiteMode.Strict;
                 options.Cookie.HttpOnly = true;
                 options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
             })
            .AddOpenIdConnect("CredentialVerify", options =>
            {
                // Bind OIDC authentication configuration
                credentialConfig.Bind(options);
                options.Authority = options.Authority!.Replace("/issuing", string.Empty);

                options.SignInScheme = "CredentialVerify.Cookie";

                options.CallbackPath = "/gateway-verify";
                options.AccessDeniedPath = "/gateway-verify";

                if (events != null)
                {
                    options.Events = events;
                }

                options.ClaimActions.MapAllExcept(options.ClaimActions.Where(c => c is DeleteClaimAction).Select(c => c.ClaimType).ToArray());
                options.TokenValidationParameters.ValidateAudience = false;

                options.Events.OnRedirectToIdentityProviderForSignOut = context =>
                {
                    context.HandleResponse();
                    return Task.CompletedTask;
                };

                options.Events.OnRedirectToIdentityProvider = async context =>
                {
                    var audit = context.HttpContext.RequestServices.GetRequiredService<ICredentialGatewayLoggingService>();

                    try
                    {
                        var requestId = Guid.NewGuid().ToString();
                        context.Properties.Items.Add("requestId", requestId);

                        var credentialType = context.Properties.Items["credentialType"];
                        var credentialIssuer = context.Properties.Items["credentialIssuer"];

                        var api = context.HttpContext.RequestServices.GetRequiredService<IClientService>();
                        var service = context.HttpContext.RequestServices.GetRequiredService<ICredentialGatewayService>();

                        await context.HttpContext.SignOutAsync(options.SignInScheme);
                        await audit.VerifyBegin(context);

                        var request = new ClientRequest { CredentialType = credentialType, Issuer = credentialIssuer };
                        var response = await api.ProcessRequest(request);

                        if (string.IsNullOrEmpty(response.ClientId))
                        {
                            throw new ApplicationException("Issuer Api call did not return client details");
                        }

                        context.Properties.Items.Add(OpenIdConnectParameterNames.ClientId, response.ClientId);
                        context.Properties.Items.Add(OpenIdConnectParameterNames.ClientSecret, response.ClientSecret);
                        context.Properties.Items.Add(OpenIdConnectParameterNames.ClientAssertion, response.ClientAssertionToken);

                        await audit.VerifyProgress(context);

                        context.ProtocolMessage.ClientId = response.ClientId;
                        context.ProtocolMessage.Scope = $"openid {credentialType}";
                    }
                    catch (Exception e)
                    {
                        await audit.VerifyError(e, context);
                        throw;
                    }
                };

                options.Events.OnAuthorizationCodeReceived = async context =>
                {
                    var audit = context.HttpContext.RequestServices.GetRequiredService<ICredentialGatewayLoggingService>();

                    try
                    {
                        await onAuthorizationCodeReceived(context);
                    }
                    catch (Exception e)
                    {
                        await audit.VerifyError(e, context);

                        throw;
                    }
                };

                options.Events.OnTokenValidated = async context =>
                {
                    var audit = context.HttpContext.RequestServices.GetRequiredService<ICredentialGatewayLoggingService>();

                    try
                    {
                        var credentialType = context.ProtocolMessage.Scope.Replace("openid", string.Empty, StringComparison.InvariantCultureIgnoreCase).Trim();
                        var identity = new ClaimsIdentity(
                            context.Principal?.Claims.Select(claim =>
                            {
                                var claimType = claim.Type.Replace(credentialType, string.Empty);
                                claimType = char.ToLowerInvariant(claimType[0]) + claimType[1..];
                                return new Claim(claimType, claim.Value);
                            }), context.Principal!.Identity!.AuthenticationType);

                        context.Principal = new ClaimsPrincipal(identity);
                    }
                    catch (Exception e)
                    {
                        await audit.VerifyError(e, context);

                        throw;
                    }
                };

                options.Events.OnTicketReceived = async context =>
                {
                    var audit = context.HttpContext.RequestServices.GetRequiredService<ICredentialGatewayLoggingService>();
                    await audit.VerifySuccess(context);
                };

                options.Events.OnRemoteFailure = async context =>
                {
                    var audit = context.HttpContext.RequestServices.GetRequiredService<ICredentialGatewayLoggingService>();
                    await audit.VerifyFailure(context);

                    var redirectUri = string.IsNullOrEmpty(context.Properties?.RedirectUri) ? "/" : context.Properties.RedirectUri;
                    context.Response.Redirect(redirectUri);
                    context.HandleResponse();
                };
            });

            return services;
        }

        internal static async Task<OpenIdConnectMessage> RedeemAuthorizationCodeAsync(OpenIdConnectMessage tokenEndpointRequest, HttpClient backchannel, CancellationToken requestAborted)
        {
            ////Logger.RedeemingCodeForTokens();

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, tokenEndpointRequest.TokenEndpoint);
            requestMessage.Content = new FormUrlEncodedContent(tokenEndpointRequest.Parameters);
            requestMessage.Version = backchannel.DefaultRequestVersion;
            var responseMessage = await backchannel.SendAsync(requestMessage, requestAborted);

            var contentMediaType = responseMessage.Content.Headers.ContentType?.MediaType;
            if (string.IsNullOrEmpty(contentMediaType))
            {
                ////Logger.LogDebug($"Unexpected token response format. Status Code: {(int)responseMessage.StatusCode}. Content-Type header is missing.");
            }
            else if (!string.Equals(contentMediaType, "application/json", StringComparison.OrdinalIgnoreCase))
            {
                ////Logger.LogDebug($"Unexpected token response format. Status Code: {(int)responseMessage.StatusCode}. Content-Type {responseMessage.Content.Headers.ContentType}.");
            }

            // Error handling:
            // 1. If the response body can't be parsed as json, throws.
            // 2. If the response's status code is not in 2XX range, throw OpenIdConnectProtocolException. If the body is correct parsed,
            //    pass the error information from body to the exception.
            OpenIdConnectMessage message;
            try
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync(requestAborted);
                message = new OpenIdConnectMessage(responseContent);
            }
            catch (Exception ex)
            {
                throw new OpenIdConnectProtocolException($"Failed to parse token response body as JSON. Status Code: {(int)responseMessage.StatusCode}. Content-Type: {responseMessage.Content.Headers.ContentType}", ex);
            }

            if (!responseMessage.IsSuccessStatusCode)
            {
                ////throw CreateOpenIdConnectProtocolException(message, responseMessage);
            }

            return message;
        }
    }
}