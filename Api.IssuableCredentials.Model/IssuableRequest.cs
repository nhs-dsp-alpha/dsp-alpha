// <copyright file="IssuableRequest.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.IssuableCredentials.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class IssuableRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }

        public string? OrganisationCode { get; set; }

        public string? UserId { get; set; }

        public DateTimeOffset? SentAt { get; set; }

        public string? PortalUserId { get; set; }
        
        public MessageType MessageType { get; set; }

        public string? Message { get; set; }

        public string? EmailAddress { get; set; }

        public bool? UseEmailAddress { get; set; }

        public string? PhoneNumber { get; set; }
        public bool? UsePhoneNumber { get; set; }
    }
}