// <copyright file="ApiApplication.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuing.Tests
{
    using Api.Issuing;
    using Api.Issuing.Model;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using System.Collections.Generic;

    internal class ApiApplication : WebApplicationFactory<Program>
    {
        private readonly IIssuingService service;
        private readonly List<ConnectionRequest>? requests;

        public ApiApplication(IIssuingService service, List<ConnectionRequest>? requests = default)
        {
            this.service = service;
            this.requests = requests;
        }

        public static void ConfigureDbOptions(DbContextOptionsBuilder builder)
        {
            builder
             .UseInMemoryDatabase("Testing");
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(async services =>
            {
                services.RemoveAll<IIssuingService>();
                services.TryAddTransient<IIssuingService>((s) => this.service);

                services.RemoveAll(typeof(DbContextOptions<IssuingDbContext>));
                services.RemoveAll(typeof(IssuingDbContext));
                services.AddDbContext<IssuingDbContext>(options => ConfigureDbOptions(options));

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                using var context = scope.ServiceProvider.GetRequiredService<IssuingDbContext>();
                context?.Database.EnsureCreated();

                if (this.requests != null)
                {
                    context!.ConnectionRequests.AddRange(this.requests);
                    context.SaveChanges();
                }
            });
        }
    }
}