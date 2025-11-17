using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectoralSystem.API.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintToPoliticalPartyAcronym : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParty_Acronym",
                schema: "dbo",
                table: "PoliticalParty",
                column: "Acronym",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PoliticalParty_Acronym",
                schema: "dbo",
                table: "PoliticalParty");
        }
    }
}

