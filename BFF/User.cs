// <copyright file="User.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace BFF
{
    public class User
    {
        [System.Text.Json.Serialization.JsonPropertyName(System.Security.Claims.ClaimTypes.Name)]
        public string? DisplayName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName(System.Security.Claims.ClaimTypes.GivenName)]
        public string? GivenName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName(System.Security.Claims.ClaimTypes.Surname)]
        public string? Surname { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName(System.Security.Claims.ClaimTypes.Email)]
        public string? Email { get; set; }

        public string[] Emails { get; set; }

        public bool? UserIsNew { get; set; }

        public string? ObjectId { get; set; }
    }
}