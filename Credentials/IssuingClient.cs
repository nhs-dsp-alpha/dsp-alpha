// <copyright file="IssuingClient.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Credentials
{
    public class IssuingClient : Client
    {
        public IssuingClient()
            : base()
        {
        }

        public string ClientId { get; set; } = string.Empty;

        public string ClientSecret { get; set; } = string.Empty;

        public string ClientSigningKey { get; set; } = string.Empty;

        public int CredentialExpiryMinutes { get; set; } = 60 * 24 * 365;
    }
}