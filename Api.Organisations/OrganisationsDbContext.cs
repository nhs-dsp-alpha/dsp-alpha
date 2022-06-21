// <copyright file="OrganisationsDbContext.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Organisations
{
    using Api.Organisations.Model;
    using Microsoft.EntityFrameworkCore;

    public class OrganisationsDbContext : DbContext
    {
        public OrganisationsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Organisation> Organisations => this.Set<Organisation>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DSP");

            modelBuilder.Entity<Organisation>()
                .HasData(
                    new Organisation
                    {
                        Id = 1,
                        Name = "Organisation One",
                        Code = "OrgOne",
                    },
                    new Organisation
                    {
                        Id = 2,
                        Name = "Organisation Two",
                        Code = "OrgTwo",
                    });
        }
    }
}