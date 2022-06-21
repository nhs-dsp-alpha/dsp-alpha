// <copyright file="ICredentialGatewayLoggingService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace CredentialGateway.Logging
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;

    public interface ICredentialGatewayLoggingService
    {
        Task IssueBegin(string requestId, string credentialType, string issuer);

        Task IssueBegin(PropertiesContext<OpenIdConnectOptions> context);

        Task IssueProgress(string requestId, string credentialType, string issuer);

        Task IssueProgress(RedirectContext context);

        Task IssueSuccess(string requestId, string credentialType, string issuer);

        Task IssueSuccess(RemoteAuthenticationContext<RemoteAuthenticationOptions> context);

        Task IssueFailure(string message, string requestId, string credentialType, string issuer);

        Task IssueFailure(RemoteFailureContext context);

        Task IssueError(string message, string requestId, string credentialType, string issuer);

        Task IssueError(Exception e, PropertiesContext<OpenIdConnectOptions> context);

        Task IssueError(Exception e, RemoteAuthenticationContext<OpenIdConnectOptions> context);

        Task VerifyBegin(string requestId, string credentialType, string issuer);

        Task VerifyBegin(PropertiesContext<OpenIdConnectOptions> context);

        Task VerifyProgress(string requestId, string credentialType, string issuer);

        Task VerifyProgress(RedirectContext context);

        Task VerifySuccess(string requestId, string credentialType, string issuer);

        Task VerifySuccess(RemoteAuthenticationContext<RemoteAuthenticationOptions> context);

        Task VerifyFailure(string message, string requestId, string credentialType, string issuer);

        Task VerifyFailure(RemoteFailureContext context);

        Task VerifyError(string message, string requestId, string credentialType, string issuer);

        Task VerifyError(Exception e, PropertiesContext<OpenIdConnectOptions> context);

        Task VerifyError(Exception e, RemoteAuthenticationContext<OpenIdConnectOptions> context);
    }
}