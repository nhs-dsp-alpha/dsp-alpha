// <copyright file="PortalService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Services
{
    using System.Net.Http;
    using Api.Services.Model;
    using Microsoft.Extensions.Options;

    public class PortalService : IClientService
    {
        private readonly IHttpClientFactory factory;
        private readonly PortalSettings settings;
        private readonly HttpClient client;

        public PortalService(
            IHttpClientFactory factory,
            IOptionsMonitor<PortalSettings> options)
        {
            this.factory = factory;
            this.settings = options.CurrentValue;
            this.client = factory.CreateClient("CredentialApi");
        }

        public async Task<ClientResponse> ProcessRequest(ClientRequest request)
        {
            var url = this.GetUrl(request);
            var response = await this.client.PostAsJsonAsync(url, request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ClientResponse>();
        }

        public async Task<IssuableCredential> ProcessRequest(CredentialRequest request)
        {
            var url = this.GetUrl(request);
            var response = await this.client.PostAsJsonAsync(url, request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IssuableCredential>();
        }

        private string GetUrl<T>(T request)
            where T : ClientRequest
        {
            var requestUrl = request is CredentialRequest ? "GetCredentialResponse" : "GetClientResponse";
            var url = this.settings.UseGateway.GetValueOrDefault(false) ? $"{request.Issuer}/{requestUrl}" : $"/{requestUrl}";

            return url;
        }
    }
}