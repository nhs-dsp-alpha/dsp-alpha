// <copyright file="Program.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

#pragma warning disable SA1200 // Using directives should be placed correctly
using Api.MsGraph.Services;
using Api.MsGraph.Services.ClientSettings;
using Api.MsGraph.Services.Interfaces;
using Api.Services;
using Api.Services.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Graph;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;
#pragma warning restore SA1200 // Using directives should be placed correctly

var builder = WebApplication.CreateBuilder(args);

builder
    .AddApiCommonServices(new List<string> { "MsGraph", "WebApi" });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"))
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddMicrosoftGraphAppOnly(provider => new Microsoft.Graph.GraphServiceClient(GraphClientFactory.Create(provider)))
    .AddInMemoryTokenCaches();

builder.Services
    .AddAuthorization()
    .AddTransient<IUserManagerService, UserManagerService>()
    .Configure<B2CUserSettings>(builder.Configuration.GetSection("AzureAdB2C"));

var app = builder.AddApiCore()
    .MapMsGraphRoutes();

app.Run();