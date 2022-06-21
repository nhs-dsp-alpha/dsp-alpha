// <copyright file="MsGraphRouteMapping.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Services
{
    using Api.MsGraph.Services.Interfaces;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc;

    public static class MsGraphRouteMapping
    {
        public static WebApplication MapMsGraphRoutes(this WebApplication app)
        {
            app.MapGet("/getProfilePicture", async ([FromHeader(Name = "dsp-user-id")] string userId, IUserManagerService userManagerService) =>
            {
                var photo = await userManagerService.GetUserPhoto(userId);

                return photo;
            });

            app.MapPost("/putProfilePicture", async ([FromHeader(Name = "dsp-user-id")] string userId, [FromBody] string base64ImageString, IUserManagerService userManagerService) =>
            {
                var photo = await userManagerService.PutUserPhoto(userId, base64ImageString);

                return photo;
            });

            return app;
        }
    }
}