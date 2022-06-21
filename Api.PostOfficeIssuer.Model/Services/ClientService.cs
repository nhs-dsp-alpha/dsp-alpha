// <copyright file="ClientService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Services
{
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text.Json;
    using Api.Services.Model;
    using Credentials;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    public class ClientService : IClientService
    {
        private readonly IssuingClient client;
        private readonly ILogger<ClientService> logger;
        private readonly Dictionary<string, ICredentialProvider> providers;

        public ClientService(
            IEnumerable<ICredentialProvider> providers,
            IOptionsMonitor<IssuingClient> client,
            ILogger<ClientService> logger)
        {
            this.client = client.CurrentValue;
            this.logger = logger;

            this.providers = providers.ToDictionary(p => p.CredentialName);
        }

        private DateTimeOffset Expiry => DateTimeOffset.UtcNow.AddMinutes(this.client.CredentialExpiryMinutes);

        public static JwtPayload CreatePayload<T>(T payload, bool ignoreReadOnly = true)
        {
            var json = JsonSerializer.Serialize(
                payload,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    IgnoreReadOnlyFields = ignoreReadOnly,
                    IgnoreReadOnlyProperties = ignoreReadOnly,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                });

            return JwtPayload.Deserialize(json);
        }

        public Task<ClientResponse> ProcessRequest(ClientRequest request)
        {
            this.logger.LogDebug("Processing Client request client: {client}", this.client.Name);

            return Task.FromResult(new ClientResponse
            {
                ClientId = this.client.ClientId,
                ClientSecret = this.client.ClientSecret,
            });
        }

        public async Task<IssuableCredential> ProcessRequest(CredentialRequest request)
        {
            this.logger.LogDebug("Requesting pushed authorisation for client: {client}", this.client.Name);

            var payload = await this.CreatePayloadAsync(request.Subject, request.CredentialType);
            var tokenAndExpires = this.TokenAndExpiry(payload, request);

            return new IssuableCredential
            {
                Credential = tokenAndExpires.token,
                Scope = request.CredentialType,
                Subject = request.Subject,
                ExpiresAt = tokenAndExpires.expiresAt,
                ClientId = this.client.ClientId,
                ClientSecret = this.client.ClientSecret,
            };
        }

        protected virtual async Task<JwtPayload> CreatePayloadAsync(string? subject, string? credentialType)
        {
            if (this.providers.TryGetValue(credentialType!, out ICredentialProvider? provider))
            {
                return await provider.CreatePayloadAsync(subject);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        private static SecurityTokenDescriptor CreateDescriptor(JwtPayload payload, string clientId, SigningCredentials signingCredentials, string authority, DateTimeOffset expiresAt)
        {
            return new SecurityTokenDescriptor()
            {
                Claims = payload,
                Issuer = clientId,
                Audience = authority,
                Expires = expiresAt.DateTime,
                SigningCredentials = signingCredentials,
            };
        }

        private static SigningCredentials CreateSigningCredentials(string clientSigningKey)
        {
            var key = new SymmetricSecurityKey(Convert.FromBase64String(clientSigningKey));

            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }

        private static string CreateToken(JwtPayload payload, string clientId, string clientSigningKey, string authority, DateTimeOffset expiresAt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var signingCredentials = CreateSigningCredentials(clientSigningKey);

            var des = CreateDescriptor(payload, clientId, signingCredentials, authority, expiresAt);

            var token = tokenHandler.CreateEncodedJwt(des);

            return token;
        }

        private static string CreateToken(JwtPayload payload, IssuingClient client, string authority, DateTimeOffset expiresAt)
        {
            return CreateToken(payload, client.ClientId, client.ClientSigningKey, authority, expiresAt);
        }

        private (string token, DateTimeOffset expiresAt) TokenAndExpiry(JwtPayload payload, CredentialRequest request)
        {
            var expiresAt = this.Expiry;
            var token = this.CreateToken(payload, request, expiresAt);

            return (token, expiresAt);
        }

        private string CreateToken(JwtPayload payload, CredentialRequest request, DateTimeOffset expiresAt)
        {
            var token = CreateToken(payload, this.client, request.Authority!, expiresAt);

            return token;
        }
    }
}