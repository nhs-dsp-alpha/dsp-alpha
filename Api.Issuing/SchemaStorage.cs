// <copyright file="Program.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

#pragma warning disable SA1200 // Using directives should be placed correctly
public class SchemaStorage : ISchemaStorage
{
    public SchemaStorage(IConfiguration configuration)
    {
        this.Schema = configuration?["IssuingDbSchema"] ?? "DSPIssuingOrg";
    }

    public string Schema { get; }
}
