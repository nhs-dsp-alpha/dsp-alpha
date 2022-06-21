// <copyright file="TokenClientConfigurationService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace BFF.Extensions
{
    using System;
    using System.Threading.Tasks;
    using IdentityModel.AspNetCore.AccessTokenManagement;
    using IdentityModel.Client;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.OAuth;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    internal class TokenClientConfigurationService : DefaultTokenClientConfigurationService
    {
        private readonly UserAccessTokenManagementOptions userAccessTokenManagementOptions;
        private readonly ClientAccessTokenManagementOptions clientAccessTokenManagementOptions;
        private readonly IOptionsMonitor<OpenIdConnectOptions> oidcOptions;
        private readonly IOptionsMonitor<OAuthOptions> oauthOptions;
        private readonly IAuthenticationSchemeProvider schemeProvider;

        public TokenClientConfigurationService(
            UserAccessTokenManagementOptions userAccessTokenManagementOptions,
            ClientAccessTokenManagementOptions clientAccessTokenManagementOptions,
            IOptionsMonitor<OpenIdConnectOptions> oidcOptions,
            IOptionsMonitor<OAuthOptions> oauthOptions,
            IAuthenticationSchemeProvider schemeProvider,
            ILogger<DefaultTokenClientConfigurationService> logger)
            : base(userAccessTokenManagementOptions, clientAccessTokenManagementOptions, oidcOptions, schemeProvider, logger)
        {
            this.userAccessTokenManagementOptions = userAccessTokenManagementOptions;
            this.clientAccessTokenManagementOptions = clientAccessTokenManagementOptions;
            this.oidcOptions = oidcOptions;
            this.oauthOptions = oauthOptions;
            this.schemeProvider = schemeProvider;
        }

        public override Task<ClientCredentialsTokenRequest> GetClientCredentialsRequestAsync(string clientName, ClientAccessTokenParameters parameters)
        {
            return base.GetClientCredentialsRequestAsync(clientName, parameters);
        }

        public async Task<OAuthOptions> GetOAuthOptionsAsync(string schemeName)
        {
            OAuthOptions options;

            if (string.IsNullOrWhiteSpace(schemeName))
            {
                var scheme = await this.schemeProvider.GetDefaultChallengeSchemeAsync();

                if (scheme is null)
                {
                    throw new InvalidOperationException("No OAuth authentication scheme configured for getting client configuration. Either set the scheme name explicitly or set the default challenge scheme");
                }

                options = this.oauthOptions.Get(scheme.Name);
            }
            else
            {
                options = this.oauthOptions.Get(schemeName);
            }

            return options;
        }

        public override async Task<RefreshTokenRequest> GetRefreshTokenRequestAsync(UserAccessTokenParameters? parameters = null)
        {
            var options = await this.GetOAuthOptionsAsync(parameters?.ChallengeScheme ?? this.userAccessTokenManagementOptions.SchemeName);

            if (!string.IsNullOrEmpty(options.TokenEndpoint))
            {
                var requestDetails = new RefreshTokenRequest
                {
                    Address = options.TokenEndpoint,
                    ClientCredentialStyle = ClientCredentialStyle.PostBody,

                    ClientId = options.ClientId,
                    ClientSecret = options.ClientSecret,
                };

                var assertion = await this.CreateAssertionAsync();
                if (assertion != null)
                {
                    requestDetails.ClientCredentialStyle = ClientCredentialStyle.PostBody;
                    requestDetails.ClientAssertion = assertion;
                }

                return requestDetails;
            }
            else
            {
                return await base.GetRefreshTokenRequestAsync(parameters);
            }
        }

        public override Task<TokenRevocationRequest> GetTokenRevocationRequestAsync(UserAccessTokenParameters? parameters = null)
        {
            return base.GetTokenRevocationRequestAsync(parameters);
        }

        protected override Task<ClientAssertion> CreateAssertionAsync(string? clientName = null)
        {
            return base.CreateAssertionAsync(clientName);
        }
    }
}