using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorDeApostas.Migrations
{
    /// <inheritdoc />
    public partial class BetColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "qtGames",
                table: "Bet",
                newName: "TotalNumbers");

            migrationBuilder.RenameColumn(
                name: "numberGames",
                table: "Bet",
                newName: "NumberOfGames");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalNumbers",
                table: "Bet",
                newName: "qtGames");

            migrationBuilder.RenameColumn(
                name: "NumberOfGames",
                table: "Bet",
                newName: "numberGames");
        }
    }
}
