// <copyright file="ServiceTests.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuing.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Api.Issuing.Model;
    using Azure.Messaging.ServiceBus;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.Extensions.Options;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ServiceTests
    {
        private Mock<ServiceBusReceiver>? receiver;
        private IssuingService? service;
        private IssuingDbContext? db;
        private List<ServiceBusReceivedMessage>? messageList;

        [TestInitialize]
        public void Initialize()
        {
            var logger = new NullLogger<IssuingService>();
            var options = Options.Create(new ServiceBusSettings() { OrganisationCode = "Org2" });

            var receiver = new Mock<ServiceBusReceiver>();
            var properties = new Dictionary<string, object>();
            var subject = new List<KeyValuePair<string, string>>();
            subject.Add(new KeyValuePair<string, string>("givenName", "first_name"));
            subject.Add(new KeyValuePair<string, string>("surname", "last_name"));
            properties["dsp:subject"] = System.Text.Json.JsonSerializer.Serialize(subject);
            properties["dsp:organisationCode"] = "Org2";

            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(properties: properties);

            var messageList = new List<ServiceBusReceivedMessage> { message };
            this.messageList = messageList;

            var list = messageList.AsReadOnly() as IReadOnlyList<ServiceBusReceivedMessage>;

            var emptyMessageList = new List<ServiceBusReceivedMessage>();
            var emptyList = emptyMessageList.AsReadOnly() as IReadOnlyList<ServiceBusReceivedMessage>;

            receiver.SetupSequence(s => s.ReceiveMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan>(), It.IsAny<System.Threading.CancellationToken>()))
                .Returns(Task.FromResult(list))
                .Returns(Task.FromResult(emptyList));

            receiver.Setup(s  => s.CompleteMessageAsync(It.IsAny<ServiceBusReceivedMessage>(), default)).Returns(Task.CompletedTask).Verifiable();
            //receiver.Setup(s => s.AbandonMessageAsync(It.IsAny<ServiceBusReceivedMessage>(), default, default)).Returns(Task.CompletedTask);

            var dbOptions = new DbContextOptionsBuilder<IssuingDbContext>()
                .UseInMemoryDatabase(databaseName: "IssuingTest")
                .Options;
            var db = new IssuingDbContext(dbOptions);

            var client = new Mock<ServiceBusClient>();
            client.Setup(c => c.CreateReceiver(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ServiceBusReceiverOptions>())).Returns(receiver.Object);

            this.receiver = receiver;
            this.service = new IssuingService(logger, db, client.Object, options);
            this.db = db;
        }

        [TestMethod]
        public async Task ProcessRequests_Returns_List()
        {
            var orgToTest = "Org2";
            var orgUserToTest = "orgUserId";

            var requests = await this.service!.ProcessRequests(orgToTest, orgUserToTest);

            this.receiver!.Verify(s => s.CompleteMessageAsync(It.IsAny<ServiceBusReceivedMessage>(), default), Times.Once);
            this.receiver.Verify(s => s.AbandonMessageAsync(It.IsAny<ServiceBusReceivedMessage>(), default, default), Times.Never);
            this.receiver!.VerifyAll();

            Assert.IsTrue(requests.Count() == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException), "IssuingService was requested to process a message that was not intended for Org2.")]
        public async Task ProcessRequests_Throws_Exception()
        {
            var orgToTest = "Org2";
            var orgUserToTest = "orgUserId";

            var properties = new Dictionary<string, object>();
            var subject = new List<KeyValuePair<string, string>>();
            subject.Add(new KeyValuePair<string, string>("givenName", "first_name"));
            subject.Add(new KeyValuePair<string, string>("surname", "last_name"));
            properties["dsp:subject"] = System.Text.Json.JsonSerializer.Serialize(subject);
            properties["dsp:organisationCode"] = "Org1";

            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(properties: properties);

            this.messageList.Add(message);

            var requests = await this.service!.ProcessRequests(orgToTest, orgUserToTest);

            this.receiver!.Verify(s => s.CompleteMessageAsync(It.IsAny<ServiceBusReceivedMessage>(), default), Times.Once);
            this.receiver.Verify(s => s.AbandonMessageAsync(It.IsAny<ServiceBusReceivedMessage>(), default, default), Times.Never);
            this.receiver!.VerifyAll();

            Assert.IsTrue(requests.Count() == 1);
        }

        [TestMethod]
        public async Task Update_Status_returns_Request()
        {
            var orgToTest = "Org2";
            var orgUserToTest = "orgUserId";

            var request = new ConnectionRequest() { Id = 1, Status = ConnectionRequestStatus.Shared };
            var records = this.db.ConnectionRequests.ToList();
            if (records != null && records.Count > 0)
            {
                this.db.ConnectionRequests.RemoveRange(records);
            }

            this.db.ConnectionRequests.Add(request);
            await this.db.SaveChangesAsync();

            var response = await this.service!.ChangeStatus(1, ConnectionRequestStatus.Accepted, orgToTest, orgUserToTest);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Id == 1);
            Assert.IsTrue(response.Status == ConnectionRequestStatus.Accepted);
        }

        [TestMethod]
        public async Task Update_Status_returns_Null_when_Not_Found()
        {
            var orgToTest = "Org2";
            var orgUserToTest = "orgUserId";

            var request = new ConnectionRequest() { Id = 1, Status = ConnectionRequestStatus.Shared };
            var records = this.db.ConnectionRequests.ToList();
            if (records != null && records.Count > 0)
            {
                this.db.ConnectionRequests.RemoveRange(records);
            }

            this.db.ConnectionRequests.Add(request);
            await this.db.SaveChangesAsync();

            var response = await this.service!.ChangeStatus(2, ConnectionRequestStatus.Accepted, orgToTest, orgUserToTest);

            Assert.IsNull(response);
        }
    }
}