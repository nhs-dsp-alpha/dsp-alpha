// <copyright file="ExternalAuditServiceTests.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Audit.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using ApiAudit.Services;
    using ApiAudit.Services.HttpClientSettings;
    using ApiAudit.Services.Models;
    using Microsoft.Extensions.Options;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;

    [TestClass]
    public class ExternalAuditServiceTests
    {
        [TestMethod]
        public async Task TestClientRequest()
        {
            // Arrange
            var factory = new Mock<IHttpClientFactory>();

            var testResponse = default(AuditRecord);
            var auditApiSettings = default(AuditApiSettings);
            var responseMessage = default(HttpResponseMessage);

            var mmessageHandler = new Mock<HttpMessageHandler>();
            mmessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(() => responseMessage!);

            factory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(() =>
            {
                var client = new HttpClient(mmessageHandler.Object);
                client.BaseAddress = new Uri(auditApiSettings!.ServiceUri!);
                return client;
            });

            var mockedOptions = new Mock<IOptionsMonitor<AuditApiSettings>>();
            mockedOptions.SetupGet(m => m.CurrentValue).Returns(() => auditApiSettings!);

            // Act
            auditApiSettings = new AuditApiSettings() { ServiceUri = "http://service.uri" };
            testResponse = new AuditRecord() { Action = 0, Id = "ffb9930b-69e7-4d09-b396-163c2c011b56", IssuedAt = DateTime.Now, IssuedBy = "324d598f-983a-4ee9-8bf9-fd8f2417c301", RequestId = "6764f825-498a-4d2a-b5de-42263537f640", Type = "PrimaryIssuedCredentials" };
            responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(testResponse),
            };

            var externalAuditService = new ExternalAuditService(factory.Object, mockedOptions.Object);

            var result = await externalAuditService.AddAuditRecord(0, "Ryan", "Jeff", "PrimaryIdentityCredentials");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Action, testResponse.Action);
            Assert.AreEqual(result.Id, testResponse.Id);
            Assert.AreEqual(result.IssuedAt, testResponse.IssuedAt);
            Assert.AreEqual(result.IssuedBy, testResponse.IssuedBy);
            Assert.AreEqual(result.RequestId, testResponse.RequestId);
            Assert.AreEqual(result.Type, testResponse.Type);
        }
    }
}