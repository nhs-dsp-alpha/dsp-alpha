// <copyright file="PrimaryIdentityCredentialProvider.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

using System.Text.Json.Nodes;
using Api.Services;
using Credentials.Models;
using System.Text.Json;

public class PrimaryIdentityCredentialProvider : CredentialProvider<PIDCred>
{
    public PrimaryIdentityCredentialProvider()
        : base()
    {
    }

    public override string CredentialName => "PrimaryIdentityCredential";

    protected override Task<PIDCred> CreateCredentialAsync(string? subject)
    {
        try
        {
            var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(subject);

            var credential = new PIDCred
            {
                DocumentType = string.Empty,
                DocumentNumber = string.Empty,
                Surname = dict["Surname"],
                GivenNames = dict["GivenNames"],
                Nationality = string.Empty,
                DateOfBirth = dict["DateOfBirth"],
                Sex = string.Empty,
                PlaceOfBirth = string.Empty,
                DateOfIssue = string.Empty,
                DateOfExpiry = string.Empty,
                IssuingAuthority = string.Empty,
                Photograph = dict["ProfileImageUrl"],
                Telephone = dict["Telephone"],
                Email = dict["EmailAddress"],

            };

            return Task.FromResult(credential);
        }
        catch (Exception e)
        {
            // Invalid JSON so should instead return default
            var credential = new PIDCred
            {
                DocumentType = "Passport",
                DocumentNumber = "123456789",
                Surname = "Holder",
                GivenNames = "Credential",
                Nationality = "british",
                DateOfBirth = "1980-01-01",
                Sex = "M",
                PlaceOfBirth = "UK",
                DateOfIssue = "2017-11-27",
                DateOfExpiry = "2027-11-26",
                IssuingAuthority = "HMPO",
            };

            return Task.FromResult(credential);
        }
    }
}