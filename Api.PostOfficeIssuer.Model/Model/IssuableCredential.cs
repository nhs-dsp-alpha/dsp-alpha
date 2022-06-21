// <copyright file="IssuableCredential.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Services.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    [JsonSourceGenerationOptions(
                    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
                    IgnoreReadOnlyFields = true,
                    IgnoreReadOnlyProperties = true,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]
    public class IssuableCredential : ClientResponse
    {
        [Required(ErrorMessage = "Credential is required")]
        public string? Credential { get; set; }

        [Required(ErrorMessage = "Scope is required")]
        public string? Scope { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        [JsonPropertyName("sub")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "Date of Expiry is required")]
        public DateTimeOffset? ExpiresAt { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ClientAssertionAuthorise { get; set; }
    }
}