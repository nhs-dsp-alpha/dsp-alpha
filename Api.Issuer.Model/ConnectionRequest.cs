// <copyright file="ConnectionRequest.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuer.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class ConnectionRequest
    {
        [Required]
        [JsonPropertyName("sub")]
        public IEnumerable<KeyValuePair<string, string>>? Subject { get; set; }

        [Required]
        public string? OrganisationCode { get; set; }
    }
}