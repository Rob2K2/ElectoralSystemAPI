using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectoralSystem.API.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueAcronomy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Acronym",
                schema: "dbo",
                table: "PoliticalParty",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AlterColumn<string>(
                name: "Acronym",
                schema: "dbo",
                table: "PoliticalParty",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
