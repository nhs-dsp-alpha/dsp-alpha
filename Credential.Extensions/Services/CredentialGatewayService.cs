// <copyright file="CredentialGatewayService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace CredentialGateway.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Credential.Extensions;
    using Credential.Extensions.Model;
    using Credentials;
    using IdentityModel;
    using IdentityModel.AspNetCore.AccessTokenManagement;
    using IdentityModel.Client;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Protocols.OpenIdConnect;

    public class CredentialGatewayService : ICredentialGatewayService
    {
        private readonly CredentialGatewayConfiguration options;
        private readonly ITokenClientConfigurationService configService;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IAuthenticationSchemeProvider schemeProvider;
        private readonly IOptionsMonitor<OpenIdConnectOptions> oidcOptions;
        private readonly ILogger<CredentialGatewayService> logger;

        public CredentialGatewayService(
            IOptionsMonitor<CredentialGatewayConfiguration> options,
            ITokenClientConfigurationService configService,
            IHttpClientFactory httpClientFactory,
            IAuthenticationSchemeProvider schemeProvider,
            IOptionsMonitor<OpenIdConnectOptions> oidcOptions,
            ILogger<CredentialGatewayService> logger)
        {
            this.options = options.CurrentValue;
            this.configService = configService;
            this.httpClientFactory = httpClientFactory;
            this.schemeProvider = schemeProvider;
            this.oidcOptions = oidcOptions;
            this.logger = logger;
        }

        public Task<ParResponse?> RequestPushedAuthorizationAsync<T>(
            string credentialType,
            T credential,
            IDictionary<string, string> parameters,
            string state,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ParResponse?> RequestPushedAuthorizationAsync(
            string credentialType,
            string credentialIssuer,
            string clientId,
            string? clientSecret,
            string? clientAssertion,
            string token,
            IDictionary<string, string> parameters,
            string state,
            CancellationToken cancellationToken = default)
        {
            this.logger.LogDebug("Requesting pushed authorisation for client: {client}", credentialIssuer);

            var (options, configuration) = await this.GetOpenIdConnectSettingsAsync("CredentialGateway");

            var requestDetails = new PushedAuthorizationRequest
            {
                Address = configuration.AdditionalData["pushed_authorization_request_endpoint"] as string,
                ClientCredentialStyle = ClientCredentialStyle.PostBody,
                ClientId = clientId,
                ClientSecret = clientSecret,
                Scope = $"issue.{credentialType}",
                IdTokenHint = token,
                RedirectUri = parameters[OidcConstants.AuthorizeRequest.RedirectUri],
                Nonce = parameters[OidcConstants.AuthorizeRequest.Nonce],
                State = state,
            };

            var httpClient = this.httpClientFactory.CreateClient();
            return await httpClient.RequestPushedAuthorizationAsync(requestDetails);
        }

        internal virtual async Task<(OpenIdConnectOptions options, OpenIdConnectConfiguration configuration)> GetOpenIdConnectSettingsAsync(string? schemeName)
        {
            OpenIdConnectOptions options;

            if (string.IsNullOrWhiteSpace(schemeName))
            {
                var scheme = await this.schemeProvider.GetDefaultChallengeSchemeAsync();

                if (scheme is null)
                {
                    throw new InvalidOperationException("No OpenID Connect authentication scheme configured for getting client configuration. Either set the scheme name explicitly or set the default challenge scheme");
                }

                options = this.oidcOptions.Get(scheme.Name);
            }
            else
            {
                options = this.oidcOptions.Get(schemeName);
            }

            OpenIdConnectConfiguration configuration;
            try
            {
                configuration = await options.ConfigurationManager!.GetConfigurationAsync(default);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Unable to load OpenID configuration for configured scheme: {e.Message}");
            }

            return (options, configuration);
        }
    }
}