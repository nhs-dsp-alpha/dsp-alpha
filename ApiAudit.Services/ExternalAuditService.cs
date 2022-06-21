// <copyright file="ExternalAuditService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace ApiAudit.Services
{
    using System.Net.Http;
    using System.Text;
    using ApiAudit.Services.Constants;
    using ApiAudit.Services.DTO;
    using ApiAudit.Services.HttpClientSettings;
    using ApiAudit.Services.Interfaces;
    using ApiAudit.Services.Models;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;

    public class ExternalAuditService : IExternalAuditService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly AuditApiSettings settings;
        private readonly HttpClient client;

        public ExternalAuditService(
            IHttpClientFactory factory,
            IOptionsMonitor<AuditApiSettings> options)
        {
            this.httpClientFactory = factory;
            this.settings = options.CurrentValue;
            this.client = factory.CreateClient("AuditApi");
        }

        public async Task<AuditRecord?> AddAuditRecord(ActionEnum actionEnum, string issuedBy, string requestId, string type)
        {
            var returnValue = default(AuditRecord);

            try
            {
                // Package Data into DTO
                AuditRecordDto auditRecordData = new AuditRecordDto()
                {
                    Action = actionEnum,
                    IssuedAt = DateTime.Now,
                    IssuedBy = issuedBy,
                    RequestId = requestId,
                    Type = type,
                };

                string json = JsonConvert.SerializeObject(auditRecordData);

                // Send Api Call
                var response = await this.client.PostAsync("audit", new StringContent(json, Encoding.UTF32, "application/json"));

                // Return Audit Record
                returnValue = JsonConvert.DeserializeObject<AuditRecord>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
            }

            return returnValue;
        }
    }
}