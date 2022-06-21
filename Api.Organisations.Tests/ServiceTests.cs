// <copyright file="ServiceTests.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Organisations.Tests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.Extensions.Options;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ServiceTests
    {
        private OrganisationsService? service;

        [TestInitialize]
        public void Initialize()
        {
            var dbOptions = new DbContextOptionsBuilder<OrganisationsDbContext>();
            ApiApplication.ConfigureDbOptions(dbOptions);

            var db = new OrganisationsDbContext(dbOptions.Options);
            db.Database.EnsureCreated();

            var options = Options.Create(new OrganisationSettings());
            var logger = new NullLogger<OrganisationsService>();
            this.service = new OrganisationsService(db, logger, options);
        }

        [TestMethod]
        public async Task GetList_Returns_List_of_Organisations()
        {
            var organisations = await this.service!.GetList();

            Assert.IsNotNull(organisations);
            Assert.IsTrue(organisations?.ToList().Count == 2);
        }
    }
}