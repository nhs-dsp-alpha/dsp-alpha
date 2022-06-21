// <copyright file="AuditRecord.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace ApiAudit.Services.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ApiAudit.Services.Constants;

    public class AuditRecord
    {
        // Action Type
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }

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
    }
}