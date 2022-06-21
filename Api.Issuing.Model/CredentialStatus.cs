// <copyright file="CredentialStatus.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

namespace Api.Issuing.Model
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CredentialStatus
    {
        Active,
        [JsonPropertyName("Needing information")]
        NeedInformation,
    }
}