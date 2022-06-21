// <copyright file="IIssuableService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.IssuableCredentials.Model
{
    public interface IIssuableService
    {
        Task<IssuableRequest> AddIssuableRequest(IssuableRequest request, string organisationCode, string orgUserId);
    }
}
