// <copyright file="PortalSettings.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Services
{
    public class PortalSettings
    {
        public string? ServiceUri { get; set; }

        public bool? UseGateway { get; set; }

        public string? GatewayUri { get; set; }
    }
}