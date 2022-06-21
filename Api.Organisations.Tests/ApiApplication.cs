// <copyright file="ApiApplication.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Organisations.Tests
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    internal class ApiApplication : WebApplicationFactory<Program>
    {
        public static void ConfigureDbOptions(DbContextOptionsBuilder builder)
        {
            builder
             .UseInMemoryDatabase("Testing");
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<OrganisationsDbContext>));
                services.RemoveAll(typeof(OrganisationsDbContext));
                services.AddDbContext<OrganisationsDbContext>(options => ConfigureDbOptions(options));

                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                using var context = scope.ServiceProvider.GetRequiredService<OrganisationsDbContext>();
                context?.Database.EnsureCreated();
            });
        }
    }
}