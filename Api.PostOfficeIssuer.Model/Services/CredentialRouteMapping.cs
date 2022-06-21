// <copyright file="CredentialRouteMapping.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Services.Extensions
{
    using Api.Services.Model;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc;

    public static class CredentialRouteMapping
    {
        public static WebApplication MapCredentialRoutes(this WebApplication app)
        {
            app.MapPost("/GetClientResponse", ([FromBody] ClientRequest request, IClientService service) =>
            {
                return service.ProcessRequest(request);
            }).WithName("GetClientResponse");

            app.MapPost("/GetCredentialResponse", async ([FromBody] CredentialRequest request, IClientService service) =>
             {
                 return await service.ProcessRequest(request);
             }).WithName("GetCredentialResponse");

            return app;
        }
    }
}