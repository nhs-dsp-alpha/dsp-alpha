// <copyright file="IssuableDbContext.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.IssuableCredentials.Model
{
    using Api.IssuableCredentials.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class IssuableDbContext : DbContext
    {
        private string schemaName;

        public IssuableDbContext(DbContextOptions options, IConfiguration? config = null)
            : base(options)
        {
            this.schemaName = config?["IssuableDbSchema"] ?? "IssuableCredentials";
        }

        public DbSet<IssuableRequest> IssuableRequests => this.Set<IssuableRequest>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(this.schemaName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // You don't actually ever need to call this
        }
    }
}
