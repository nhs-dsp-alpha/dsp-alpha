// <copyright file="ApiApplication.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuer.Tests
{
    using Api.Issuer.Model;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.Hosting;

    internal class ApiApplication : WebApplicationFactory<Program>
    {
        private readonly IIssuerService service;

        public ApiApplication(IIssuerService service)
        {
            this.service = service;
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll<IIssuerService>();
                services.TryAddTransient<IIssuerService>((s) => this.service);

                ////services.RemoveAll(typeof(DbContextOptions<NotesDbContext>));
                ////services.AddDbContext<NotesDbContext>(options =>
                ////    options.UseInMemoryDatabase("Testing", root));
            });

            return base.CreateHost(builder);
        }
    }
}