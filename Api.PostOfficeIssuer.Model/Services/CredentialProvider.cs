// <copyright file="CredentialProvider.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Services
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text.Json;
    using System.Threading.Tasks;

    public abstract class CredentialProvider : ICredentialProvider
    {
        protected CredentialProvider()
        {
        }

        public abstract string CredentialName { get; }

        public abstract Task<JwtPayload> CreatePayloadAsync(string? subject);

        protected ClaimsIdentity CreateIdentity(string json)
        {
            var payload = JwtPayload.Deserialize(json);

            return new ClaimsIdentity(payload.Claims);
        }

        protected JwtSecurityToken CreateJWT(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            return handler.ReadJwtToken(token);
        }

        protected TE DeserialiseEntity<TE>(string json)
        {
            return JsonSerializer.Deserialize<TE>(json) !;
        }
    }
}