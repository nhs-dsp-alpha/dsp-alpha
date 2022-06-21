// <copyright file="RouteMapping.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuing
{
    using Api.Issuing.Model;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc;

    public static class RouteMapping
    {
        public static WebApplication MapIssuingRoutes(this WebApplication app)
        {
            app.MapGet("/", async (
                [FromHeader(Name = "dsp-org-code")] string organisationId,
                [FromHeader(Name = "dsp-org-user-id")] string orgUserId,
                [FromServices] IIssuingService service) =>
            {
                return await service.ProcessRequests(organisationId, orgUserId);
            }).WithName("GetAll");

            app.MapGet("/pending", async (
                [FromHeader(Name = "dsp-org-code")] string organisationId,
                [FromHeader(Name = "dsp-org-user-id")] string orgUserId,
                [FromServices]IIssuingService service) =>
            {
                return await service.ProcessRequests(organisationId, orgUserId, ConnectionRequestStatus.Shared);
            }).WithName("GetPending");

            app.MapGet("/accepted", async (
                [FromHeader(Name = "dsp-org-code")] string organisationId,
                [FromHeader(Name = "dsp-org-user-id")] string orgUserId,
                [FromServices] IIssuingService service) =>
            {
                return await service.ProcessRequests(organisationId, orgUserId, ConnectionRequestStatus.Accepted);
            }).WithName("GetAccepted");

            app.MapGet("/rejected", async (
                [FromHeader(Name = "dsp-org-code")] string organisationId,
                [FromHeader(Name = "dsp-org-user-id")] string orgUserId,
                [FromServices] IIssuingService service) =>
            {
                return await service.ProcessRequests(organisationId, orgUserId, ConnectionRequestStatus.Rejected);
            }).WithName("GetRejected");

            app.MapGet("/active", async (
                [FromHeader(Name = "dsp-org-code")] string organisationId,
                [FromHeader(Name = "dsp-org-user-id")] string orgUserId,
                [FromServices] IIssuingService service) =>
            {
                return await service.ProcessRequests(organisationId, orgUserId, ConnectionRequestStatus.Active);
            }).WithName("GetActive");

            app.MapPut("/{id}", async (
                [FromRoute] int id,
                ConnectionRequest request,
                [FromHeader(Name = "dsp-org-code")] string organisationId,
                [FromHeader(Name = "dsp-org-user-id")] string orgUserId,
                [FromServices] IIssuingService service) =>
            {
                var updatedReequest = await service.ChangeStatus(id, request.Status, organisationId, orgUserId);

                if (updatedReequest is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(updatedReequest);
            }).WithName("UpdateStatus");

            return app;
        }
    }
}