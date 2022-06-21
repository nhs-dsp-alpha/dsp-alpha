// <copyright file="OrganisationsService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Organisations
{
    using System.Threading.Tasks;
    using Api.Organisations.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class OrganisationsService : IOrganisationsService
    {
        private readonly OrganisationsDbContext db;
        private readonly ILogger<OrganisationsService> logger;
        private readonly OrganisationSettings settings;

        public OrganisationsService(
            OrganisationsDbContext db,
            ILogger<OrganisationsService> logger,
            IOptions<OrganisationSettings> settings)
        {
            this.db = db;
            this.logger = logger;
            this.settings = settings.Value;
        }

        public async Task<IEnumerable<Organisation>> GetList()
        {
            return await this.db.Organisations.ToListAsync();
        }

        public async Task<Organisation?> Get(int id)
        {
            return await this.db.Organisations.FindAsync(id);
        }
    }
}