// <copyright file="WebApplicationBuilderExtensions.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace CredentialGateway.Extensions
{
    using BFF.Extensions;
    using Microsoft.AspNetCore.Builder;

    public static class WebApplicationBuilderExtensions
    {
        public static WebApplication BuildDSP<T>(this WebApplicationBuilder builder)
        {
            builder.Services.AddCredentialGateway(builder.Configuration);

            var app = builder.BuildB2CBFF()
                .MapCredentialGatewayRoutes()
                .MapRoutes<T>(useMicrosoftIdentity: true);

            app.UseEndpoints(e =>
            {
                e.MapControllers();
                e.MapRazorPages();
            });

            return app;
        }

        public static WebApplication BuildOidcDSP<T>(this WebApplicationBuilder builder)
        {
            builder.Services.AddCredentialGateway(builder.Configuration);
            return builder.BuildB2CBFF()
                .MapRoutes<T>()
                .MapCredentialGatewayRoutes();
        }

        public static WebApplication BuildOauthDSP<T>(this WebApplicationBuilder builder)
        {
            builder.Services.AddCredentialGateway(builder.Configuration);
            return builder.BuildB2CBFF()
                .MapRoutes<T>()
                .MapCredentialGatewayRoutes();
        }
    }
}