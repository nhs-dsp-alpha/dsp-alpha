// <copyright file="ServiceTests.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuer.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Api.Issuer.Model;
    using Azure.Messaging.ServiceBus;
    using Microsoft.Extensions.Logging.Abstractions;
    using Microsoft.Extensions.Options;
    using Microsoft.Graph;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;

    [TestClass]
    public class ServiceTests
    {
        private Mock<ServiceBusSender>? sender;
        private IssuerService? service;

        [TestInitialize]
        public void Initialize()
        {
            var logger = new NullLogger<IssuerService>();
            var options = Options.Create(new ServiceBusSettings());

            var sender = new Mock<ServiceBusSender>();
            sender.Setup(s => s.SendMessageAsync(It.IsAny<ServiceBusMessage>(), default)).Returns(Task.CompletedTask).Verifiable();

            var client = new Mock<ServiceBusClient>();
            client.Setup(c => c.CreateSender(It.IsAny<string>())).Returns(sender.Object);

            var providerMock = new Mock<HttpMessageHandler>(MockBehavior.Loose);
            providerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<System.Threading.CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(new User()),
                });

            var provider = new SimpleHttpProvider(new HttpClient(providerMock.Object));

            var mockAuthProvider = new Mock<IAuthenticationProvider>(MockBehavior.Loose);
            mockAuthProvider.Setup(s => s.AuthenticateRequestAsync(It.IsAny<HttpRequestMessage>())).Returns(Task.CompletedTask).Verifiable();

            var graphClient = new GraphServiceClient(mockAuthProvider.Object, provider);

            this.sender = sender;
            this.service = new IssuerService(logger, graphClient, client.Object, options);
        }

        [TestMethod]
        public async Task ProcessRequest_Returns()
        {
            var userId = "userId";
            var request = new ConnectionRequest();
            await this.service!.ProcessRequest(userId, request);

            this.sender!.VerifyAll();
        }
    }
}