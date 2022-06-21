// <copyright file="IssuingDbContextDbContext.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuing
{
    using Api.Issuing.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class IssuingDbContext : DbContext
    {
        private string schemaName;

        public IssuingDbContext(DbContextOptions options, IConfiguration? config = null)
            : base(options)
        {
            this.schemaName = config?["IssuingDbSchema"] ?? "DSPIssuingOrg";
        }

        public DbSet<ConnectionRequest> ConnectionRequests => this.Set<ConnectionRequest>();

        public DbSet<Credential> Credentials => this.Set<Credential>();

        public DbSet<StaffMember> StaffMembers => this.Set<StaffMember>();

        public DbSet<Presentation> Presentations => this.Set<Presentation>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(this.schemaName);
        }
    }
}