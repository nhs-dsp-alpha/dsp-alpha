// <copyright file="IIssuerService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuer.Model
{
    public interface IIssuerService
    {
        Task ProcessRequest(string userId, ConnectionRequest request);
    }
}