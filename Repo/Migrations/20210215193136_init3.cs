using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Runs",
                table: "BasketballStatistics",
                newName: "ThreePts");

            migrationBuilder.RenameColumn(
                name: "Assissts",
                table: "BasketballStatistics",
                newName: "Assists");

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => new { x.UserID, x.GameID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.RenameColumn(
                name: "ThreePts",
                table: "BasketballStatistics",
                newName: "Runs");

            migrationBuilder.RenameColumn(
                name: "Assists",
                table: "BasketballStatistics",
                newName: "Assissts");
        }
    }
}
