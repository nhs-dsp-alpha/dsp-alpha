// <copyright file="SACred.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Credentials.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SACred
    {
        public string? Organisation { get; set; }

        public string? Department { get; set; }

        public string? BookingId { get; set; }

        public string? ProvisionedUserId { get; set; }

        public string? Role { get; set; }

        public string? PositionId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),]
        public string? StartDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),]
        public string? EndDateTime { get; set; }

        public string? PpCredentialSerialNumberReference { get; set; }

        public string? Error { get; set; }
    }
}