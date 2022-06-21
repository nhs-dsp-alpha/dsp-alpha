// <copyright file="AuditingCredentialGatewayLoggingService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace CredentialGateway.Logging
{
    using ApiAudit.Services.Constants;
    using ApiAudit.Services.Interfaces;
    using Microsoft.Extensions.Logging;

    public class AuditingCredentialGatewayLoggingService : CredentialGatewayLoggingService
    {
        private readonly IExternalAuditService externalAuditService;

        public AuditingCredentialGatewayLoggingService(ILogger<CredentialGatewayLoggingService> logger, IExternalAuditService auditService)
            : base(logger)
        {
            this.externalAuditService = auditService;
        }

        protected override async Task LogError(string ev, string requestId, string message, string credentialType, string issuer)
        {
            await base.LogError(ev, requestId, message, credentialType, issuer);
        }

        protected override async Task LogInformation(string ev, string requestId, string credentialType, string issuer)
        {
            await base.LogInformation(ev, requestId, credentialType, issuer);

            if (ev is nameof(this.VerifySuccess) or nameof(this.VerifyFailure) or nameof(this.IssueSuccess) or nameof(this.IssueFailure))
            {
                ActionEnum actionEnum = (ActionEnum)Enum.Parse(typeof(ActionEnum), ev);

                await this.externalAuditService.AddAuditRecord(actionEnum, issuer, requestId, credentialType);
            }
        }
    }
}