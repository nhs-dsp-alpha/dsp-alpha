// <copyright file="ApiAuditApplication.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Audit.Tests
{
    using ApiAudit.Services.Context;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.Hosting;

    // This class allows you to mock services with the application that you are testing
    internal class ApiAuditApplication : WebApplicationFactory<Program>
    {
        public ApiAuditApplication()
        {
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<AuditDbContext>));
                services.AddDbContext<AuditDbContext>(options =>
                    options.UseInMemoryDatabase("test", root));
            });

            return base.CreateHost(builder);
        }
    }
}