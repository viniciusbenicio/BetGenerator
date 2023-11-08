using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorDeApostas.Migrations
{
    /// <inheritdoc />
    public partial class colunaerronatabelabet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "error",
                table: "Bet",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "error",
                table: "Bet");
        }
    }
}
