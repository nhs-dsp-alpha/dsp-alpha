// <copyright file="SchemaMigrationsSqlGenerator.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

#pragma warning disable SA1200 // Using directives should be placed correctly
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
/// <summary>
/// A class injected into the SQL command generation
/// in order to replace the schema with the one we want.
/// </summary>
public sealed class SchemaMigrationsSqlGenerator : IMigrationsSqlGenerator
{
    #region Fields

    private readonly MigrationsSqlGenerator mOriginal;

    private readonly ISchemaStorage mSchema;

    #endregion


    #region Init aned clean-up

    /// <summary>
    /// Constructor for dependency injection.
    /// </summary>
    /// <param name="original">Previously used SQL generator</param>
    /// <param name="schema">Where the schema name is stored</param>
    public SchemaMigrationsSqlGenerator(MigrationsSqlGenerator original, ISchemaStorage schema)
    {
        mOriginal = original;
        mSchema = schema;
    }

    public IReadOnlyList<MigrationCommand> Generate(
        IReadOnlyList<MigrationOperation> operations,
        IModel? model = null,
        MigrationsSqlGenerationOptions options = MigrationsSqlGenerationOptions.Default)
    {
        foreach (var operation in operations)
        {
            switch (operation)
            {
                case SqlServerCreateDatabaseOperation _:
                    break;

                case EnsureSchemaOperation ensureOperation:
                    ensureOperation.Name = mSchema.Schema;
                    break;

                case CreateTableOperation tblOperation:
                    tblOperation.Schema = mSchema.Schema;
                    break;

                case DropTableOperation tblOperation:
                    tblOperation.Schema = mSchema.Schema;
                    break;

                case CreateIndexOperation idxOperation:
                    idxOperation.Schema = mSchema.Schema;
                    break;

                case DropIndexOperation idxOperation:
                    idxOperation.Schema = mSchema.Schema;
                    break;

                default:
                    throw new NotImplementedException(
                        $"Migration operation of type {operation.GetType().Name} is not supported by SchemaMigrationsSqlGenerator.");
            }
        }

        return mOriginal.Generate(operations, model);
    }

    #endregion
}