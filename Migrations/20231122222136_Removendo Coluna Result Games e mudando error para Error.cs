using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorDeApostas.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoColunaResultGamesemudandoerrorparaError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "resultGames",
                table: "Bet");

            migrationBuilder.RenameColumn(
                name: "error",
                table: "Bet",
                newName: "Error");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Error",
                table: "Bet",
                newName: "error");

            migrationBuilder.AddColumn<string>(
                name: "resultGames",
                table: "Bet",
                type: "NVARCHAR(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
