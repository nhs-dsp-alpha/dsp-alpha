// <copyright file="20220511150108_InitialCreate.cs" company="SiteKit Health Solutions">
// Copyright (c) Sitekit Applications. All rights reserved.
// </copyright>

#nullable disable

namespace Api.Organisations.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DSP");

            migrationBuilder.CreateTable(
                name: "Organisations",
                schema: "DSP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "DSP",
                table: "Organisations",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, "OrgOne", "Organisation One" });

            migrationBuilder.InsertData(
                schema: "DSP",
                table: "Organisations",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 2, "OrgTwo", "Organisation Two" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organisations",
                schema: "DSP");
        }
    }
}