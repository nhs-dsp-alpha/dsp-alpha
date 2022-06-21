// <copyright file="CredentialRequest.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Services.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class CredentialRequest : ClientRequest
    {
        [Required]
        [JsonPropertyName("sub")]
        public string? Subject { get; set; }

        [Required]
        public string? Authority { get; set; }
    }
}