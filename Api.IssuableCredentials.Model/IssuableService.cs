// <copyright file="IssuableService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.IssuableCredentials.Model
{
    using System.Runtime.InteropServices;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class IssuableService : IIssuableService
    {
        private readonly ILogger<IssuableService> logger;
        private readonly IssuableDbContext dbContext;

        public IssuableService(
            ILogger<IssuableService> logger,
            IssuableDbContext db)
        {
            this.logger = logger;
            this.dbContext = db;
        }

        public virtual async Task<IssuableRequest> AddIssuableRequest(IssuableRequest request, string organisationCode, string orgUserId)
        {
            this.logger.LogDebug("Processing Issuable request for {request.PortalUserId}", request.PortalUserId);
            try
            {
                IssuableRequest dbRequest = new IssuableRequest()
                {
                    OrganisationCode = organisationCode,
                    UserId = orgUserId,
                    SentAt = request.SentAt,
                    PortalUserId = request.PortalUserId,
                    MessageType = request.MessageType,
                    Message = request.Message,
                };

                var issuableRequest = this.dbContext.IssuableRequests.Add(dbRequest);

                await this.dbContext.SaveChangesAsync();

                return issuableRequest.Entity;
            }
            catch (Exception e)
            {
                this.logger.LogError("Error processing request {request}", request);
                throw;
            }


        }
    }
}
