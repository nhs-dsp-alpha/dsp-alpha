// <copyright file="ApiApplication.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.IssuableCredentials.Tests
{
    using Api.IssuableCredentials.Model;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.Hosting;

    internal class ApiApplication : WebApplicationFactory<Program>
    {
        private readonly IIssuableService service;

        public ApiApplication(IIssuableService service)
        {
            this.service = service;
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll<IIssuableService>();
                services.TryAddTransient<IIssuableService>((s) => this.service);

                ////services.RemoveAll(typeof(DbContextOptions<NotesDbContext>));
                ////services.AddDbContext<NotesDbContext>(options =>
                ////    options.UseInMemoryDatabase("Testing", root));
            });

            return base.CreateHost(builder);
        }
    }
}