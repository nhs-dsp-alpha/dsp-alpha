// <copyright file="IUserManagerService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.MsGraph.Services.Interfaces
{
    public interface IUserManagerService
    {
        Task<string> GetUserPhoto(string userId);

        Task<string> PutUserPhoto(string userId, string base64ImageString);
    }
}