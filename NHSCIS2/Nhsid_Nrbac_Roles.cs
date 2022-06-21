// <copyright file="Nhsid_Nrbac_Roles.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace NHSCIS2
{
    using System.CodeDom.Compiler;

    [GeneratedCode("Paste class from JSON", default)]
    public class Nhsid_Nrbac_Roles
    {
        public string? person_orgid { get; set; }

        public string? person_roleid { get; set; }

        public string? org_code { get; set; }

        public string? role_name { get; set; }

        public string? role_code { get; set; }

        public string[]? activities { get; set; }

        public string[]? activity_codes { get; set; }

        public string[]? workgroups { get; set; }

        public string[]? workgroups_codes { get; set; }

        public string[]? aow { get; set; }

        public string[]? aow_codes { get; set; }
    }
}