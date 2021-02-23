using System;
using Microsoft.EntityFrameworkCore;
using Xunit;

using Repository;
using Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace Service.Tests
{
    public class LogicTests {

        /// <summary>
        /// Tests the BuildPlayerGame method of Logic
        /// </summary>
        [Fact]
        public async void TestForBuildPlayerGame()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var playerStatistic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = Guid.NewGuid(),
                    GameID = Guid.NewGuid()
                };

                await l.BuildPlayerGame(playerStatistic.UserID, playerStatistic.GameID, playerStatistic.StatLineID);
                Assert.NotEmpty(context.PlayerGames);
            }
        }

        /// <summary>
        /// Tests the BuildTeamGame method of Logic
        /// </summary>
        //[Fact]
        //public async void TestForBuildTeamGame()
        //{
        //    var options = new DbContextOptionsBuilder<StatsContext>()
        //    .UseInMemoryDatabase(databaseName: "p3StatService")
        //    .Options;

        //    using (var context = new StatsContext(options))
        //    {
        //        context.Database.EnsureDeleted();
        //        context.Database.EnsureCreated();

        //        Repo r = new Repo(context, new NullLogger<Repo>());
        //        Logic l = new Logic(r, new NullLogger<Repo>());
        //        var teamStatistic = new TeamGame
        //        {
        //            TeamID = "tigers",
        //            StatLineID = Guid.NewGuid(),
        //            GameID = Guid.NewGuid()
        //        };

        //        await l.BuildTeamGame(teamStatistic.TeamID, teamStatistic.GameID, teamStatistic.StatLineID);
        //        Assert.NotEmpty(context.TeamGames);
        //    }
        //}

        /// <summary>
        /// Tests the CreateStatistic(basketball) method of Logic
        /// </summary>
        [Fact]
        public async void TestForCreateBasketballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var basketballStatistics = new BasketballStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    FGoals = 12,
                    ThreePts = 8,
                    FThrows = 10,
                    Rebounds = 15,
                    Assists = 23,
                    Steals = 17,
                    Turnovers = 11,
                    Fouls = 7,
                    PossessionTime = 9
                };
                var playerStatistic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = basketballStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };

                var sportStastic = await l.CreateStatistic(playerStatistic.UserID, playerStatistic.GameID, basketballStatistics);
                Assert.Equal(12, sportStastic.FGoals);
                Assert.Equal(8, sportStastic.ThreePts);
                Assert.Equal(10, sportStastic.FThrows);
                Assert.Equal(15, sportStastic.Rebounds);
                Assert.Equal(23, sportStastic.Assists);
                Assert.Equal(17, sportStastic.Steals);
                Assert.Equal(11, sportStastic.Turnovers);
                Assert.Equal(7, sportStastic.Fouls);
                Assert.Equal(9, sportStastic.PossessionTime);
            }
        }

        /// <summary>
        /// Tests the CreateStatistic(baseball) method of Logic
        /// </summary>
        [Fact]
        public async void TestForCreateBaseballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var baseballStatistics = new BaseballStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    BattingAve = 4.7689M,
                    Runs = 17,
                    RBI = 2.3156M,
                    Hits = 13,
                    Steals = 23,
                    ERA = 3.1114M,
                    StrikeOuts = 32,
                    Saves = 25
                };
                var playerStatistic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = baseballStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };

                var sportStastic = await l.CreateStatistic(playerStatistic.UserID, playerStatistic.GameID, baseballStatistics);
                Assert.Equal(4.7689M, sportStastic.baseballStat.BattingAve);
                Assert.Equal(17, sportStastic.baseballStat.Runs);
                Assert.Equal(2.3156M, sportStastic.baseballStat.RBI);
                Assert.Equal(13, sportStastic.baseballStat.Hits);
                Assert.Equal(23, sportStastic.baseballStat.Steals);
                Assert.Equal(3.1114M, sportStastic.baseballStat.ERA);
                Assert.Equal(32, sportStastic.baseballStat.StrikeOuts);
                Assert.Equal(25, sportStastic.baseballStat.Saves);
            }
        }

        /// <summary>
        /// Tests the CreateStatistic(football) method of Logic
        /// </summary>
        [Fact]
        public async void TestForCreateFootballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var footballStatistics = new FootBallStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    YardsRec = 25,
                    YardsRun = 72,
                    Sacks = 19,
                    Turnovers = 13,
                    Plays = 31,
                    FirstDownCons = 35,
                    PossessionTime = 21,
                    Penalties = 13
                };
                var playerStatistic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = footballStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };

                var sportStastic = await l.CreateStatistic(playerStatistic.UserID, playerStatistic.GameID, footballStatistics);
                Assert.Equal(25, sportStastic.YardsRec);
                Assert.Equal(72, sportStastic.YardsRun);
                Assert.Equal(19, sportStastic.Sacks);
                Assert.Equal(13, sportStastic.Turnovers);
                Assert.Equal(31, sportStastic.Plays);
                Assert.Equal(35, sportStastic.FirstDownCons);
                Assert.Equal(13, sportStastic.Penalties);
                Assert.Equal(21, sportStastic.PossessionTime);
            }
        }

        /// <summary>
        /// Tests the CreateStatistic(golf) method of Logic
        /// </summary>
        [Fact]
        public async void TestForCreateGolfStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var golfStatistics = new GolfStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    ScoreToPar = 41,
                    DriveDistance = 312,
                    DriveAccuracy = 75,
                    GIR = 37,
                    PutsperGIR = 15,
                    Eagles = 7,
                    Birdies = 15,
                    Bogeys = 23,
                    SandSaves = 11,
                    Scrambles = 25
                };
                var playerStatistic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = golfStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };

                var sportStastic = await l.CreateStatistic(playerStatistic.UserID, playerStatistic.GameID, golfStatistics);
                Assert.Equal(41, sportStastic.ScoreToPar);
                Assert.Equal(312, sportStastic.DriveDistance);
                Assert.Equal(75, sportStastic.DriveAccuracy);
                Assert.Equal(37, sportStastic.GIR);
                Assert.Equal(15, sportStastic.PutsperGIR);
                Assert.Equal(7, sportStastic.Eagles);
                Assert.Equal(15, sportStastic.Birdies);
                Assert.Equal(23, sportStastic.Bogeys);
                Assert.Equal(11, sportStastic.SandSaves);
                Assert.Equal(25, sportStastic.Scrambles);
            }
        }

        /// <summary>
        /// Tests the CreateStatistic(hockey) method of Logic
        /// </summary>
        [Fact]
        public async void TestForCreateHockeyStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var hockeyStatistics = new HockeyStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    Goals = 16,
                    Shots = 51,
                    Hits = 27,
                    FaceOffWins = 7,
                    PowerPlayOpps = 23,
                    PenaltyMins = 45,
                    Blocks = 21,
                    TakeAWays = 12,
                    GiveAways = 19
                };
                var playerStatistic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = hockeyStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };

                var sportStastic = await l.CreateStatistic(playerStatistic.UserID, playerStatistic.GameID, hockeyStatistics);
                Assert.Equal(16, sportStastic.Goals);
                Assert.Equal(51, sportStastic.Shots);
                Assert.Equal(27, sportStastic.Hits);
                Assert.Equal(7, sportStastic.FaceOffWins);
                Assert.Equal(23, sportStastic.PowerPlayOpps);
                Assert.Equal(45, sportStastic.PenaltyMins);
                Assert.Equal(21, sportStastic.Blocks);
                Assert.Equal(12, sportStastic.TakeAWays);
                Assert.Equal(19, sportStastic.GiveAways);
            }
        }

        /// <summary>
        /// Tests the CreateStatistic(soccer) method of Logic
        /// </summary>
        [Fact]
        public async void TestForCreateSoccerStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var soccerStatistics = new SoccerStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    Goals = 33,
                    ShotOnGoal = 55,
                    Fouls = 73,
                    yellowCards = 47,
                    RedCards = 31,
                    OffSides = 26,
                    CornerKicks = 67,
                    PossessionTime = 44
                };
                var playerStatistic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = soccerStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };

                var sportStastic = await l.CreateStatistic(playerStatistic.UserID, playerStatistic.GameID, soccerStatistics);
                Assert.Equal(33, sportStastic.Goals);
                Assert.Equal(55, sportStastic.ShotOnGoal);
                Assert.Equal(73, sportStastic.Fouls);
                Assert.Equal(47, sportStastic.yellowCards);
                Assert.Equal(31, sportStastic.RedCards);
                Assert.Equal(26, sportStastic.OffSides);
                Assert.Equal(67, sportStastic.CornerKicks);
                Assert.Equal(44, sportStastic.PossessionTime);
            }
        }

        /*****************************************************************************************/

        /// <summary>
        /// Tests the CreateTeamStatistic(basketball) method of Logic
        /// </summary>
        //[Fact]
        //public async void TestForCreateBasketballTeamStatistic()
        //{
        //    var options = new DbContextOptionsBuilder<StatsContext>()
        //    .UseInMemoryDatabase(databaseName: "p3StatService")
        //    .Options;

        //    using (var context = new StatsContext(options))
        //    {
        //        context.Database.EnsureDeleted();
        //        context.Database.EnsureCreated();

        //        Repo r = new Repo(context, new NullLogger<Repo>());
        //        Logic l = new Logic(r, new NullLogger<Repo>());
        //        var basketballStatistics = new BasketballStatistic()
        //        {
        //            StatLineID = Guid.NewGuid(),
        //            FGoals = 12,
        //            ThreePts = 8,
        //            FThrows = 10,
        //            Rebounds = 15,
        //            Assists = 23,
        //            Steals = 17,
        //            Turnovers = 11,
        //            Fouls = 7,
        //            PossessionTime = 9
        //        };
        //        var teamStatistic = new TeamGame
        //        {
        //            TeamID = "tigers",
        //            StatLineID = Guid.NewGuid(),
        //            GameID = Guid.NewGuid()
        //        };

        //        var sportStastic = await l.CreateTeamStatistic(teamStatistic.TeamID, teamStatistic.GameID, basketballStatistics);
        //        Assert.Equal(12, sportStastic.FGoals);
        //        Assert.Equal(8, sportStastic.ThreePts);
        //        Assert.Equal(10, sportStastic.FThrows);
        //        Assert.Equal(15, sportStastic.Rebounds);
        //        Assert.Equal(23, sportStastic.Assists);
        //        Assert.Equal(17, sportStastic.Steals);
        //        Assert.Equal(11, sportStastic.Turnovers);
        //        Assert.Equal(7, sportStastic.Fouls);
        //        Assert.Equal(9, sportStastic.PossessionTime);
        //    }
        //}

        /*****************************************************************************************/

        /// <summary>
        /// Tests the GetBasketballStatisticsById() method of Logic
        /// </summary>
        [Fact]
        public async void TestForGetBasketballStatisticsById()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var basketballStatistics = new BasketballStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    FGoals = 12,
                    ThreePts = 8,
                    FThrows = 10,
                    Rebounds = 15,
                    Assists = 23,
                    Steals = 17,
                    Turnovers = 11,
                    Fouls = 7,
                    PossessionTime = 9
                };
                r.BasketballStatistics.Add(basketballStatistics);
                await r.CommitSave();

                var sportStastic = await l.GetBasketballStatisticById(basketballStatistics.StatLineID);
                Assert.Equal(12, sportStastic.FGoals);
                Assert.Equal(8, sportStastic.ThreePts);
                Assert.Equal(10, sportStastic.FThrows);
                Assert.Equal(15, sportStastic.Rebounds);
                Assert.Equal(23, sportStastic.Assists);
                Assert.Equal(17, sportStastic.Steals);
                Assert.Equal(11, sportStastic.Turnovers);
                Assert.Equal(7, sportStastic.Fouls);
                Assert.Equal(9, sportStastic.PossessionTime);
            }
        }

        /// <summary>
        /// Tests the GetBaseballStatisticsById() method of Logic
        /// </summary>
        [Fact]
        public async void TestForGetBaseballStatisticsById()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var baseballStatistics = new BaseballStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    BattingAve = 4.7689M,
                    Runs = 17,
                    RBI = 2.3156M,
                    Hits = 13,
                    Steals = 23,
                    ERA = 3.1114M,
                    StrikeOuts = 32,
                    Saves = 25
                };
                r.BaseballStatistics.Add(baseballStatistics);
                await r.CommitSave();

                var sportStastic = await l.GetBaseballStatisticById(baseballStatistics.StatLineID);
                Assert.Equal(4.7689M, sportStastic.BattingAve);
                Assert.Equal(17, sportStastic.Runs);
                Assert.Equal(2.3156M, sportStastic.RBI);
                Assert.Equal(13, sportStastic.Hits);
                Assert.Equal(23, sportStastic.Steals);
                Assert.Equal(3.1114M, sportStastic.ERA);
                Assert.Equal(32, sportStastic.StrikeOuts);
                Assert.Equal(25, sportStastic.Saves);
            }
        }

        /// <summary>
        /// Tests the GetFootballStatisticsById() method of Logic
        /// </summary>
        [Fact]
        public async void TestForGetFootballStatisticsById()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var footballStatistics = new FootBallStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    YardsRec = 25,
                    YardsRun = 72,
                    Sacks = 19,
                    Turnovers = 13,
                    Plays = 31,
                    FirstDownCons = 35,
                    PossessionTime = 21,
                    Penalties = 13
                };
                r.FootballStatistics.Add(footballStatistics);
                await r.CommitSave();

                var sportStastic = await l.GetFootballStatisticById(footballStatistics.StatLineID);
                Assert.Equal(25, sportStastic.YardsRec);
                Assert.Equal(72, sportStastic.YardsRun);
                Assert.Equal(19, sportStastic.Sacks);
                Assert.Equal(13, sportStastic.Turnovers);
                Assert.Equal(31, sportStastic.Plays);
                Assert.Equal(35, sportStastic.FirstDownCons);
                Assert.Equal(13, sportStastic.Penalties);
                Assert.Equal(21, sportStastic.PossessionTime);
            }
        }

        /// <summary>
        /// Tests the GetGolfStatisticsById() method of Logic
        /// </summary>
        [Fact]
        public async void TestForGetGolfStatisticsById()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var golfStatistics = new GolfStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    ScoreToPar = 41,
                    DriveDistance = 312,
                    DriveAccuracy = 75,
                    GIR = 37,
                    PutsperGIR = 15,
                    Eagles = 7,
                    Birdies = 15,
                    Bogeys = 23,
                    SandSaves = 11,
                    Scrambles = 25
                };
                r.GolfStatistics.Add(golfStatistics);
                await r.CommitSave();

                var sportStastic = await l.GetGolfStatisticById(golfStatistics.StatLineID);
                Assert.Equal(41, sportStastic.ScoreToPar);
                Assert.Equal(312, sportStastic.DriveDistance);
                Assert.Equal(75, sportStastic.DriveAccuracy);
                Assert.Equal(37, sportStastic.GIR);
                Assert.Equal(15, sportStastic.PutsperGIR);
                Assert.Equal(7, sportStastic.Eagles);
                Assert.Equal(15, sportStastic.Birdies);
                Assert.Equal(23, sportStastic.Bogeys);
                Assert.Equal(11, sportStastic.SandSaves);
                Assert.Equal(25, sportStastic.Scrambles);
            }
        }

        /// <summary>
        /// Tests the GetHockeyStatisticsById() method of Logic
        /// </summary>
        [Fact]
        public async void TestForGetHockeyStatisticsById()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var hockeyStatistics = new HockeyStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    Goals = 16,
                    Shots = 51,
                    Hits = 27,
                    FaceOffWins = 7,
                    PowerPlayOpps = 23,
                    PenaltyMins = 45,
                    Blocks = 21,
                    TakeAWays = 12,
                    GiveAways = 19
                };
                r.HockeyStatistics.Add(hockeyStatistics);
                await r.CommitSave();

                var sportStastic = await l.GetHockeyStatisticById(hockeyStatistics.StatLineID);
                Assert.Equal(16, sportStastic.Goals);
                Assert.Equal(51, sportStastic.Shots);
                Assert.Equal(27, sportStastic.Hits);
                Assert.Equal(7, sportStastic.FaceOffWins);
                Assert.Equal(23, sportStastic.PowerPlayOpps);
                Assert.Equal(45, sportStastic.PenaltyMins);
                Assert.Equal(21, sportStastic.Blocks);
                Assert.Equal(12, sportStastic.TakeAWays);
                Assert.Equal(19, sportStastic.GiveAways);
            }
        }

        /// <summary>
        /// Tests the GetSoccerStatisticsById() method of Logic
        /// </summary>
        [Fact]
        public async void TestForGetSoccerStatisticsById()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var soccerStatistics = new SoccerStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    Goals = 33,
                    ShotOnGoal = 55,
                    Fouls = 73,
                    yellowCards = 47,
                    RedCards = 31,
                    OffSides = 26,
                    CornerKicks = 67,
                    PossessionTime = 44
                };
                r.SoccerStatistics.Add(soccerStatistics);
                await r.CommitSave();

                var sportStastic = await l.GetSoccerStatisticById(soccerStatistics.StatLineID);
                Assert.Equal(33, sportStastic.Goals);
                Assert.Equal(55, sportStastic.ShotOnGoal);
                Assert.Equal(73, sportStastic.Fouls);
                Assert.Equal(47, sportStastic.yellowCards);
                Assert.Equal(31, sportStastic.RedCards);
                Assert.Equal(26, sportStastic.OffSides);
                Assert.Equal(67, sportStastic.CornerKicks);
                Assert.Equal(44, sportStastic.PossessionTime);
            }
        }

        /*****************************************************************************************/

        /// <summary>
        /// Tests the GetBasketballGameStatistic() method of Logic
        /// </summary>
        [Fact]
        public async void TestForGetBasketballGameStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var basketballStatistics = new BasketballStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    FGoals = 12,
                    ThreePts = 8,
                    FThrows = 10,
                    Rebounds = 15,
                    Assists = 23,
                    Steals = 17,
                    Turnovers = 11,
                    Fouls = 7,
                    PossessionTime = 9
                };
                r.BasketballStatistics.Add(basketballStatistics);
                var playerStatstic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = basketballStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };
                r.PlayerGames.Add(playerStatstic);
                await r.CommitSave();

                var sportStastic = await l.GetBasketballGameStatistic(playerStatstic.UserID, playerStatstic.GameID);
                Assert.Equal(12, sportStastic.FGoals);
                Assert.Equal(8, sportStastic.ThreePts);
                Assert.Equal(10, sportStastic.FThrows);
                Assert.Equal(15, sportStastic.Rebounds);
                Assert.Equal(23, sportStastic.Assists);
                Assert.Equal(17, sportStastic.Steals);
                Assert.Equal(11, sportStastic.Turnovers);
                Assert.Equal(7, sportStastic.Fouls);
                Assert.Equal(9, sportStastic.PossessionTime);
            }
        }

        /// <summary>
        /// Tests the GetBaseballGameStatistic() method of Logic
        /// </summary>
        [Fact]
        public async void TestForGetBaseballGameStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var baseballStatistics = new BaseballStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    BattingAve = 4.7689M,
                    Runs = 17,
                    RBI = 2.3156M,
                    Hits = 13,
                    Steals = 23,
                    ERA = 3.1114M,
                    StrikeOuts = 32,
                    Saves = 25
                };
                r.BaseballStatistics.Add(baseballStatistics);
                var playerStatstic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = baseballStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };
                r.PlayerGames.Add(playerStatstic);
                await r.CommitSave();

                var sportStastic = await l.GetBaseballGameStatistic(playerStatstic.UserID, playerStatstic.GameID);
                Assert.Equal(4.7689M, sportStastic.BattingAve);
                Assert.Equal(17, sportStastic.Runs);
                Assert.Equal(2.3156M, sportStastic.RBI);
                Assert.Equal(13, sportStastic.Hits);
                Assert.Equal(23, sportStastic.Steals);
                Assert.Equal(3.1114M, sportStastic.ERA);
                Assert.Equal(32, sportStastic.StrikeOuts);
                Assert.Equal(25, sportStastic.Saves);
            }
        }

        /// <summary>
        /// Tests the GetFootballGameStatistic() method of Logic
        /// </summary>
        [Fact]
        public async void TestForGetFootballGameStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var footballStatistics = new FootBallStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    YardsRec = 25,
                    YardsRun = 72,
                    Sacks = 19,
                    Turnovers = 13,
                    Plays = 31,
                    FirstDownCons = 35,
                    PossessionTime = 21,
                    Penalties = 13
                };
                r.FootballStatistics.Add(footballStatistics);
                var playerStatstic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = footballStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };
                r.PlayerGames.Add(playerStatstic);
                await r.CommitSave();

                var sportStastic = await l.GetFootballGameStatistic(playerStatstic.UserID, playerStatstic.GameID);
                Assert.Equal(25, sportStastic.YardsRec);
                Assert.Equal(72, sportStastic.YardsRun);
                Assert.Equal(19, sportStastic.Sacks);
                Assert.Equal(13, sportStastic.Turnovers);
                Assert.Equal(31, sportStastic.Plays);
                Assert.Equal(35, sportStastic.FirstDownCons);
                Assert.Equal(13, sportStastic.Penalties);
                Assert.Equal(21, sportStastic.PossessionTime);
            }
        }

        /// <summary>
        /// Tests the GetGolfGameStatistic() method of Logic
        /// </summary>
        [Fact]
        public async void TestForGetGolfGameStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var golfStatistics = new GolfStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    ScoreToPar = 41,
                    DriveDistance = 312,
                    DriveAccuracy = 75,
                    GIR = 37,
                    PutsperGIR = 15,
                    Eagles = 7,
                    Birdies = 15,
                    Bogeys = 23,
                    SandSaves = 11,
                    Scrambles = 25
                };
                r.GolfStatistics.Add(golfStatistics);
                var playerStatstic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = golfStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };
                r.PlayerGames.Add(playerStatstic);
                await r.CommitSave();

                var sportStastic = await l.GetGolfGameStatistic(playerStatstic.UserID, playerStatstic.GameID);
                Assert.Equal(41, sportStastic.ScoreToPar);
                Assert.Equal(312, sportStastic.DriveDistance);
                Assert.Equal(75, sportStastic.DriveAccuracy);
                Assert.Equal(37, sportStastic.GIR);
                Assert.Equal(15, sportStastic.PutsperGIR);
                Assert.Equal(7, sportStastic.Eagles);
                Assert.Equal(15, sportStastic.Birdies);
                Assert.Equal(23, sportStastic.Bogeys);
                Assert.Equal(11, sportStastic.SandSaves);
                Assert.Equal(25, sportStastic.Scrambles);
            }
        }

        /// <summary>
        /// Tests the GetHockeyGameStatistic() method of Logic
        /// </summary>
        [Fact]
        public async void TestForGetHockeyGameStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var hockeyStatistics = new HockeyStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    Goals = 16,
                    Shots = 51,
                    Hits = 27,
                    FaceOffWins = 7,
                    PowerPlayOpps = 23,
                    PenaltyMins = 45,
                    Blocks = 21,
                    TakeAWays = 12,
                    GiveAways = 19
                };
                r.HockeyStatistics.Add(hockeyStatistics);
                var playerStatstic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = hockeyStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };
                r.PlayerGames.Add(playerStatstic);
                await r.CommitSave();

                var sportStastic = await l.GetHockeyGameStatistic(playerStatstic.UserID, playerStatstic.GameID);
                Assert.Equal(16, sportStastic.Goals);
                Assert.Equal(51, sportStastic.Shots);
                Assert.Equal(27, sportStastic.Hits);
                Assert.Equal(7, sportStastic.FaceOffWins);
                Assert.Equal(23, sportStastic.PowerPlayOpps);
                Assert.Equal(45, sportStastic.PenaltyMins);
                Assert.Equal(21, sportStastic.Blocks);
                Assert.Equal(12, sportStastic.TakeAWays);
                Assert.Equal(19, sportStastic.GiveAways);
            }
        }

        /// <summary>
        /// Tests the GetSoccerGameStatistic() method of Logic
        /// </summary>
        [Fact]
        public async void TestForGetSoccerGameStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var soccerStatistics = new SoccerStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    Goals = 33,
                    ShotOnGoal = 55,
                    Fouls = 73,
                    yellowCards = 47,
                    RedCards = 31,
                    OffSides = 26,
                    CornerKicks = 67,
                    PossessionTime = 44
                };
                r.SoccerStatistics.Add(soccerStatistics);
                var playerStatstic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = soccerStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };
                r.PlayerGames.Add(playerStatstic);
                await r.CommitSave();

                var sportStastic = await l.GetSoccerGameStatistic(playerStatstic.UserID, playerStatstic.GameID);
                Assert.Equal(33, sportStastic.Goals);
                Assert.Equal(55, sportStastic.ShotOnGoal);
                Assert.Equal(73, sportStastic.Fouls);
                Assert.Equal(47, sportStastic.yellowCards);
                Assert.Equal(31, sportStastic.RedCards);
                Assert.Equal(26, sportStastic.OffSides);
                Assert.Equal(67, sportStastic.CornerKicks);
                Assert.Equal(44, sportStastic.PossessionTime);
            }
        }

        /*****************************************************************************************/

        /// <summary>
        /// Tests the GetPlayerOverallBasketballStatistic() method of Logic
        /// TODO: having a list of basketball player statistics won't work because they can't share primary keys
        /// </summary>
        [Fact]
        public async void TestForGetPlayerOverallBasketballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var basketballStatistics = new BasketballStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    FGoals = 12,
                    ThreePts = 8,
                    FThrows = 10,
                    Rebounds = 15,
                    Assists = 23,
                    Steals = 17,
                    Turnovers = 11,
                    Fouls = 7,
                    PossessionTime = 9
                };
                r.BasketballStatistics.Add(basketballStatistics);
                var playerStatstic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = basketballStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };
                r.PlayerGames.Add(playerStatstic);
                await r.CommitSave();

                var sportStastic = await l.GetPlayerOverallBasketballStatistic(playerStatstic.UserID);
                Assert.Equal(12, sportStastic.FGoals);
                Assert.Equal(8, sportStastic.ThreePts);
                Assert.Equal(10, sportStastic.FThrows);
                Assert.Equal(15, sportStastic.Rebounds);
                Assert.Equal(23, sportStastic.Assists);
                Assert.Equal(17, sportStastic.Steals);
                Assert.Equal(11, sportStastic.Turnovers);
                Assert.Equal(7, sportStastic.Fouls);
                Assert.Equal(9, sportStastic.PossessionTime);
            }
        }

        /// <summary>
        /// Tests the GetPlayerOverallBaseballStatistic() method of Logic
        /// TODO: having a list of basketball player statistics won't work because they can't share primary keys
        /// </summary>
        [Fact]
        public async void TestForGetPlayerOverallBaseballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var baseballStatistics = new BaseballStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    BattingAve = 4.7689M,
                    Runs = 17,
                    RBI = 2.3156M,
                    Hits = 13,
                    Steals = 23,
                    ERA = 3.1114M,
                    StrikeOuts = 32,
                    Saves = 25
                };
                r.BaseballStatistics.Add(baseballStatistics);
                var playerStatstic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = baseballStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };
                r.PlayerGames.Add(playerStatstic);
                await r.CommitSave();

                var sportStastic = await l.GetPlayerOverallBaseballStatistic(playerStatstic.UserID);
                Assert.Equal(4.7689M, sportStastic.BattingAve);
                Assert.Equal(17, sportStastic.Runs);
                Assert.Equal(2.3156M, sportStastic.RBI);
                Assert.Equal(13, sportStastic.Hits);
                Assert.Equal(23, sportStastic.Steals);
                Assert.Equal(3.1114M, sportStastic.ERA);
                Assert.Equal(32, sportStastic.StrikeOuts);
                Assert.Equal(25, sportStastic.Saves);
            }
        }

        /// <summary>
        /// Tests the GetPlayerOverallFootballStatistic() method of Logic
        /// TODO: having a list of basketball player statistics won't work because they can't share primary keys
        /// </summary>
        [Fact]
        public async void TestForGetPlayerOverallFoobballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var footballStatistics = new FootBallStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    YardsRec = 25,
                    YardsRun = 72,
                    Sacks = 19,
                    Turnovers = 13,
                    Plays = 31,
                    FirstDownCons = 35,
                    PossessionTime = 21,
                    Penalties = 13
                };
                r.FootballStatistics.Add(footballStatistics);
                var playerStatstic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = footballStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };
                r.PlayerGames.Add(playerStatstic);
                await r.CommitSave();

                var sportStastic = await l.GetPlayerOverallFootballStatistic(playerStatstic.UserID);
                Assert.Equal(25, sportStastic.YardsRec);
                Assert.Equal(72, sportStastic.YardsRun);
                Assert.Equal(19, sportStastic.Sacks);
                Assert.Equal(13, sportStastic.Turnovers);
                Assert.Equal(31, sportStastic.Plays);
                Assert.Equal(35, sportStastic.FirstDownCons);
                Assert.Equal(13, sportStastic.Penalties);
                Assert.Equal(21, sportStastic.PossessionTime);
            }
        }

        /// <summary>
        /// Tests the GetPlayerOverallGolfStatistic() method of Logic
        /// TODO: having a list of basketball player statistics won't work because they can't share primary keys
        /// </summary>
        [Fact]
        public async void TestForGetPlayerOverallGolfStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var golfStatistics = new GolfStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    ScoreToPar = 41,
                    DriveDistance = 312,
                    DriveAccuracy = 75,
                    GIR = 37,
                    PutsperGIR = 15,
                    Eagles = 7,
                    Birdies = 15,
                    Bogeys = 23,
                    SandSaves = 11,
                    Scrambles = 25
                };
                r.GolfStatistics.Add(golfStatistics);
                var playerStatstic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = golfStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };
                r.PlayerGames.Add(playerStatstic);
                await r.CommitSave();

                var sportStastic = await l.GetPlayerOverallGolfStatistic(playerStatstic.UserID);
                Assert.Equal(41, sportStastic.ScoreToPar);
                Assert.Equal(312, sportStastic.DriveDistance);
                Assert.Equal(75, sportStastic.DriveAccuracy);
                Assert.Equal(37, sportStastic.GIR);
                Assert.Equal(15, sportStastic.PutsperGIR);
                Assert.Equal(7, sportStastic.Eagles);
                Assert.Equal(15, sportStastic.Birdies);
                Assert.Equal(23, sportStastic.Bogeys);
                Assert.Equal(11, sportStastic.SandSaves);
                Assert.Equal(25, sportStastic.Scrambles);
            }
        }

        /// <summary>
        /// Tests the GetPlayerOverallHockeyStatistic() method of Logic
        /// TODO: having a list of basketball player statistics won't work because they can't share primary keys
        /// </summary>
        [Fact]
        public async void TestForGetPlayerOverallHockeyStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var hockeyStatistics = new HockeyStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    Goals = 16,
                    Shots = 51,
                    Hits = 27,
                    FaceOffWins = 7,
                    PowerPlayOpps = 23,
                    PenaltyMins = 45,
                    Blocks = 21,
                    TakeAWays = 12,
                    GiveAways = 19
                };
                r.HockeyStatistics.Add(hockeyStatistics);
                var playerStatstic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = hockeyStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };
                r.PlayerGames.Add(playerStatstic);
                await r.CommitSave();

                var sportStastic = await l.GetPlayerOverallHockeyStatistic(playerStatstic.UserID);
                Assert.Equal(16, sportStastic.Goals);
                Assert.Equal(51, sportStastic.Shots);
                Assert.Equal(27, sportStastic.Hits);
                Assert.Equal(7, sportStastic.FaceOffWins);
                Assert.Equal(23, sportStastic.PowerPlayOpps);
                Assert.Equal(45, sportStastic.PenaltyMins);
                Assert.Equal(21, sportStastic.Blocks);
                Assert.Equal(12, sportStastic.TakeAWays);
                Assert.Equal(19, sportStastic.GiveAways);
            }
        }

        /// <summary>
        /// Tests the GetPlayerOverallSoccerStatistic() method of Logic
        /// TODO: having a list of basketball player statistics won't work because they can't share primary keys
        /// </summary>
        [Fact]
        public async void TestForGetPlayerOverallSoccerStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var soccerStatistics = new SoccerStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    Goals = 33,
                    ShotOnGoal = 55,
                    Fouls = 73,
                    yellowCards = 47,
                    RedCards = 31,
                    OffSides = 26,
                    CornerKicks = 67,
                    PossessionTime = 44
                };
                r.SoccerStatistics.Add(soccerStatistics);
                var playerStatstic = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = soccerStatistics.StatLineID,
                    GameID = Guid.NewGuid()
                };
                r.PlayerGames.Add(playerStatstic);
                await r.CommitSave();

                var sportStastic = await l.GetPlayerOverallSoccerStatistic(playerStatstic.UserID);
                Assert.Equal(33, sportStastic.Goals);
                Assert.Equal(55, sportStastic.ShotOnGoal);
                Assert.Equal(73, sportStastic.Fouls);
                Assert.Equal(47, sportStastic.yellowCards);
                Assert.Equal(31, sportStastic.RedCards);
                Assert.Equal(26, sportStastic.OffSides);
                Assert.Equal(67, sportStastic.CornerKicks);
                Assert.Equal(44, sportStastic.PossessionTime);
            }
        }

        /*****************************************************************************************/

        /// <summary>
        /// Tests the UpdateStatistic(basketball) method of Logic
        /// </summary>
        [Fact]
        public async void TestForUpdateBasketballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var basketballStatistics = new BasketballStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    FGoals = 12,
                    ThreePts = 8,
                    FThrows = 10,
                    Rebounds = 15,
                    Assists = 23,
                    Steals = 17,
                    Turnovers = 11,
                    Fouls = 7,
                    PossessionTime = 9
                };
                r.BasketballStatistics.Add(basketballStatistics);
                await r.CommitSave();
                Assert.Equal(12, basketballStatistics.FGoals);
                basketballStatistics.FGoals = 21;
                var sportStastic = await l.UpdateStatistic(basketballStatistics);
                Assert.Equal(21, sportStastic.FGoals);
            }
        }

        /// <summary>
        /// Tests the UpdateStatistic(baseball) method of Logic
        /// </summary>
        [Fact]
        public async void TestForUpdateBaseballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var baseballStatistics = new BaseballStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    BattingAve = 4.7689M,
                    Runs = 17,
                    RBI = 2.3156M,
                    Hits = 13,
                    Steals = 23,
                    ERA = 3.1114M,
                    StrikeOuts = 32,
                    Saves = 25
                };
                r.BaseballStatistics.Add(baseballStatistics);
                await r.CommitSave();
                Assert.Equal(17, baseballStatistics.Runs);
                baseballStatistics.Runs = 31;
                var sportStastic = await l.UpdateStatistic(baseballStatistics);
                Assert.Equal(31, sportStastic.Runs);
            }
        }

        /// <summary>
        /// Tests the UpdateStatistic(football) method of Logic
        /// </summary>
        [Fact]
        public async void TestForUpdateFootballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var footballStatistics = new FootBallStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    YardsRec = 25,
                    YardsRun = 72,
                    Sacks = 19,
                    Turnovers = 13,
                    Plays = 31,
                    FirstDownCons = 35,
                    PossessionTime = 21,
                    Penalties = 13
                };
                r.FootballStatistics.Add(footballStatistics);
                await r.CommitSave();
                Assert.Equal(25, footballStatistics.YardsRec);
                footballStatistics.YardsRec = 41;
                var sportStastic = await l.UpdateStatistic(footballStatistics);
                Assert.Equal(41, sportStastic.YardsRec);
            }
        }

        /// <summary>
        /// Tests the UpdateStatistic(golf) method of Logic
        /// </summary>
        [Fact]
        public async void TestForUpdateGolfStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var golfStatistics = new GolfStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    ScoreToPar = 41,
                    DriveDistance = 312,
                    DriveAccuracy = 75,
                    GIR = 37,
                    PutsperGIR = 15,
                    Eagles = 7,
                    Birdies = 15,
                    Bogeys = 23,
                    SandSaves = 11,
                    Scrambles = 25
                };
                r.GolfStatistics.Add(golfStatistics);
                await r.CommitSave();
                Assert.Equal(41, golfStatistics.ScoreToPar);
                golfStatistics.ScoreToPar = 55;
                var sportStastic = await l.UpdateStatistic(golfStatistics);
                Assert.Equal(55, sportStastic.ScoreToPar);
            }
        }

        /// <summary>
        /// Tests the UpdateStatistic(hockey) method of Logic
        /// </summary>
        [Fact]
        public async void TestForUpdateHockeyStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var hockeyStatistics = new HockeyStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    Goals = 16,
                    Shots = 51,
                    Hits = 27,
                    FaceOffWins = 7,
                    PowerPlayOpps = 23,
                    PenaltyMins = 45,
                    Blocks = 21,
                    TakeAWays = 12,
                    GiveAways = 19
                };
                r.HockeyStatistics.Add(hockeyStatistics);
                await r.CommitSave();
                Assert.Equal(16, hockeyStatistics.Goals);
                hockeyStatistics.Goals = 24;
                var sportStastic = await l.UpdateStatistic(hockeyStatistics);
                Assert.Equal(24, sportStastic.Goals);
            }
        }

        /// <summary>
        /// Tests the UpdateStatistic(soccer) method of Logic
        /// </summary>
        [Fact]
        public async void TestForUpdateSoccerStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var soccerStatistics = new SoccerStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    Goals = 33,
                    ShotOnGoal = 55,
                    Fouls = 73,
                    yellowCards = 47,
                    RedCards = 31,
                    OffSides = 26,
                    CornerKicks = 67,
                    PossessionTime = 44
                };
                r.SoccerStatistics.Add(soccerStatistics);
                await r.CommitSave();
                Assert.Equal(33, soccerStatistics.Goals);
                soccerStatistics.Goals = 41;
                var sportStastic = await l.UpdateStatistic(soccerStatistics);
                Assert.Equal(41, sportStastic.Goals);
            }
        }

        /*****************************************************************************************/

        /// <summary>
        /// Tests the DeleteStatistic(basketball) method of Logic
        /// </summary>
        [Fact]
        public async void TestForDeleteBasketballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var basketballStatistics = new BasketballStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    FGoals = 12,
                    ThreePts = 8,
                    FThrows = 10,
                    Rebounds = 15,
                    Assists = 23,
                    Steals = 17,
                    Turnovers = 11,
                    Fouls = 7,
                    PossessionTime = 9
                };
                r.BasketballStatistics.Add(basketballStatistics);
                await r.CommitSave();
                Assert.NotEmpty(context.BasketballStatistics);
                await l.DeleteStatistic(basketballStatistics);
                var returnNull = await context.BasketballStatistics.FindAsync(basketballStatistics.StatLineID);
                Assert.Null(returnNull);
            }
        }

        /// <summary>
        /// Tests the DeleteStatistic(baseball) method of Logic
        /// </summary>
        [Fact]
        public async void TestForDeleteBaseballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var baseballStatistics = new BaseballStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    BattingAve = 4.7689M,
                    Runs = 17,
                    RBI = 2.3156M,
                    Hits = 13,
                    Steals = 23,
                    ERA = 3.1114M,
                    StrikeOuts = 32,
                    Saves = 25
                };
                r.BaseballStatistics.Add(baseballStatistics);
                await r.CommitSave();
                Assert.NotEmpty(context.BaseballStatistics);
                await l.DeleteStatistic(baseballStatistics);
                var returnNull = await context.BaseballStatistics.FindAsync(baseballStatistics.StatLineID);
                Assert.Null(returnNull);
            }
        }

        /// <summary>
        /// Tests the DeleteStatistic(football) method of Logic
        /// </summary>
        [Fact]
        public async void TestForDeleteFootballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var footballStatistics = new FootBallStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    YardsRec = 25,
                    YardsRun = 72,
                    Sacks = 19,
                    Turnovers = 13,
                    Plays = 31,
                    FirstDownCons = 35,
                    PossessionTime = 21,
                    Penalties = 13
                };
                r.FootballStatistics.Add(footballStatistics);
                await r.CommitSave();
                Assert.NotEmpty(context.FootballStatistics);
                await l.DeleteStatistic(footballStatistics);
                var returnNull = await context.FootballStatistics.FindAsync(footballStatistics.StatLineID);
                Assert.Null(returnNull);
            }
        }

        /// <summary>
        /// Tests the DeleteStatistic(golf) method of Logic
        /// </summary>
        [Fact]
        public async void TestForDeleteGolfStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var golfStatistics = new GolfStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    ScoreToPar = 41,
                    DriveDistance = 312,
                    DriveAccuracy = 75,
                    GIR = 37,
                    PutsperGIR = 15,
                    Eagles = 7,
                    Birdies = 15,
                    Bogeys = 23,
                    SandSaves = 11,
                    Scrambles = 25
                };
                r.GolfStatistics.Add(golfStatistics);
                await r.CommitSave();
                Assert.NotEmpty(context.GolfStatistics);
                await l.DeleteStatistic(golfStatistics);
                var returnNull = await context.GolfStatistics.FindAsync(golfStatistics.StatLineID);
                Assert.Null(returnNull);
            }
        }

        /// <summary>
        /// Tests the DeleteStatistic(hockey) method of Logic
        /// </summary>
        [Fact]
        public async void TestForDeleteHockeyStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var hockeyStatistics = new HockeyStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    Goals = 16,
                    Shots = 51,
                    Hits = 27,
                    FaceOffWins = 7,
                    PowerPlayOpps = 23,
                    PenaltyMins = 45,
                    Blocks = 21,
                    TakeAWays = 12,
                    GiveAways = 19
                };
                r.HockeyStatistics.Add(hockeyStatistics);
                await r.CommitSave();
                Assert.NotEmpty(context.HockeyStatistics);
                await l.DeleteStatistic(hockeyStatistics);
                var returnNull = await context.GolfStatistics.FindAsync(hockeyStatistics.StatLineID);
                Assert.Null(returnNull);
            }
        }

        /// <summary>
        /// Tests the DeleteStatistic(soccer) method of Logic
        /// </summary>
        [Fact]
        public async void TestForDeleteSoccerStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                var soccerStatistics = new SoccerStatistic()
                {
                    StatLineID = Guid.NewGuid(),
                    Goals = 33,
                    ShotOnGoal = 55,
                    Fouls = 73,
                    yellowCards = 47,
                    RedCards = 31,
                    OffSides = 26,
                    CornerKicks = 67,
                    PossessionTime = 44
                };
                r.SoccerStatistics.Add(soccerStatistics);
                await r.CommitSave();
                Assert.NotEmpty(context.SoccerStatistics);
                await l.DeleteStatistic(soccerStatistics);
                var returnNull = await context.SoccerStatistics.FindAsync(soccerStatistics.StatLineID);
                Assert.Null(returnNull);
            }
        }
    }
}
