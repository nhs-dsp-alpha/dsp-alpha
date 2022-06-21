// <copyright file="StaffMember.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuing.Model
{
    using System.ComponentModel.DataAnnotations;

    public class StaffMember
    {
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTimeOffset DateOfBirth { get; set; }

        public ICollection<ConnectionRequest>? ConnectionRequests { get; set; }

        public ICollection<Credential>? Credentials { get; set; }

        public ICollection<Presentation>? Presentations { get; set; }
    }
}