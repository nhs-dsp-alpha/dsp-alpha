// <copyright file="Program.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

#pragma warning disable SA1200 // Using directives should be placed correctly
using Api.Common;
using Api.Organisations;
using Api.Services.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
#pragma warning restore SA1200 // Using directives should be placed correctly

var builder = WebApplication.CreateBuilder(args);

bool.TryParse(builder.Configuration["UseInMemory"], out var useInMemory);

builder
    .AddApiCommonServices(new List<string> { "OrganisationsApi" });

SqlAuthenticationProvider.SetProvider(SqlAuthenticationMethod.ActiveDirectoryInteractive, new SqlAppAuthenticationProvider());
builder.Services
    .AddAuthorization()
    .AddTransient<IOrganisationsService, OrganisationsService>()
    .AddDbContext<OrganisationsDbContext>(options =>
    {
        if (useInMemory)
        {
            options.UseInMemoryDatabase("organisations");
        }
        else
        {
            options.UseSqlServer("name=ConnectionStrings:AuditDatabase", b => b.MigrationsAssembly("Api.Organisations"));
        }
    });

var app = builder.AddApiCore()
    .MapOrganisationRoutes();

using var scope = app.Services.CreateScope();
using var context = scope.ServiceProvider.GetService<OrganisationsDbContext>();
var contextOptions = scope.ServiceProvider.GetService<DbContextOptions<OrganisationsDbContext>>();

if (contextOptions?.FindExtension<Microsoft.EntityFrameworkCore.InMemory.Infrastructure.Internal.InMemoryOptionsExtension>() != null)
{
    context?.Database.EnsureCreated();
}
else
{
    context?.Database.Migrate();
}

app.Run();