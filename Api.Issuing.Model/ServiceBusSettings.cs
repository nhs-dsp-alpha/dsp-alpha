// <copyright file="ServiceBusSettings.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuing.Model
{
    public class ServiceBusSettings
    {
        public string? ConnectionTopic { get; set; }

        public string? Subscription { get; set; }

        public string? OrganisationCode { get; set; }

        public bool? PeekOnly { get; set; }
    }
}