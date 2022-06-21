// <copyright file="Program.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

#pragma warning disable SA1200 // Using directives should be placed correctly
using Api.Issuer.Model;
using Api.Services.Extensions;
using Azure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Azure;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;
#pragma warning restore SA1200 // Using directives should be placed correctly

var builder = WebApplication.CreateBuilder(args);

builder
    .AddApiCommonServices(new List<string> { "WebApi", "IssuerApi" });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"))
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddMicrosoftGraphAppOnly(provider => new Microsoft.Graph.GraphServiceClient(GraphClientFactory.Create(provider)))
    .AddInMemoryTokenCaches();

builder.Services
    .AddAuthorization()
    .AddTransient<IIssuerService, IssuerService>()
    .Configure<ServiceBusSettings>(builder.Configuration.GetSection("ServiceBus"));

builder.Services.AddAzureClients(azureBuilder =>
    {
        azureBuilder.AddServiceBusClient(builder.Configuration.GetSection("ServiceBus"))
        .WithCredential(new DefaultAzureCredential());
    });

var app = builder.AddApiCore()
    .MapIssuerRoutes();

app.Run();