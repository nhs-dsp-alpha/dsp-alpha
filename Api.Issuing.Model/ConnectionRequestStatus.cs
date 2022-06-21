// <copyright file="ConnectionRequestStatus.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuing.Model
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ConnectionRequestStatus
    {
        Shared,
        Accepted,
        Rejected,
        Active,
    }
}