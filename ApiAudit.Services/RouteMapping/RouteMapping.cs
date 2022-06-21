// <copyright file="RouteMapping.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace ApiAudit.Services.RouteMapping
{
    using ApiAudit.Services.DTO;
    using ApiAudit.Services.Interfaces;
    using ApiAudit.Services.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;

    internal static class RouteMapping
    {
        public static WebApplication MapAuditRoutes(this WebApplication app)
        {
            app.MapPost("/audit", async (AuditRecordDto auditRecord, IAuditService auditService) =>
            {
                var response = await auditService.AddAuditRecord(auditRecord);

                return Results.Ok(response);
            });

            app.MapGet("/audits", async (IAuditService auditService) =>
            {
                var audits = await auditService.ListAuditRecords();

                return audits;
            });

            app.MapGet("/audit/{id}", async (string id, IAuditService auditService) =>
                await auditService.GetAuditRecord(id)
                    is AuditRecord auditRecord
                    ? Results.Ok(auditRecord)
                    : Results.NotFound());
            return app;
        }
    }
}