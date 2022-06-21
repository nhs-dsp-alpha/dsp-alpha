// <copyright file="Program.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

#pragma warning disable SA1200 // Using directives should be placed correctly
using Api.Common;
using Api.Services;
using Api.Services.Extensions;
using ApiAudit.Services;
using ApiAudit.Services.Context;
using ApiAudit.Services.HttpClientSettings;
using ApiAudit.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

#pragma warning restore SA1200 // Using directives should be placed correctly

var builder = WebApplication.CreateBuilder(args);

bool.TryParse(builder.Configuration["UseInMemory"], out var useInMemory);

builder
    .AddApiCommonServices(new List<string> { "AuditApiSettings" });

SqlAuthenticationProvider.SetProvider(SqlAuthenticationMethod.ActiveDirectoryInteractive, new SqlAppAuthenticationProvider());
builder.Services
    .AddAuthorization()
    .AddTransient<IAuditService, AuditService>()
    .AddDbContext<AuditDbContext>(options =>
    {
        if (useInMemory)
        {
            options.UseInMemoryDatabase("organisations");
        }
        else
        {
            options.UseSqlServer("name=ConnectionStrings:AuditDatabase", b => b.MigrationsAssembly("Api.Audit"));
        }
    })
    .Configure<AuditApiSettings>(builder.Configuration.GetSection("AuditApiSettings"));

var app = builder.AddApiCore()
    .MapAuditRoutes();

using var scope = app.Services.CreateScope();
using var context = scope.ServiceProvider.GetService<AuditDbContext>();
var contextOptions = scope.ServiceProvider.GetService<DbContextOptions<AuditDbContext>>();

if (contextOptions?.FindExtension<Microsoft.EntityFrameworkCore.InMemory.Infrastructure.Internal.InMemoryOptionsExtension>() != null)
{
    context?.Database.EnsureCreated();
}
else
{
    context?.Database.Migrate();
}

app.Run();