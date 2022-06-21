// <copyright file="User.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace NHSCIS2
{
    using System.CodeDom.Compiler;
    using System.Text.Json.Serialization;
    using DigitalStaffPassport.Extensions;

    [GeneratedCode("Paste class from JSON", default)]
    public class User
    {
        public string? sub { get; set; }

        public string? nhsid_useruid { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<Nhsid_Org_Memberships>))]
        public List<Nhsid_Org_Memberships>? nhsid_org_memberships { get; set; }

        public string? gdc_id { get; set; }

        public string? initials { get; set; }

        public string? gmp_id { get; set; }

        public string? consultant_id { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<Nhsid_Org_Roles>))]
        public List<Nhsid_Org_Roles>? nhsid_org_roles { get; set; }

        public string? title { get; set; }

        public string? gmc_id { get; set; }

        public string? display_name { get; set; }

        public string? given_name { get; set; }

        public string? uid { get; set; }

        public string? rcn_id { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<Nhsid_Nrbac_Roles>))]
        public List<Nhsid_Nrbac_Roles>? nhsid_nrbac_roles { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<Nhsid_User_Orgs>))]
        public List<Nhsid_User_Orgs>? nhsid_user_orgs { get; set; }

        public string? nmc_id { get; set; }

        public string? middle_names { get; set; }

        public string? name { get; set; }

        public string? idassurancelevel { get; set; }

        public string? family_name { get; set; }

        public string? email { get; set; }

        public string? gphc_id { get; set; }

        public string? gdp_id { get; set; }
    }
}