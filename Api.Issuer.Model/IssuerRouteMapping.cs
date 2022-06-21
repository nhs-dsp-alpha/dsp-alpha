// <copyright file="IssuerRouteMapping.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuer.Model
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc;

    public static class IssuerRouteMapping
    {
        public static WebApplication MapIssuerRoutes(this WebApplication app)
        {
            app.MapPost("/Connect", ([FromBody] ConnectionRequest request, [FromHeader(Name = "dsp-user-id")] string userId, IIssuerService service) =>
            {
                return service.ProcessRequest(userId, request);
            }).WithName("Connect");

            return app;
        }
    }
}