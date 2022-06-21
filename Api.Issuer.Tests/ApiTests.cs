// <copyright file="ApiTests.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuer.Tests
{
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Api.Issuer.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public async Task Connect_adds_message()
        {
            var service = new Mock<IIssuerService>();
            service.Setup(s => s.ProcessRequest(It.IsAny<string>(), It.IsAny<ConnectionRequest>())).Returns(Task.CompletedTask).Verifiable();

            await using var application = new ApiApplication(service.Object);

            var client = application.CreateClient();
            var request = new ConnectionRequest();

            client.DefaultRequestHeaders.Add("dsp-user-id", "userId");
            await client.PostAsJsonAsync("/Connect", request);

            service.VerifyAll();
        }
    }
}