// <copyright file="ContainerRouteMapping.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Container.Model
{
    using Api.Container.Model.Interfaces;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public static class ContainerRouteMapping
    {
        public static WebApplication MapContainerRoutes(this WebApplication app)
        {
            app.MapPost("/putProfilePictureBlob", async ([FromHeader(Name = "dsp-user-id")] string userId, [FromBody] string base64ImageString, IUserBlobService userBlobService) =>
            {
                var photoUrl = await userBlobService.putProfilePicture(userId, base64ImageString);

                return Results.Created(photoUrl, null);
            });
            return app;
        }
    }
}