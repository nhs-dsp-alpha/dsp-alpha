// <copyright file="PCCred.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Credentials.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PCCred
    {
        public string? BookingId { get; set; }

        public string? VacancyId { get; set; }

        public string? WorkerReference { get; set; }

        public string? Organisation { get; set; }

        public string? Department { get; set; }

        public string? Role { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),]
        public string? DateTimeStarted { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),]
        public string? DateTimeEnded { get; set; }

        public string? PpCredentialSerialNumberReference { get; set; }

        public string? Error { get; set; }
    }
}