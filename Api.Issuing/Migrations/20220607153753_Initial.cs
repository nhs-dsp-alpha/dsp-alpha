using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Issuing.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "IssuingOrg2");

            migrationBuilder.CreateTable(
                name: "StaffMembers",
                schema: "IssuingOrg2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConnectionRequests",
                schema: "IssuingOrg2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PortalUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffMemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConnectionRequests_StaffMembers_StaffMemberId",
                        column: x => x.StaffMemberId,
                        principalSchema: "IssuingOrg2",
                        principalTable: "StaffMembers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                schema: "IssuingOrg2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IssuedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SourceOrganisation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffMemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credentials_StaffMembers_StaffMemberId",
                        column: x => x.StaffMemberId,
                        principalSchema: "IssuingOrg2",
                        principalTable: "StaffMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Presentations",
                schema: "IssuingOrg2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffMemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presentations_StaffMembers_StaffMemberId",
                        column: x => x.StaffMemberId,
                        principalSchema: "IssuingOrg2",
                        principalTable: "StaffMembers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CredentialPresentation",
                schema: "IssuingOrg2",
                columns: table => new
                {
                    CredentialsId = table.Column<int>(type: "int", nullable: false),
                    PresentationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CredentialPresentation", x => new { x.CredentialsId, x.PresentationsId });
                    table.ForeignKey(
                        name: "FK_CredentialPresentation_Credentials_CredentialsId",
                        column: x => x.CredentialsId,
                        principalSchema: "IssuingOrg2",
                        principalTable: "Credentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CredentialPresentation_Presentations_PresentationsId",
                        column: x => x.PresentationsId,
                        principalSchema: "IssuingOrg2",
                        principalTable: "Presentations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionRequests_StaffMemberId",
                schema: "IssuingOrg2",
                table: "ConnectionRequests",
                column: "StaffMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionRequests_Status",
                schema: "IssuingOrg2",
                table: "ConnectionRequests",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_CredentialPresentation_PresentationsId",
                schema: "IssuingOrg2",
                table: "CredentialPresentation",
                column: "PresentationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_StaffMemberId",
                schema: "IssuingOrg2",
                table: "Credentials",
                column: "StaffMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_Status",
                schema: "IssuingOrg2",
                table: "Credentials",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Presentations_StaffMemberId",
                schema: "IssuingOrg2",
                table: "Presentations",
                column: "StaffMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConnectionRequests",
                schema: "IssuingOrg2");

            migrationBuilder.DropTable(
                name: "CredentialPresentation",
                schema: "IssuingOrg2");

            migrationBuilder.DropTable(
                name: "Credentials",
                schema: "IssuingOrg2");

            migrationBuilder.DropTable(
                name: "Presentations",
                schema: "IssuingOrg2");

            migrationBuilder.DropTable(
                name: "StaffMembers",
                schema: "IssuingOrg2");
        }
    }
}
