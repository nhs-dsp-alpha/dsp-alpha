// <copyright file="Program.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

#pragma warning disable SA1200 // Using directives should be placed correctly
using BFF.Extensions;
using NHSCIS2;
#pragma warning restore SA1200 // Using directives should be placed correctly

var builder = WebApplication.CreateBuilder(args);

var app = builder.BuildOAuthBFF()
    .MapRoutes<User>();

app.Run();