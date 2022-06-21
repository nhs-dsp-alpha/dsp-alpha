// <copyright file="IOrganisationsService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Organisations
{
    using Api.Organisations.Model;

    public interface IOrganisationsService
    {
        Task<IEnumerable<Organisation>> GetList();

        Task<Organisation?> Get(int id);
    }
}