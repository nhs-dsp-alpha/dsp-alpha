// <copyright file="PCred.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Credentials.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PCred
    {
        public string? BookingId { get; set; }

        public string? BookingToken { get; set; }

        public string? VacancyId { get; set; }

        public string? WorkerReference { get; set; }

        public string? Organisation { get; set; }

        public string? Department { get; set; }

        public string? Role { get; set; }

        public string? Grade { get; set; }

        public string? Speciality { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd", ApplyFormatInEditMode = true),]
        public string? StartDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),]
        public string? EndDateTime { get; set; }

        public string? PositionId { get; set; }

        public string? CbCredentialSerialNumberReference { get; set; }

        public string? Error { get; set; }
    }
}