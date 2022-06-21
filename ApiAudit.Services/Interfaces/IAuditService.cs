// <copyright file="IAuditService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace ApiAudit.Services.Interfaces
{
    using ApiAudit.Services.DTO;
    using ApiAudit.Services.Models;

    public interface IAuditService
    {
        Task<AuditRecord> AddAuditRecord(AuditRecordDto auditRecordData);

        Task<AuditRecord> GetAuditRecord(string id);

        Task<List<AuditRecord>> ListAuditRecords();
    }
}