// <copyright file="IClientService.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Services
{
    using Api.Services.Model;

    public interface IClientService
    {
        Task<ClientResponse> ProcessRequest(ClientRequest request);

        Task<IssuableCredential> ProcessRequest(CredentialRequest request);
    }
}