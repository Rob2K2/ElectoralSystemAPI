using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectoralSystem.API.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "PoliticalParty",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticalParty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PollingStation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisteredVoters = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollingStation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartyPollingResult",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PollStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PoliticalPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VotesValid = table.Column<int>(type: "int", nullable: false),
                    VotesBlank = table.Column<int>(type: "int", nullable: false),
                    VotesNull = table.Column<int>(type: "int", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyPollingResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartyPollingResult_PoliticalParty_PoliticalPartyId",
                        column: x => x.PoliticalPartyId,
                        principalSchema: "dbo",
                        principalTable: "PoliticalParty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartyPollingResult_PollingStation_PollStationId",
                        column: x => x.PollStationId,
                        principalSchema: "dbo",
                        principalTable: "PollingStation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChangeHistory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChangeHistory_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeHistory_Id",
                schema: "dbo",
                table: "ChangeHistory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeHistory_UserId",
                schema: "dbo",
                table: "ChangeHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PartyPollingResult_Id",
                schema: "dbo",
                table: "PartyPollingResult",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PartyPollingResult_PoliticalPartyId",
                schema: "dbo",
                table: "PartyPollingResult",
                column: "PoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_PartyPollingResult_PollStationId",
                schema: "dbo",
                table: "PartyPollingResult",
                column: "PollStationId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParty_Id",
                schema: "dbo",
                table: "PoliticalParty",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStation_Id",
                schema: "dbo",
                table: "PollingStation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                schema: "dbo",
                table: "User",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeHistory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PartyPollingResult",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PoliticalParty",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PollingStation",
                schema: "dbo");
        }
    }
}
