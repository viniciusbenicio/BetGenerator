using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorDeApostas.Migrations
{
    /// <inheritdoc />
    public partial class Tabeladeapostas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qtGames = table.Column<int>(type: "INTEGER", nullable: false),
                    numberGames = table.Column<int>(type: "INTEGER", nullable: false),
                    resultGames = table.Column<string>(type: "NVARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bet", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bet");
        }
    }
}
