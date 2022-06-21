// <copyright file="ConnectionRequestMessage.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuer.Model
{
    using System.ComponentModel.DataAnnotations;

    internal class ConnectionRequestMessage : ConnectionRequest
    {
        private ConnectionRequest request;

        public ConnectionRequestMessage(ConnectionRequest request, string userId)
        {
            this.request = request;
            this.UserId = userId;
        }

        [Required]
        public string? UserId { get; set; }
    }
}