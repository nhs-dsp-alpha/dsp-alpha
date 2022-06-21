// <copyright file="AuditApiTests.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Audit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using ApiAudit.Services.Context;
    using ApiAudit.Services.DTO;
    using ApiAudit.Services.Models;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AuditApiTests
    {
        [TestMethod]
        public async Task AuditApi_PostAuditRecordDto_ReturnsNewAuditRecord()
        {
            await using var application = new ApiAuditApplication();

            var client = application.CreateClient();

            AuditRecordDto auditRecord = new AuditRecordDto()
            {
                Action = 0,
                IssuedAt = DateTime.Now,
                IssuedBy = "Ryan",
                RequestId = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                Type = "PrimaryIdentityCredential",
            };

            // Act
            var response = await client.PostAsJsonAsync("/audit", auditRecord);

            var result = response.Content.ReadFromJsonAsync<AuditRecord>();

            Assert.IsNotNull(response);
            Assert.IsTrue(result.Result?.Type == "PrimaryIdentityCredential");
        }

        [TestMethod]
        public async Task AuditApi_GetAuditRecord_ReturnsAuditRecord()
        {
            await using var application = new ApiAuditApplication();
            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var auditDbContext = provider.GetRequiredService<AuditDbContext>())
                {
                    await auditDbContext.Database.EnsureCreatedAsync();

                    await auditDbContext.AuditRecords.AddAsync(new AuditRecord()
                    {
                        Id = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                        Action = 0,
                        IssuedAt = DateTime.Now,
                        IssuedBy = "Ryan",
                        RequestId = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                        Type = "PrimaryIdentityCredential",
                    });

                    await auditDbContext.SaveChangesAsync();
                }
            }

            var client = application.CreateClient();
            var auditRecords = await client.GetFromJsonAsync<AuditRecord>("/audit/db9c85fb-07f6-4e1a-92f6-0c17c38708b0");

            Assert.IsNotNull(auditRecords);
        }

        [TestMethod]
        public async Task AuditApi_GetAuditRecords_ReturnsListOfAuditRecords()
        {
            await using var application = new ApiAuditApplication();
            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var auditDbContext = provider.GetRequiredService<AuditDbContext>())
                {
                    await auditDbContext.Database.EnsureCreatedAsync();

                    await auditDbContext.AuditRecords.AddRangeAsync(new List<AuditRecord>()
                    {
                        new AuditRecord()
                        {
                        Id = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                        Action = 0,
                        IssuedAt = DateTime.Now,
                        IssuedBy = "Ryan",
                        RequestId = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                        Type = "PrimaryIdentityCredential",
                        },
                        new AuditRecord()
                        {
                            Id = "ce6a086a-d70a-4c49-9087-4a0db5830a51",
                            Action = 0,
                            IssuedAt = DateTime.Now,
                            IssuedBy = "Ryan",
                            RequestId = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                            Type = "PrimaryIdentityCredential",
                        },
                        new AuditRecord()
                        {
                            Id = "9e2581ae-507c-414d-81d7-bf20388498d9",
                            Action = 0,
                            IssuedAt = DateTime.Now,
                            IssuedBy = "Ryan",
                            RequestId = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                            Type = "PrimaryIdentityCredential",
                        },
                    });

                    await auditDbContext.SaveChangesAsync();
                }
            }

            var client = application.CreateClient();
            var auditRecords = await client.GetFromJsonAsync<List<AuditRecord>>("/audits");

            Assert.AreEqual(3, auditRecords.Count());
        }
    }
}