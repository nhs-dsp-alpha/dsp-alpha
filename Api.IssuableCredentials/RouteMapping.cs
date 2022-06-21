// <copyright file="RouteMapping.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.IssuableCredentials
{
    using Api.IssuableCredentials.Model;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc;

    public static class RouteMapping
    {
        public static WebApplication MapIssuableRoutes(this WebApplication app)
        {
            app.MapPost("/request", async (
                [FromHeader(Name = "dsp-org-code")] string organisationCode,
                [FromHeader(Name = "dsp-org-user-id")] string orgUserId,
                [FromBody] IssuableRequest request,
                IIssuableService service) =>
            {
                var response = await service.AddIssuableRequest(request, organisationCode, orgUserId);

                return Results.Ok(response);
            });

            return app;
        }
    }
}