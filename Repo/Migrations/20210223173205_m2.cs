using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamGames",
                columns: table => new
                {
                    TeamID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamGames", x => new { x.TeamID, x.GameID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamGames");
        }
    }
}
