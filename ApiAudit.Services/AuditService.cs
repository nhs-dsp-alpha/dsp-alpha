// <copyright file="AuditService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace ApiAudit.Services
{
    using ApiAudit.Services.Context;
    using ApiAudit.Services.DTO;
    using ApiAudit.Services.Interfaces;
    using ApiAudit.Services.Models;
    using Microsoft.EntityFrameworkCore;

    public class AuditService : IAuditService
    {
        private readonly AuditDbContext dbContext;

        public AuditService(AuditDbContext db)
        {
            this.dbContext = db;
        }

        public async Task<AuditRecord> AddAuditRecord(AuditRecordDto auditRecordDto)
        {
            try
            {
                // Add Audit Record
                var auditRecordEntity = this.dbContext.AuditRecords.Add(auditRecordDto.DtoToModel());

                // Save Changes Async
                await this.dbContext.SaveChangesAsync();

                // Return newly created entity
                return auditRecordEntity.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<AuditRecord> GetAuditRecord(string id)
        {
            // Get Audit Record
            var auditRecord = await this.dbContext.AuditRecords.SingleAsync(x => x.Id == id);

            // Return record
            return auditRecord;
        }

        public async Task<List<AuditRecord>> ListAuditRecords()
        {
            // Get list of Audit Records
            var auditRecords = await this.dbContext.AuditRecords.ToListAsync();

            // Return record
            return auditRecords;
        }
    }
}