// <copyright file="VerifyingViewModel.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Credentials.Models
{
    using System.Collections.Generic;

    public class VerifyingViewModel
    {
        public string? AuthError { get; set; }

        public string? AuthResult { get; set; }

        public string? Credential { get; set; }

        public string? Status { get; set; }

        public string? State { get; set; }

        public Dictionary<string, string>? Claims { get; set; }

        public Dictionary<string, string>? Notes { get; set; }

        public string ClaimNote(string key) => this.Notes.ContainsKey(key) ? this.Notes[key] : string.Empty;
    }
}