// <copyright file="Program.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

#pragma warning disable SA1200 // Using directives should be placed correctly
using Api.Common;
using Api.IssuableCredentials;
using Api.IssuableCredentials.Model;
using Api.Services.Extensions;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Azure;
#pragma warning restore SA1200 // Using directives should be placed correctly

var builder = WebApplication.CreateBuilder(args);

var issuerConfigurationLabel = builder.Configuration["IssuableConfigurationLabel"];
bool.TryParse(builder.Configuration["UseInMemory"], out var useInMemory);

builder
    .AddApiCommonServices(new List<string> { "WebApi", "IssuableApi", issuerConfigurationLabel });

SqlAuthenticationProvider.SetProvider(SqlAuthenticationMethod.ActiveDirectoryInteractive, new SqlAppAuthenticationProvider());

builder.Services
    .AddAuthorization()
    .AddTransient<IIssuableService, IssuableService>()

    .AddEntityFrameworkSqlServer()
    .AddScoped<ISchemaStorage, SchemaStorage>()
    .AddScoped<IMigrationsSqlGenerator, SchemaMigrationsSqlGenerator>()
    .AddScoped<MigrationsSqlGenerator, SqlServerMigrationsSqlGenerator>()

    .AddDbContext<IssuableDbContext>((serviceProvider, options) =>
    {
        options.UseInternalServiceProvider(serviceProvider);

        if (useInMemory)
        {
            options.UseInMemoryDatabase("IssuableOrganisations");
        }
        else
        {
            options.UseSqlServer("name=ConnectionStrings:AuditDatabase", b =>
            {
                b.MigrationsAssembly("Api.IssuableCredentials");
                b.MigrationsHistoryTable("__EFMigrationsHistory", builder.Configuration?["IssuableDbSchema"] ?? "IssuableCredentials");
            });
        }
    });

var app = builder.AddApiCore()
    .MapIssuableRoutes();

using var scope = app.Services.CreateScope();
using var context = scope.ServiceProvider.GetService<IssuableDbContext>();
var contextOptions = scope.ServiceProvider.GetService<DbContextOptions<IssuableDbContext>>();

if (contextOptions?.FindExtension<Microsoft.EntityFrameworkCore.InMemory.Infrastructure.Internal.InMemoryOptionsExtension>() != null)
{
    context?.Database.EnsureCreated();
}
else
{
    context?.Database.Migrate();
}

app.Run();