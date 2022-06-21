// <copyright file="Program.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

#pragma warning disable SA1200 // Using directives should be placed correctly
using Api.Common;
using Api.Issuing;
using Api.Issuing.Model;
using Api.Services.Extensions;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Azure;
#pragma warning restore SA1200 // Using directives should be placed correctly

var builder = WebApplication.CreateBuilder(args);

var issuerConfigurationLabel = builder.Configuration["IssuerConfigurationLabel"];
bool.TryParse(builder.Configuration["UseInMemory"], out var useInMemory);

builder
    .AddApiCommonServices(new List<string> { "WebApi", "IssuingApi", issuerConfigurationLabel });

SqlAuthenticationProvider.SetProvider(SqlAuthenticationMethod.ActiveDirectoryInteractive, new SqlAppAuthenticationProvider());
builder.Services
    .AddAuthorization()
    .AddTransient<IIssuingService, IssuingService>()
    .Configure<ServiceBusSettings>(builder.Configuration.GetSection("ServiceBus"))

    .AddEntityFrameworkSqlServer()
    .AddScoped<ISchemaStorage, SchemaStorage>()
    .AddScoped<IMigrationsSqlGenerator, SchemaMigrationsSqlGenerator>()
    .AddScoped<MigrationsSqlGenerator, SqlServerMigrationsSqlGenerator>()

    .AddDbContext<IssuingDbContext>((serviceProvider, options) =>
    {
        options.UseInternalServiceProvider(serviceProvider);

        if (useInMemory)
        {
            options.UseInMemoryDatabase("IssuingOrganisations");
        }
        else
        {
            options.UseSqlServer("name=ConnectionStrings:AuditDatabase", b =>
            {
                b.MigrationsAssembly("Api.Issuing");
                b.MigrationsHistoryTable("__EFMigrationsHistory", builder.Configuration["IssuingDbSchema"] ?? "DSPIssuingOrg");
            });
        }
    });
builder.Services.AddAzureClients(azureBuilder =>
{
    azureBuilder.AddServiceBusClient(builder.Configuration.GetSection("ServiceBus"))
    .WithCredential(new DefaultAzureCredential());
});

var app = builder.AddApiCore()
    .MapIssuingRoutes();

using var scope = app.Services.CreateScope();
using var context = scope.ServiceProvider.GetService<IssuingDbContext>();
var contextOptions = scope.ServiceProvider.GetService<DbContextOptions<IssuingDbContext>>();

if (contextOptions?.FindExtension<Microsoft.EntityFrameworkCore.InMemory.Infrastructure.Internal.InMemoryOptionsExtension>() != null)
{
    context?.Database.EnsureCreated();
}
else
{
    context?.Database.Migrate();
}

app.Run();