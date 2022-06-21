// <copyright file="B2CUserSettings.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.MsGraph.Services.ClientSettings
{
    public class B2CUserSettings
    {
        public string? TenantId { get; set; }

        public string? ClientId { get; set; }

        public string? ClientSecret { get; set; }

        public string? Tenant { get; set; }

        public string? B2cExtensionAppClientId { get; set; }
    }
}