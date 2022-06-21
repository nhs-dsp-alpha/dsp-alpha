// <copyright file="ApiTests.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

using System.Linq;

namespace Api.IssuableCredentials.Tests
{
    using System;
    using System.Threading.Tasks;
    using Api.IssuableCredentials.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ApiTests
    {
        private IssuableDbContext issuableDbContext = default!;
        private IssuableService issuableService = default!;
        private Mock<ILogger<IssuableService>> mockLogger;

        [TestInitialize]
        public void Initialize()
        {
            var dbContext = new DbContextOptionsBuilder<IssuableDbContext>();
            dbContext.UseInMemoryDatabase(Guid.NewGuid().ToString());
            this.mockLogger = new Mock<ILogger<IssuableService>>();
            this.issuableDbContext = new IssuableDbContext(dbContext.Options);
            this.issuableService = new IssuableService(this.mockLogger.Object, this.issuableDbContext);
        }

        [TestMethod]
        public async Task AuditService_AddAuditRecord_ReturnsAuditRecord()
        {
            // Arrange
            var dateValue = DateTimeOffset.Now;


            var issuableRequest = new IssuableRequest()
            {
               EmailAddress = "User@Email.com",
               Message = "Message",
               MessageType = MessageType.Issuable,
               PhoneNumber = "1234567890",
               PortalUserId = "portalUserId1",
               SentAt = dateValue,
               UseEmailAddress = true,
               UsePhoneNumber = true,

            };

            // Act
            var result = await this.issuableService.AddIssuableRequest(issuableRequest, "OrgTwo", "userId1");

            // Assert
            Assert.AreEqual("OrgTwo", result.OrganisationCode);
            Assert.AreEqual("userId1", result.UserId);
            Assert.AreNotEqual(string.Empty, result.Id);
            Assert.AreEqual(this.issuableDbContext.IssuableRequests.Single(x => x.Id == result.Id), result);
        }
    }
}