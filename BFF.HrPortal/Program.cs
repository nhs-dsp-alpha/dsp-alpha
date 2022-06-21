// <copyright file="Program.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

#pragma warning disable SA1200 // Using directives should be placed correctly
using BFF.Extensions;
using BFF.HrPortal;
using System.IdentityModel.Tokens.Jwt;
using NHSCIS2;
#pragma warning restore SA1200 // Using directives should be placed correctly

var builder = WebApplication.CreateBuilder(args);

var IssuerConfigurationLabel = builder.Configuration["IssuerConfigurationLabel"];

builder.Services.Configure<ClientConfig>(builder.Configuration.GetSection("ClientConfig"));

Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

var app = builder.BuildB2CBFF(new List<string> { "HRPortal", IssuerConfigurationLabel })
    .MapRoutes<B2CUser, ClientConfig>(true);

app.UseEndpoints(e =>
{
    e.MapControllers();
    e.MapRazorPages();
});

app.Run();