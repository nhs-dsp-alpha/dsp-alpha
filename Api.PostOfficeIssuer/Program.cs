// <copyright file="Program.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

#pragma warning disable SA1200 // Using directives should be placed correctly
using Api.PostOfficeIssuer;
using Api.Services.Extensions;
#pragma warning restore SA1200 // Using directives should be placed correctly

var builder = WebApplication.CreateBuilder(args);

builder
    .AddApiCommonServices(new List<string> { "PostOffice" });

builder.Services
    .AddAuthorization()
    .AddCredentialClientConfiguration(builder.Configuration)
    .AddCredentialProvider<DynamicCredentialProvider>();

var app = builder.AddApiCore()
    .MapCredentialRoutes();

app.Run();