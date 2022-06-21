// <copyright file="CBCred.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Credentials.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CBCred
    {
        public string? Instance { get; set; }

        public string? UserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),]
        public string? IssueDate { get; set; }

        public string? UserSurname { get; set; }

        public string? UserFirstName { get; set; }

        public string? UserEmail { get; set; }

        public string? EoCredentialSerialNumberReference { get; set; }

        public string? Error { get; set; }
    }
}