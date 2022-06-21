// <copyright file="ClientRequest.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Services.Model
{
    using System.ComponentModel.DataAnnotations;

    public class ClientRequest
    {
        [Required]
        public string? CredentialType { get; set; }

        public string? Issuer { get; set; }
    }
}