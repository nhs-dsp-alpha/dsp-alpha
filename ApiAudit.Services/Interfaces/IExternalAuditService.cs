// <copyright file="IExternalAuditService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace ApiAudit.Services.Interfaces
{
    using ApiAudit.Services.Constants;
    using ApiAudit.Services.Models;

    public interface IExternalAuditService
    {
        Task<AuditRecord?> AddAuditRecord(ActionEnum actionEnum, string issuedBy, string requestId, string type);
    }
}