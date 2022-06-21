// <copyright file="DynamicCredentialProvider.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.PostOfficeIssuer
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Text.Json.Nodes;
    using Api.Services;

    public class DynamicCredentialProvider : CredentialProvider
    {
        public override string CredentialName => "PrimaryIdentityCredential";

        public override Task<JwtPayload> CreatePayloadAsync(string? subject)
        {
            try
            {
                var userCreds = JsonValue.Parse(subject);

                var jwt = ClientService.CreatePayload(userCreds, false);

                return Task.FromResult(ClientService.CreatePayload(userCreds, false));
            }
            catch (Exception e)
            {
                // Invalid JSON so return default
                var credential = new
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
                    Photograph = string.Empty,
                    Signature = string.Empty,
                };

                return Task.FromResult(ClientService.CreatePayload(credential, false));
            }


        }
    }
}