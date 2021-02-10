using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseballStatistics",
                columns: table => new
                {
                    StatLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BattingAve = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Runs = table.Column<int>(type: "int", nullable: false),
                    RBI = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hits = table.Column<int>(type: "int", nullable: false),
                    Steals = table.Column<int>(type: "int", nullable: false),
                    ERA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StrikeOuts = table.Column<int>(type: "int", nullable: false),
                    Saves = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseballStatistics", x => x.StatLineID);
                });

            migrationBuilder.CreateTable(
                name: "BasketballStatistics",
                columns: table => new
                {
                    StatLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Runs = table.Column<int>(type: "int", nullable: false),
                    FGoals = table.Column<int>(type: "int", nullable: false),
                    FThrows = table.Column<int>(type: "int", nullable: false),
                    Rebounds = table.Column<int>(type: "int", nullable: false),
                    Assissts = table.Column<int>(type: "int", nullable: false),
                    Steals = table.Column<int>(type: "int", nullable: false),
                    Turnovers = table.Column<int>(type: "int", nullable: false),
                    Fouls = table.Column<int>(type: "int", nullable: false),
                    PossessionTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketballStatistics", x => x.StatLineID);
                });

            migrationBuilder.CreateTable(
                name: "FootballStatistics",
                columns: table => new
                {
                    StatLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YardsRec = table.Column<int>(type: "int", nullable: false),
                    YardsRun = table.Column<int>(type: "int", nullable: false),
                    Sacks = table.Column<int>(type: "int", nullable: false),
                    Turnovers = table.Column<int>(type: "int", nullable: false),
                    Plays = table.Column<int>(type: "int", nullable: false),
                    FirstDownCons = table.Column<int>(type: "int", nullable: false),
                    Penalties = table.Column<int>(type: "int", nullable: false),
                    PossessionTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballStatistics", x => x.StatLineID);
                });

            migrationBuilder.CreateTable(
                name: "GolfStatistics",
                columns: table => new
                {
                    StatLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScoreToPar = table.Column<int>(type: "int", nullable: false),
                    DriveDistance = table.Column<int>(type: "int", nullable: false),
                    DriveAccuracy = table.Column<int>(type: "int", nullable: false),
                    GIR = table.Column<int>(type: "int", nullable: false),
                    PutsperGIR = table.Column<int>(type: "int", nullable: false),
                    Eagles = table.Column<int>(type: "int", nullable: false),
                    Birdies = table.Column<int>(type: "int", nullable: false),
                    Bogeys = table.Column<int>(type: "int", nullable: false),
                    SandSaves = table.Column<int>(type: "int", nullable: false),
                    Scrambles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GolfStatistics", x => x.StatLineID);
                });

            migrationBuilder.CreateTable(
                name: "HockeyStatistics",
                columns: table => new
                {
                    StatLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Shots = table.Column<int>(type: "int", nullable: false),
                    Hits = table.Column<int>(type: "int", nullable: false),
                    FaceOffWins = table.Column<int>(type: "int", nullable: false),
                    PowerPlayOpps = table.Column<int>(type: "int", nullable: false),
                    PenaltyMins = table.Column<int>(type: "int", nullable: false),
                    Blocks = table.Column<int>(type: "int", nullable: false),
                    TakeAWays = table.Column<int>(type: "int", nullable: false),
                    GiveAways = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HockeyStatistics", x => x.StatLineID);
                });

            migrationBuilder.CreateTable(
                name: "SoccerStatistics",
                columns: table => new
                {
                    StatLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    ShotOnGoal = table.Column<int>(type: "int", nullable: false),
                    Fouls = table.Column<int>(type: "int", nullable: false),
                    yellowCards = table.Column<int>(type: "int", nullable: false),
                    RedCards = table.Column<int>(type: "int", nullable: false),
                    OffSides = table.Column<int>(type: "int", nullable: false),
                    CornerKicks = table.Column<int>(type: "int", nullable: false),
                    PossessionTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoccerStatistics", x => x.StatLineID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseballStatistics");

            migrationBuilder.DropTable(
                name: "BasketballStatistics");

            migrationBuilder.DropTable(
                name: "FootballStatistics");

            migrationBuilder.DropTable(
                name: "GolfStatistics");

            migrationBuilder.DropTable(
                name: "HockeyStatistics");

            migrationBuilder.DropTable(
                name: "SoccerStatistics");
        }
    }
}
