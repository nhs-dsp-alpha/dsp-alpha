// <copyright file="ICredentialGatewayService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace CredentialGateway.Services
{
    using Credential.Extensions.Model;

    public interface ICredentialGatewayService
    {
        Task<ParResponse?> RequestPushedAuthorizationAsync<T>(
            string credentialType,
            T token,
            IDictionary<string, string> parameters,
            string state,
            CancellationToken cancellationToken = default);

        Task<ParResponse?> RequestPushedAuthorizationAsync(
                    string credentialType,
                    string credentialIssuer,
                    string clientId,
                    string? clientSecret,
                    string? clientAssertion,
                    string token,
                    IDictionary<string, string> parameters,
                    string state,
                    CancellationToken cancellationToken = default);
    }
}