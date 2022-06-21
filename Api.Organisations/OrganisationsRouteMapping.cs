// <copyright file="OrganisationsRouteMapping.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Organisations
{
    using Microsoft.AspNetCore.Builder;

    public static class OrganisationsRouteMapping
    {
        public static WebApplication MapOrganisationRoutes(this WebApplication app)
        {
            app.MapGet("/", async (IOrganisationsService service) =>
            {
                return await service.GetList();
            }).WithName("List");

            app.MapGet("/{id}", (IOrganisationsService service, int id) =>
            {
                return service.GetList();
            }).WithName("Single");

            return app;
        }
    }
}