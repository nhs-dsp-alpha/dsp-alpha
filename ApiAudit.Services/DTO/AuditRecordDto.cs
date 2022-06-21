// <copyright file="AuditRecordDto.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace ApiAudit.Services.DTO
{
    using ApiAudit.Services.Constants;
    using ApiAudit.Services.Models;

    public class AuditRecordDto
    {
        // Action Type
        public ActionEnum Action { get; set; }

        // Credential Type
        public string Type { get; set; } = string.Empty;

        // Issued to ID
        public string RequestId { get; set; } = string.Empty;

        // Issued By ID
        public string IssuedBy { get; set; } = string.Empty;

        // Date of issue
        public DateTime IssuedAt { get; set; }

        public AuditRecord DtoToModel()
        {
            return new AuditRecord
            {
                Action = this.Action,
                Type = this.Type,
                RequestId = this.RequestId,
                IssuedBy = this.IssuedBy,
                IssuedAt = this.IssuedAt,
            };
        }
    }
}