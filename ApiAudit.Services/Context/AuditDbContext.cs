// <copyright file="AuditDbContext.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace ApiAudit.Services.Context
{
    using ApiAudit.Services.Models;
    using Microsoft.EntityFrameworkCore;

    public class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options)
            : base(options)
        {
        }

        public DbSet<AuditRecord> AuditRecords => this.Set<AuditRecord>();
    }
}