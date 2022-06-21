// <copyright file="Services.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace BFF.Extensions
{
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using IdentityModel.AspNetCore.AccessTokenManagement;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication.OAuth;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Graph;
    using Microsoft.Identity.Web;
    using Yarp.ReverseProxy.Transforms;

    public static class Services
    {
        public static IServiceCollection AddOauthBFF(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.TryAddTransient<ITokenClientConfigurationService, TokenClientConfigurationService>();

            // Add authentication configuration
            return services.AddOauthAuthentication(configuration)
                .AddBFF(configuration);
        }

        public static IServiceCollection AddOidcBFF(this IServiceCollection services, ConfigurationManager configuration)
        {
            // Add authentication configuration
            return services.AddOidcAuthentication(configuration)
                .AddBFF(configuration);
        }

        public static IServiceCollection AddB2CBFF(this IServiceCollection services, ConfigurationManager configuration)
        {
            // Add authentication configuration
            return services.AddB2CAuthentication(configuration)
                .AddBFF(configuration);
        }

        internal static IServiceCollection AddBFF(this IServiceCollection services, ConfigurationManager configuration)
        {
            // Add services to the container.
            // Add reverse proxy configuration (YARP)
            return services.AddProxy(configuration)

            // Add authorization configuration
            .AddAuthorizationPolicies();
        }

        internal static IServiceCollection AddProxy(this IServiceCollection services, ConfigurationManager configuration)
        {
            var reverseProxyConfig = configuration.GetSection("ReverseProxy") ?? throw new ArgumentException("ReverseProxy section is missing!");

            services.AddUserAccessTokenManagement();

            var ocpApimSubscriptionKey = configuration["OcpApimSubscriptionKey"];
            var organisationCode = configuration["ClientConfig:OrganisationCode"];
            var rolesClaimName = configuration["RolesClaimName"];
            var scopesToAccessDownstreamApi = configuration["ApiScopes"].Split(",");

            services.AddReverseProxy()
                .LoadFromConfig(reverseProxyConfig)
                .AddTransforms(builderContext =>
                {
                    var auth = builderContext.Route.AuthorizationPolicy;
                    if (!string.IsNullOrEmpty(auth) && auth != "Anonymous")
                    {
                        _ = builderContext.AddRequestTransform(async transformContext =>
                          {
                              var tokenAcquisition = transformContext.HttpContext.RequestServices.GetService<ITokenAcquisition>();

                              var accessToken = default(string);

                              try
                              {
                                  accessToken = (tokenAcquisition != null) ?
                                  await tokenAcquisition.GetAccessTokenForUserAsync(scopesToAccessDownstreamApi)
                                  : await transformContext.HttpContext.GetUserAccessTokenAsync();
                              }
                              catch (Exception)
                              {
                              }

                              if (!string.IsNullOrEmpty(accessToken))
                              {
                                  transformContext.ProxyRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                              }

                              var headerName = "Ocp-Apim-Subscription-Key";
                              AddRequestHeader(transformContext.ProxyRequest, headerName, ocpApimSubscriptionKey);

                              headerName = "dsp-org-code";
                              AddRequestHeader(transformContext.ProxyRequest, headerName, organisationCode);

                              var userIdClaim = transformContext.HttpContext.User.GetNameIdentifierId() ?? transformContext.HttpContext.User.FindFirstValue("sub");

                              headerName = "dsp-org-user-id";
                              AddRequestHeader(transformContext.ProxyRequest, headerName, userIdClaim);

                              var roleClaim = transformContext.HttpContext.User.FindFirstValue(rolesClaimName);

                              headerName = "dsp-org-user-role";
                              AddRequestHeader(transformContext.ProxyRequest, headerName, roleClaim);
                          });
                    }
                });

            return services;
        }

        private static void AddRequestHeader(HttpRequestMessage proxyRequest, string headerName, string headerValue)
        {
            proxyRequest.Headers.Remove(headerName);
            if (!string.IsNullOrEmpty(headerValue))
            {
                var value = headerValue.ReplaceLineEndings().Replace("\r\n", string.Empty);
                proxyRequest.Headers.Add(headerName, value);
            }
        }

        internal static AuthenticationBuilder AddCookieAuth(this IServiceCollection services, string scheme)
        {
            var builder = services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = scheme;
                options.DefaultSignOutScheme = scheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.Name = "__BFF";
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            return builder;
        }

        internal static IServiceCollection AddOauthAuthentication(this IServiceCollection services, ConfigurationManager configuration, OpenIdConnectEvents? events = default)
        {
            services.AddUserAccessTokenHttpClient("userinfo", new UserAccessTokenParameters { }, client =>
              {
                  var oAuthConfig = configuration.GetSection("OAuth") ?? throw new ArgumentException("OAuth section is missing!");

                  client.BaseAddress = new Uri(oAuthConfig.GetValue<string>("UserInformationEndpoint"));
              });

            services.AddCookieAuth(OpenIdConnectDefaults.AuthenticationScheme)
            .AddOAuth(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                var oAuthConfig = configuration.GetSection("OAuth") ?? throw new ArgumentException("OAuth section is missing!");

                oAuthConfig.Bind(options);

                // Define how to map returned user data to claims
                options.ClaimActions.MapAll();

                // Register to events
                options.Events = new OAuthEvents
                {
                    // After OAuth2 has authenticated the user
                    OnCreatingTicket = async context =>
                    {
                        // Create the request message to get user data via the backchannel
                        var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

                        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        // Query for user data via backchannel
                        var response = await context.Backchannel.SendAsync(request, context.HttpContext.RequestAborted);
                        response.EnsureSuccessStatusCode();

                        // Parse user data into an object
                        var json = await response.Content.ReadAsStringAsync();
                        var user = System.Text.Json.JsonDocument.Parse(json, new System.Text.Json.JsonDocumentOptions { MaxDepth = 4 });

                        // Execute defined mapping action to create the claims from the received user object
                        context.RunClaimActions(user.RootElement);
                    },
                    OnRemoteFailure = context =>
                    {
                        context.HandleResponse();
                        context.Response.Redirect("/Home/Error?message=" + context?.Failure?.Message);
                        return Task.FromResult(0);
                    },
                };
            });

            return services;
        }

        internal static IServiceCollection AddOidcAuthentication(this IServiceCollection services, ConfigurationManager configuration, OpenIdConnectEvents? events = default)
        {
            services.AddCookieAuth(OpenIdConnectDefaults.AuthenticationScheme)
            .AddOpenIdConnect(options =>
            {
                var authenticationConfig = configuration.GetSection("Authentication") ?? throw new ArgumentException("Authentication section is missing!");

                // Bind OIDC authentication configuration
                authenticationConfig.Bind(options);

                if (events != null)
                {
                    options.Events = events;
                }

                // Add dynamically scope values from configuration
                var scopes = authenticationConfig["Scope"].Split(" ").ToList();
                options.Scope.Clear();
                scopes.ForEach(scope => options.Scope.Add(scope));

                options.TokenValidationParameters = new ()
                {
                    NameClaimType = "name",
                    RoleClaimType = "role",
                };
            });

            return services;
        }

        internal static IServiceCollection AddB2CAuthentication(this IServiceCollection services, ConfigurationManager configuration, OpenIdConnectEvents? events = default)
        {
            const string policyName = "policy";

            Func<AuthorizationCodeReceivedContext, Task> onAuthorizationCodeReceived = async context =>
            {
                var configuration = await context.Options.ConfigurationManager!.GetConfigurationAsync(context.HttpContext.RequestAborted);
                var tokenEndpointRequest = context.TokenEndpointRequest;
                var endpoint = configuration.TokenEndpoint;

                // work around small bug in Microsoft.Identity.Web
                // see https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2/issues/399 and elsewhere
                var hasPolicy = context.Properties!.Items.TryGetValue(policyName, out var policy);
                if (hasPolicy)
                {
                    endpoint = endpoint.Replace("B2C_1_SUSI", policy, StringComparison.InvariantCultureIgnoreCase);
                }

                tokenEndpointRequest!.TokenEndpoint = endpoint;
            };

            services.Configure<MicrosoftIdentityOptions>(options =>
            {
                // BUGBUG - Microsoft.Identity.Web bug when editing profile.
                // Partial work-around already implemented, but needs more, as it fails when the new token is received.
                // nb the token is not required when editing the profile, and can be discarded
                // https://github.com/AzureAD/microsoft-identity-web/issues/729
                //var secretConfig = configuration["AzureAdB2C:B2CClientSecret"];
                //options.ClientSecret = secretConfig;

                var previousOptions = options.Events.OnRedirectToIdentityProvider;
                options.Events.OnRedirectToIdentityProvider = async context =>
                {
                    var hasPolicy = context.Properties.Items.TryGetValue(policyName, out var policy);
                    await previousOptions(context);

                    context.ProtocolMessage.Prompt = "login";

                    if (hasPolicy)
                    {
                        context.Properties.Items.TryAdd(policyName, policy);
                    }

                    if (context.ProtocolMessage.ResponseType == Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectResponseType.CodeIdToken)
                    {
                        context.ProtocolMessage.ResponseType = Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectResponseType.Code;
                    }
                };

                var previousAuthorizationCodeReceived = options.Events.OnAuthorizationCodeReceived;
                options.Events.OnAuthorizationCodeReceived = context =>
                {
                    var hasPolicy = context.Properties!.Items.TryGetValue(policyName, out var policy);
                    return hasPolicy ? onAuthorizationCodeReceived(context) : previousAuthorizationCodeReceived(context);
                };
            });

            services.AddMicrosoftIdentityWebAppAuthentication(configuration, "AzureAdB2C")
                .EnableTokenAcquisitionToCallDownstreamApi(configuration["ApiScopes"].Split(","))
                .AddDownstreamWebApi("cred", configuration.GetSection("Cred"))
                //// .AddMicrosoftGraph(configuration.GetSection("GraphBeta"))
                .AddMicrosoftGraphAppOnly(provider => new Microsoft.Graph.GraphServiceClient(GraphClientFactory.Create(provider)))
                .AddInMemoryTokenCaches();

            ////services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
            ////{
            ////    //options.MapInboundClaims = false;
            ////    //options.ClaimActions.Clear();

            ////    JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            ////    options.MapInboundClaims = false;

            ////    var previousOptions = options.Events.OnRedirectToIdentityProvider;
            ////    options.Events.OnRedirectToIdentityProvider = async context =>
            ////    {
            ////        var hasPolicy = context.Properties.Items.TryGetValue(policyName, out var policy);
            ////        await previousOptions(context);
            ////        if (hasPolicy)
            ////        {
            ////            context.Properties.Items.TryAdd(policyName, policy);
            ////        }

            ////        if (context.ProtocolMessage.ResponseType == Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectResponseType.CodeIdToken)
            ////        {
            ////            context.ProtocolMessage.ResponseType = Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectResponseType.Code;
            ////        }
            ////    };

            ////    var previousAuthorizationCodeReceived = options.Events.OnAuthorizationCodeReceived;
            ////    options.Events.OnAuthorizationCodeReceived = context =>
            ////    {
            ////        var hasPolicy = context.Properties!.Items.TryGetValue(policyName, out var policy);
            ////        return hasPolicy ? onAuthorizationCodeReceived(context) : previousAuthorizationCodeReceived(context);
            ////    };

            ////    options.Events.OnTokenResponseReceived = context =>
            ////    {
            ////        return Task.CompletedTask;
            ////    };

            ////    options.Events.OnTicketReceived = context =>
            ////    {
            ////        return Task.CompletedTask;
            ////    };
            ////});

            return services;
        }

        internal static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            return services.AddAuthorization(options =>
            {
                // This is a default authorization policy which requires authentication
                options.AddPolicy(DigitalStaffPassport.Constants.RequireAuthenticatedUserPolicy, policy =>
                {
                    policy.RequireAuthenticatedUser();
                });
            });
        }
    }
}