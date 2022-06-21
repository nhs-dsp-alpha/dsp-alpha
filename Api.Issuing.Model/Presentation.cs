// <copyright file="Presentation.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuing.Model
{
    public class Presentation
    {
        public Presentation()
        {
            this.Credentials = new HashSet<Credential>();
        }

        public int Id { get; set; }

        public int? StaffMemberId { get; set; }

        public StaffMember? StaffMember { get; set; }

        public ICollection<Credential> Credentials { get; set; }
    }
}