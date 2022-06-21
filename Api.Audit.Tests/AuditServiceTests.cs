// <copyright file="AuditServiceTests.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Audit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ApiAudit.Services;
    using ApiAudit.Services.Context;
    using ApiAudit.Services.DTO;
    using ApiAudit.Services.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AuditServiceTests
    {
        private AuditDbContext auditDbContext = default!;
        private AuditService auditService = default!;

        [TestInitialize]
        public void Initialize()
        {
            var dbContext = new DbContextOptionsBuilder<AuditDbContext>();
            dbContext.UseInMemoryDatabase(Guid.NewGuid().ToString());
            this.auditDbContext = new AuditDbContext(dbContext.Options);
            this.auditService = new AuditService(this.auditDbContext);
        }

        [TestMethod]
        public async Task AuditService_AddAuditRecord_ReturnsAuditRecord()
        {
            // Arrange
            var auditRecordDto = new AuditRecordDto()
            {
                Action = 0,
                IssuedAt = DateTime.Now,
                IssuedBy = "Ryan",
                RequestId = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                Type = "Issued",
            };

            // Act
            var result = await this.auditService.AddAuditRecord(auditRecordDto);

            // Assert
            Assert.AreEqual(auditRecordDto.IssuedBy, result.IssuedBy);
            Assert.AreNotEqual(string.Empty, result.Id);
            Assert.AreEqual(this.auditDbContext.AuditRecords.Single(x => x.Id == result.Id), result);
        }

        [TestMethod]
        public async Task AuditService_Add2AuditRecords_VerifyIssuedIdsAreUnique()
        {
            // Arrange
            var auditRecord1Dto = new AuditRecordDto()
            {
                Action = 0,
                IssuedAt = DateTime.Now,
                IssuedBy = "Ryan",
                RequestId = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                Type = "Issued",
            };
            var auditRecord2Dto = new AuditRecordDto()
            {
                Action = 0,
                IssuedAt = DateTime.Now.AddHours(1),
                IssuedBy = "Ryan",
                RequestId = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                Type = "Issued",
            };

            // Act
            var result1 = await this.auditService.AddAuditRecord(auditRecord1Dto);
            var result2 = await this.auditService.AddAuditRecord(auditRecord2Dto);

            // Assert - verify 2 different Id's are issued
            Assert.AreNotEqual(result1.Id, result2.Id);
        }

        [TestMethod]
        public async Task AuditService_GetAuditRecord_ReturnsAuditRecord()
        {
            // Arrange
            var auditRecords = new List<AuditRecord>()
            {
                new AuditRecord()
                {
                    Id = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                    Action = 0,
                    IssuedAt = DateTime.Now,
                    IssuedBy = "Ryan",
                    RequestId = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                    Type = "Issued",
                },
                new AuditRecord()
                {
                    Id = "dea6871c-c354-4b4a-a25a-acac79337e45",
                    Action = 0,
                    IssuedAt = DateTime.Now.AddHours(1),
                    IssuedBy = "Jeff",
                    RequestId = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                    Type = "Verify",
                },
            };

            this.auditDbContext.AuditRecords.AddRange(auditRecords);
            await this.auditDbContext.SaveChangesAsync();

            // Act
            var result = await this.auditService.GetAuditRecord("dea6871c-c354-4b4a-a25a-acac79337e45");

            // Assert - verify requested record matches expected
            Assert.AreEqual(auditRecords[1], result);
        }

        [TestMethod]
        public async Task AuditService_ListAuditRecords_ReturnsListOfAuditRecords()
        {
            // Arrange
            var auditRecords = new List<AuditRecord>()
            {
                new AuditRecord()
                {
                    Id = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                    Action = 0,
                    IssuedAt = DateTime.Now,
                    IssuedBy = "Ryan",
                    RequestId = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                    Type = "Issued",
                },
                new AuditRecord()
                {
                    Id = "dea6871c-c354-4b4a-a25a-acac79337e45",
                    Action = 0,
                    IssuedAt = DateTime.Now.AddHours(1),
                    IssuedBy = "Jeff",
                    RequestId = "db9c85fb-07f6-4e1a-92f6-0c17c38708b0",
                    Type = "Verify",
                },
            };

            this.auditDbContext.AuditRecords.AddRange(auditRecords);
            await this.auditDbContext.SaveChangesAsync();

            // Act
            var result = await this.auditService.ListAuditRecords();

            // Assert - verify requested record matches expected
            Assert.AreEqual(auditRecords.Count(), result.Count());
        }
    }
}