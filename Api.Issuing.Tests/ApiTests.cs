// <copyright file="ApiTests.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuing.Tests
{
    using Api.Issuing.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public async Task Get_processes_messages()
        {
            var orgToTest = "Org2";
            var orgUserToTest = "orgUserId";

            var service = new Mock<IIssuingService>();
            var requestsList = new List<ConnectionRequest> { new ConnectionRequest() };
            service.Setup(s => s.ProcessRequests(It.Is<string>(s => s == orgToTest), It.Is<string>(s => s == orgUserToTest), null, 0, 30, false))
                .Returns(Task.FromResult(requestsList.AsEnumerable())).Verifiable();

            await using var application = new ApiApplication(service.Object);

            var client = application.CreateClient();

            client.DefaultRequestHeaders.Add("dsp-org-code", orgToTest);
            client.DefaultRequestHeaders.Add("dsp-org-user-id", orgUserToTest);
            var result = await client.GetAsync("/");

            var list = await result.Content.ReadAsAsync<IEnumerable<ConnectionRequest>>();

            service.VerifyAll();
            Assert.IsTrue(list.Count() == 1);
        }

        [TestMethod]
        public async Task Put_updates_status()
        {
            var orgToTest = "Org2";
            var orgUserToTest = "orgUserId";

            var service = new Mock<IIssuingService>();
            var requestsList = new List<ConnectionRequest> { new ConnectionRequest() { Id = 1, Status = ConnectionRequestStatus.Accepted } };
            service.Setup(s => s.ChangeStatus(It.Is<int>(s => s == 1), It.Is<ConnectionRequestStatus>(s => s == ConnectionRequestStatus.Accepted), orgToTest, orgUserToTest))
                .Returns(Task.FromResult(requestsList.FirstOrDefault())).Verifiable();

            await using var application = new ApiApplication(service.Object, requestsList);

            var client = application.CreateClient();

            client.DefaultRequestHeaders.Add("dsp-org-code", orgToTest);
            client.DefaultRequestHeaders.Add("dsp-org-user-id", orgUserToTest);
            var result = await client.PutAsJsonAsync("/1", new ConnectionRequest { Status = ConnectionRequestStatus.Accepted });

            var subject = await result.Content.ReadAsAsync<ConnectionRequest>();

            service.VerifyAll();
            Assert.IsTrue(subject.Id == 1);
            Assert.IsTrue(subject.Status == ConnectionRequestStatus.Accepted);
        }
    }
}