// <copyright file="IIssuingService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuing.Model
{
    public interface IIssuingService
    {
        Task<IEnumerable<ConnectionRequest>> ProcessRequests(string organisationCode, string orgUserId, ConnectionRequestStatus? status = default, int pageNum = 0, int pageSize = 30, bool enablePaging = false);

        Task<ConnectionRequest?> ChangeStatus(int id, ConnectionRequestStatus status, string organisationId, string orgUserId);
    }
}