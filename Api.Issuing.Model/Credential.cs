// <copyright file="Credential.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuing.Model
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;

    [Index(nameof(Status))]
    public class Credential
    {
        public Credential()
        {
            this.Presentations = new HashSet<Presentation>();
        }

        public int Id { get; set; }

        [Required]
        public string? Data { get; set; }

        public CredentialStatus Status { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset IssuedDate { get; set; }

        public string? SourceOrganisation { get; set; }

        public int StaffMemberId { get; set; }

        public StaffMember? StaffMember { get; set; }

        public ICollection<Presentation> Presentations { get; set; }
    }
}