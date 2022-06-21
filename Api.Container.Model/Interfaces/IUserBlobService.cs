// <copyright file="IUserBlobService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Container.Model.Interfaces
{
    public interface IUserBlobService
    {
        Task<string> putProfilePicture(string userId, string base64ImageString);
    }
}