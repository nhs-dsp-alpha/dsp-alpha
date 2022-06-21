// <copyright file="ConnectionRequest.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuing.Model
{
    using Azure.Messaging.ServiceBus;
    using Microsoft.EntityFrameworkCore;

    [Index(nameof(Status))]
    public class ConnectionRequest
    {
        public ConnectionRequest()
        {
        }

        public ConnectionRequest(ServiceBusReceivedMessage busMessage)
            : this()
        {
            var subjectJson = busMessage.ApplicationProperties.TryGetValue("dsp:subject", out var subjectVal) ? subjectVal as string : default;
            if (string.IsNullOrEmpty(subjectJson))
            {
                throw new ArgumentException("The Service Bus Message did not contain any subject data.");
            }

            var orgCode = busMessage.ApplicationProperties.TryGetValue("dsp:organisationCode", out var orgCodeVal) ? orgCodeVal as string : default;
            if (string.IsNullOrEmpty(orgCode))
            {
                throw new ArgumentException("The Service Bus Message did not contain the organisation code.");
            }

            var portalUserId = busMessage.ApplicationProperties.TryGetValue("dsp:userId", out var portalUserIdVal) ? portalUserIdVal as string : default;
            if (string.IsNullOrEmpty(portalUserId))
            {
                throw new ArgumentException("The Service Bus Message did not contain the portal user id.");
            }

            var subject = System.Text.Json.JsonSerializer.Deserialize<List<KeyValuePair<string, string>>>(subjectJson!)!.ToDictionary(k => k.Key, v => v.Value);
            var givenName = subject["givenName"];
            var surname = subject["surname"];

            this.DisplayName = $"{givenName} {surname}";

            this.BusMessage = System.Text.Json.JsonSerializer.Serialize(busMessage);
            this.MessageId = busMessage.MessageId;
            this.ReceivedAt = busMessage.EnqueuedTime;
            this.PortalUserId = portalUserId;
        }

        public int Id { get; set; }

        public string? MessageId { get; set; }

        public DateTimeOffset? ReceivedAt { get; set; }

        public ConnectionRequestStatus Status { get; set; }

        public string PortalUserId { get; set; }

        public string? DisplayName { get; set; }

        public string? BusMessage { get; set; }

        public int? StaffMemberId { get; set; }

        public StaffMember? StaffMember { get; set; }
    }
}