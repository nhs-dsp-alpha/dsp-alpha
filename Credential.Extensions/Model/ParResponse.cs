// <copyright file="ParResponse.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Credential.Extensions.Model
{
    using System.Text.Json.Serialization;

    public class ParResponse
    {
        [JsonPropertyName("request_uri")]
        public string? RequestUri { get; set; }

        [JsonPropertyName("expires_in")]
        public int? ExpiresIn { get; set; }
    }
}