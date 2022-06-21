// <copyright file="ApiTests.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Organisations.Tests
{
    using System.Collections.Generic;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Api.Organisations.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public async Task GetList_returns_list()
        {
            await using var application = new ApiApplication();

            var client = application.CreateClient();
            var organisations = await client.GetFromJsonAsync<List<Organisation>>("/");

            Assert.IsNotNull(organisations);
            Assert.IsTrue(organisations.Count == 2);
        }
    }
}