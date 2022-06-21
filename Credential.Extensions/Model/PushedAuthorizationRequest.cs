// <copyright file="PushedAuthorizationRequest.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Credential.Extensions.Model
{
    using IdentityModel.Client;

    public class PushedAuthorizationRequest : ProtocolRequest
    {
        public PushedAuthorizationRequest()
        {
        }

        public string? Scope { get; set; }

        public string? IdTokenHint { get; set; }

        public string? RedirectUri { get; set; }

        public string? Nonce { get; set; }

        public string? State { get; set; }
    }
}