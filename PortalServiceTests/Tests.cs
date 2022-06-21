// <copyright file="Tests.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace PortalServiceTests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Api.Services;
    using Api.Services.Model;
    using Microsoft.Extensions.Options;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public async Task TestClientRequest()
        {
            // Arrange
            var factory = new Mock<IHttpClientFactory>();

            var testResponse = default(ClientResponse);
            var portalSettings = default(PortalSettings);
            var responseMessage = default(HttpResponseMessage);

            var mmessageHandler = new Mock<HttpMessageHandler>();
            mmessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(() => responseMessage!);

            factory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(() =>
            {
                var client = new HttpClient(mmessageHandler.Object);
                client.BaseAddress = new Uri(portalSettings!.UseGateway.GetValueOrDefault(false) ? portalSettings.GatewayUri! : portalSettings.ServiceUri!);
                return client;
            });

            var mockedOptions = new Mock<IOptionsMonitor<PortalSettings>>();
            mockedOptions.SetupGet(m => m.CurrentValue).Returns(() => portalSettings!);

            // Act
            portalSettings = new PortalSettings() { GatewayUri = "http://gateway.uri", ServiceUri = "http://service.uri", UseGateway = false };
            testResponse = new ClientResponse() { ClientAssertionToken = "ClientAssertionToken", ClientId = "ClientId", ClientSecret = "ClientSecret" };
            responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(testResponse),
            };

            var subject = new PortalService(factory.Object, mockedOptions.Object);
            var request = new ClientRequest() { CredentialType = "TestType", Issuer = "TestIssuer" };

            var result = await subject.ProcessRequest(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ClientId, testResponse.ClientId);
            Assert.AreEqual(result.ClientSecret, testResponse.ClientSecret);
            Assert.AreEqual(result.ClientAssertionToken, testResponse.ClientAssertionToken);
        }

        [TestMethod]
        public async Task TestCredentialRequest()
        {
            // Arrange
            var factory = new Mock<IHttpClientFactory>();

            var testResponse = default(IssuableCredential);
            var portalSettings = default(PortalSettings);
            var responseMessage = default(HttpResponseMessage);

            var mmessageHandler = new Mock<HttpMessageHandler>();
            mmessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(() => responseMessage!);

            factory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(() =>
            {
                var client = new HttpClient(mmessageHandler.Object);
                client.BaseAddress = new Uri(portalSettings!.UseGateway.GetValueOrDefault(false) ? portalSettings.GatewayUri! : portalSettings.ServiceUri!);
                return client;
            });

            var mockedOptions = new Mock<IOptionsMonitor<PortalSettings>>();
            mockedOptions.SetupGet(m => m.CurrentValue).Returns(() => portalSettings!);

            // Act
            portalSettings = new PortalSettings() { GatewayUri = "http://gateway.uri", ServiceUri = "http://service.uri", UseGateway = false };
            testResponse = new IssuableCredential() { ClientAssertionToken = "ClientAssertionToken", ClientId = "ClientId", ClientSecret = "ClientSecret" };
            responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(testResponse),
            };

            var subject = new PortalService(factory.Object, mockedOptions.Object);
            var request = new CredentialRequest() { CredentialType = "TestType", Issuer = "TestIssuer" };

            var result = await subject.ProcessRequest(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ClientId, testResponse.ClientId);
            Assert.AreEqual(result.ClientSecret, testResponse.ClientSecret);
            Assert.AreEqual(result.ClientAssertionToken, testResponse.ClientAssertionToken);
        }
    }
}