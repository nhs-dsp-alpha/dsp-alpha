// <copyright file="IssuingService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuing.Model
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Azure.Messaging.ServiceBus;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class IssuingService : IIssuingService
    {
        private readonly ILogger<IssuingService> logger;
        private readonly IssuingDbContext db;
        private readonly ServiceBusClient serviceBusClient;
        private readonly ServiceBusSettings settings;

        public IssuingService(
            ILogger<IssuingService> logger,
            IssuingDbContext db,
            ServiceBusClient serviceBusClient,
            IOptions<ServiceBusSettings> settings)
        {
            this.logger = logger;
            this.db = db;
            this.serviceBusClient = serviceBusClient;
            this.settings = settings.Value;
        }

        public virtual async Task<IEnumerable<ConnectionRequest>> ProcessRequests(string organisationCode, string orgUserId, ConnectionRequestStatus? status = default, int pageNum = 0, int pageSize = 30, bool enablePaging = false)
        {
            if (organisationCode != this.settings.OrganisationCode)
            {
                var msg = $"{nameof(IssuingService)} was requested to {nameof(this.ProcessRequests)} where the request was not intended for {this.settings.OrganisationCode}.";
                this.logger.LogError(msg);
                throw new ApplicationException(msg);
            }

            var messages = await this.PreprocessMessages(organisationCode);

            this.logger.LogDebug("Reading shared Connection requests for {organisationId}", organisationCode);
            this.logger.LogTrace("\tuser {userId}", orgUserId);

            var request = this.db.ConnectionRequests.AsNoTracking();
            if (status != default)
            {
                request = request.Where(c => c.Status == status);
            }

            if (enablePaging)
            {
                request = request.Skip(pageNum * pageSize);
                request = request.Take(pageSize);
            }

            return await request.ToListAsync();
        }

        public async Task<ConnectionRequest?> ChangeStatus(int id, ConnectionRequestStatus status, string organisationCode, string orgUserId)
        {
            if (organisationCode != this.settings.OrganisationCode)
            {
                var msg = $"{nameof(IssuingService)} was requested to {nameof(this.ChangeStatus)} where the request was not intended for {this.settings.OrganisationCode}.";
                this.logger.LogError(msg);
                throw new ApplicationException(msg);
            }

            this.logger.LogDebug("Updating status for connection request {id}", id);
            this.logger.LogTrace("\tuser {userId}", orgUserId);

            var request = await this.db.ConnectionRequests.FindAsync(id);

            if (request is not null)
            {

                request.Status = status;

                await this.db.SaveChangesAsync();
            }

            return request;
        }

        private async Task<IEnumerable<ServiceBusReceivedMessage>> PreprocessMessages(string organisationCode)
        {
            this.logger.LogDebug("Processing incoming Connection requests for {organisationId}", organisationCode);

            var receiver = this.serviceBusClient.CreateReceiver(
                this.settings.ConnectionTopic,
                this.settings.Subscription,
                new ServiceBusReceiverOptions { ReceiveMode = ServiceBusReceiveMode.PeekLock });

            var messageCount = 0;
            var processedMessages = new List<ServiceBusReceivedMessage>();
            var unprocessedMessages = new List<ServiceBusReceivedMessage>();

            do
            {
                var messages = await receiver.ReceiveMessagesAsync(100, TimeSpan.FromSeconds(1));
                messageCount = messages.Count;

                foreach (var message in messages)
                {

                    if (await this.PreprocessMessage(message))
                    {
                        processedMessages.Add(message);
                    }
                    else
                    {
                        unprocessedMessages.Add(message);
                    }
                }
            }
            while (messageCount > 0);

            foreach (var message in processedMessages)
            {
                if (this.settings.PeekOnly.GetValueOrDefault(false))
                {
                    await receiver.AbandonMessageAsync(message);
                }
                else
                {
                    await receiver.CompleteMessageAsync(message);
                }
            }

            foreach (var message in unprocessedMessages)
            {
                await receiver.AbandonMessageAsync(message);
            }

            return processedMessages;
        }

        private async Task<bool> PreprocessMessage(ServiceBusReceivedMessage message)
        {
            this.logger.LogTrace("Processing incoming message {messageId}", message.MessageId);

            var orgCode = default(string);

            if (message.ApplicationProperties.TryGetValue("dsp:organisationCode", out var val))
            {
                orgCode = val as string;
            }

            if (orgCode != this.settings.OrganisationCode)
            {
                var msg = $"{nameof(IssuingService)} was requested to process a message that was not intended for {this.settings.OrganisationCode}.";
                this.logger.LogError(msg);
                throw new ApplicationException(msg);
            }

            var request = new ConnectionRequest(message);

            this.db.ConnectionRequests.Add(request);
            await this.db.SaveChangesAsync();

            return true;
        }
    }
}