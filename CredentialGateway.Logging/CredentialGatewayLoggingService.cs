// <copyright file="CredentialGatewayLoggingService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace CredentialGateway.Logging
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.Extensions.Logging;

    public class CredentialGatewayLoggingService : ICredentialGatewayLoggingService
    {
        private const string LogInformationMessageFormat = "{ev} - requestId: {requestId}";
        private const string LogDebugMessageFormat = "{ev} - requestId: {requestId}, credentialType: {credentialType}, issuer: {issuer}. {dateTime}";
        private const string LogErrorFormat = "{ev} - requestId: {requestId}, error: {message}, credentialType: {credentialType}, issuer: {issuer}. {dateTime}";
        private const string LogWarningFormat = "{ev} - requestId: {requestId}, error: {message}, credentialType: {credentialType}, issuer: {issuer}";
        private const string UnknownParameter = "unknown";

        private readonly ILogger<CredentialGatewayLoggingService> logger;

        public CredentialGatewayLoggingService(ILogger<CredentialGatewayLoggingService> logger)
        {
            this.logger = logger;
        }

        public Task IssueBegin(string requestId, string credentialType, string issuer)
        {
            return this.LogInformation(nameof(this.IssueBegin), requestId, credentialType, issuer);
        }

        public Task IssueBegin(PropertiesContext<OpenIdConnectOptions> context)
        {
            var parameters = this.GetParameters(context.Properties);
            return this.IssueBegin(parameters.requestId, parameters.credentialType, parameters.issuer);
        }

        public Task IssueProgress(string requestId, string credentialType, string issuer)
        {
            return this.LogInformation(nameof(this.IssueProgress), requestId, credentialType, issuer);
        }

        public Task IssueProgress(RedirectContext context)
        {
            var parameters = this.GetParameters(context.Properties);
            return this.IssueProgress(parameters.requestId, parameters.credentialType, parameters.issuer);
        }

        public Task IssueSuccess(string requestId, string credentialType, string issuer)
        {
            return this.LogInformation(nameof(this.IssueSuccess), requestId, credentialType, issuer);
        }

        public Task IssueSuccess(RemoteAuthenticationContext<RemoteAuthenticationOptions> context)
        {
            var parameters = this.GetParameters(context.Properties);
            return this.IssueSuccess(parameters.requestId, parameters.credentialType, parameters.issuer);
        }

        public Task IssueFailure(string message, string requestId, string credentialType, string issuer)
        {
            return this.LogError(nameof(this.IssueFailure), requestId, message, credentialType, issuer);
        }

        public Task IssueFailure(RemoteFailureContext context)
        {
            var parameters = this.GetParameters(context.Properties);
            var message = context?.Failure?.Message;
            if (string.IsNullOrEmpty(message))
            {
                message = UnknownParameter;
            }

            return this.IssueFailure(message, parameters.requestId, parameters.credentialType, parameters.issuer);
        }

        public Task IssueError(string message, string requestId, string credentialType, string issuer)
        {
            return this.LogError(nameof(this.IssueError), requestId, message, credentialType, issuer);
        }

        public Task IssueError(Exception e, RemoteAuthenticationContext<OpenIdConnectOptions> context)
        {
            var parameters = this.GetParameters(context.Properties);
            return this.IssueError(e.Message, parameters.requestId, parameters.credentialType, parameters.issuer);
        }

        public Task VerifyBegin(string requestId, string credentialType, string issuer)
        {
            return this.LogInformation(nameof(this.VerifyBegin), requestId, credentialType, issuer);
        }

        public Task VerifyBegin(PropertiesContext<OpenIdConnectOptions> context)
        {
            var parameters = this.GetParameters(context.Properties);
            return this.VerifyBegin(parameters.requestId, parameters.credentialType, parameters.issuer);
        }

        public Task VerifyProgress(string requestId, string credentialType, string issuer)
        {
            return this.LogInformation(nameof(this.VerifyProgress), requestId, credentialType, issuer);
        }

        public Task VerifyProgress(RedirectContext context)
        {
            var parameters = this.GetParameters(context.Properties);
            return this.VerifyProgress(parameters.requestId, parameters.credentialType, parameters.issuer);
        }

        public Task VerifySuccess(string requestId, string credentialType, string issuer)
        {
            return this.LogInformation(nameof(this.VerifySuccess), requestId, credentialType, issuer);
        }

        public Task VerifySuccess(RemoteAuthenticationContext<RemoteAuthenticationOptions> context)
        {
            var parameters = this.GetParameters(context.Properties);
            return this.VerifySuccess(parameters.requestId, parameters.credentialType, parameters.issuer);
        }

        public Task VerifyFailure(string message, string requestId, string credentialType, string issuer)
        {
            return this.LogError(nameof(this.VerifyFailure), requestId, message, credentialType, issuer);
        }

        public Task VerifyFailure(RemoteFailureContext context)
        {
            var parameters = this.GetParameters(context.Properties);
            var message = context?.Failure?.Message;
            if (string.IsNullOrEmpty(message))
            {
                message = UnknownParameter;
            }

            return this.VerifyFailure(message, parameters.requestId, parameters.credentialType, parameters.issuer);
        }

        public Task VerifyError(string message, string requestId, string credentialType, string issuer)
        {
            return this.LogError(nameof(this.VerifyError), requestId, message, credentialType, issuer);
        }

        public Task IssueError(Exception e, PropertiesContext<OpenIdConnectOptions> context)
        {
            var parameters = this.GetParameters(context.Properties);
            return this.IssueError(e.Message, parameters.requestId, parameters.credentialType, parameters.issuer);
        }

        public Task VerifyError(Exception e, PropertiesContext<OpenIdConnectOptions> context)
        {
            var parameters = this.GetParameters(context.Properties);
            return this.VerifyError(e.Message, parameters.requestId, parameters.credentialType, parameters.issuer);
        }

        public Task VerifyError(Exception e, RemoteAuthenticationContext<OpenIdConnectOptions> context)
        {
            var parameters = this.GetParameters(context.Properties);
            return this.VerifyError(e.Message, parameters.requestId, parameters.credentialType, parameters.issuer);
        }

        protected virtual Task LogError(string ev, string requestId, string message, string credentialType, string issuer)
        {
            this.logger.LogError(LogErrorFormat, ev, requestId, message, credentialType, issuer, DateTimeOffset.UtcNow.ToString("o"));
            return Task.CompletedTask;
        }

        protected virtual Task LogInformation(string ev, string requestId, string credentialType, string issuer)
        {
            this.logger.LogInformation(LogInformationMessageFormat, ev, requestId);
            this.logger.LogDebug(LogDebugMessageFormat, ev, requestId, credentialType, issuer, DateTimeOffset.UtcNow.ToString("o"));
            return Task.CompletedTask;
        }

        private static string GetItem(string key, IDictionary<string, string?>? dict)
        {
            if (dict == null)
            {
                return UnknownParameter;
            }
            else
            {
                return dict.TryGetValue(key, out var value) ? value! : UnknownParameter;
            }
        }

        private (string requestId, string credentialType, string issuer) GetParameters(AuthenticationProperties? properties)
        {
            var items = properties?.Items;
            var requestId = GetItem("requestId", items);
            var credentialType = GetItem("credentialType", items);
            var issuer = GetItem("credentialIssuer", items);

            return (requestId, credentialType, issuer);
        }
    }
}