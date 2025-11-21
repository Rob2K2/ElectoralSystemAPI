using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectoralSystem.API.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddUniquePartyPollingResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartyPollingResult_PollStationId",
                schema: "dbo",
                table: "PartyPollingResult");

            migrationBuilder.CreateIndex(
                name: "IX_PartyPollingResult_Unique_Station_Party_Date",
                schema: "dbo",
                table: "PartyPollingResult",
                columns: new[] { "PollStationId", "PoliticalPartyId", "RegisteredDate" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartyPollingResult_Unique_Station_Party_Date",
                schema: "dbo",
                table: "PartyPollingResult");

            migrationBuilder.CreateIndex(
                name: "IX_PartyPollingResult_PollStationId",
                schema: "dbo",
                table: "PartyPollingResult",
                column: "PollStationId");
        }
    }
}
