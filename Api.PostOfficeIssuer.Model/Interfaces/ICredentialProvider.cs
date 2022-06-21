// <copyright file="ICredentialProvider.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Services
{
    using System.IdentityModel.Tokens.Jwt;

    public interface ICredentialProvider
    {
        string CredentialName { get; }

        Task<JwtPayload> CreatePayloadAsync(string? subject);
    }
}