// <copyright file="CredentialProvider{T}.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Services
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Threading.Tasks;

    public abstract class CredentialProvider<T> : CredentialProvider
        where T : class
    {
        protected CredentialProvider()
           : base()
        {
        }

        public override string CredentialName => typeof(T).Name.Replace("Provider", string.Empty);

        public override async Task<JwtPayload> CreatePayloadAsync(string? subject)
        {
            var credential = await this.CreateCredentialAsync(subject);
            return ClientService.CreatePayload(credential);
        }

        protected abstract Task<T> CreateCredentialAsync(string? subject);
    }
}