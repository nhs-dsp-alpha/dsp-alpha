// <copyright file="IssuerService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuer.Model
{
    using System.Threading.Tasks;
    using Azure.Messaging.ServiceBus;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.Graph;

    public class IssuerService : IIssuerService
    {
        private readonly ILogger<IssuerService> logger;
        private readonly GraphServiceClient graphClient;
        private readonly ServiceBusClient serviceBusClient;
        private readonly ServiceBusSettings settings;

        public IssuerService(
            ILogger<IssuerService> logger,
            GraphServiceClient graphClient,
            ServiceBusClient serviceBusClient,
            IOptions<ServiceBusSettings> settings)
        {
            this.logger = logger;
            this.graphClient = graphClient;
            this.serviceBusClient = serviceBusClient;
            this.settings = settings.Value;
        }

        public virtual async Task ProcessRequest(string userId, ConnectionRequest request)
        {
            this.logger.LogDebug("Processing Connection request for {userId}", userId);
            this.logger.LogTrace("Processing Connection request for {userId} to {issuerId}", userId, request.OrganisationCode);

            var sender = this.serviceBusClient.CreateSender(this.settings.ConnectionTopic);

            var message = new ConnectionRequestMessage(request, userId);
            var busMessage = new ServiceBusMessage();
            busMessage.ApplicationProperties.Add("dsp:userId", userId);
            busMessage.ApplicationProperties.Add("dsp:organisationCode", request.OrganisationCode);
            var subject = System.Text.Json.JsonSerializer.Serialize(request.Subject?.ToList());
            busMessage.ApplicationProperties.Add("dsp:subject", subject);
            busMessage.Subject = "Connection Request";

            // TODO: remove
            // ********* Proposal was to store user connections using GraphApi.
            // ********* This code remains a placeholder and shojld be removed on confirmation of decision
            /* var user = await this.graphClient.Users[userId].Request().WithAppOnly().GetAsync(); */

            await sender.SendMessageAsync(busMessage);
        }
    }
}