using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace Repository.Tests
{
    public class RepoTests {

        /// <summary>
        /// Tests the CommitSave() method of Repo
        /// </summary>
        [Fact]
        public async void TestForCommitSave()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
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
            }
        }

        /// <summary>
        /// Tests the CreateStatistic(basketball) method of Repo
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

                var sportStastic = await r.CreateStatistic(basketballStatistics);
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
        /// Tests the CreateStatistic(baseball) method of Repo
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

                var sportStastic = await r.CreateStatistic(baseballStatistics);
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
        /// Tests the CreateStatistic(football) method of Repo
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

                var sportStastic = await r.CreateStatistic(footballStatistics);
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
        /// Tests the CreateStatistic(golf) method of Repo
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

                var sportStastic = await r.CreateStatistic(golfStatistics);
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
        /// Tests the CreateStatistic(hockey) method of Repo
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

                var sportStastic = await r.CreateStatistic(hockeyStatistics);
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
        /// Tests the CreateStatistic(soccer) method of Repo
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

                var sportStastic = await r.CreateStatistic(soccerStatistics);
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
        /// Tests the GetBasketballStatisticsById() method of Repo
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

                var sportStastic = await r.GetBasketballStatisticsById(basketballStatistics.StatLineID);
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
        /// Tests the GetBaseballStatisticsById() method of Repo
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

                var sportStastic = await r.GetBaseballStatisticsById(baseballStatistics.StatLineID);
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
        /// Tests the GetFootballStatisticsById() method of Repo
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

                var sportStastic = await r.GetFootballStatisticsById(footballStatistics.StatLineID);
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
        /// Tests the GetGolfStatisticsById() method of Repo
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

                var sportStastic = await r.GetGolfStatisticsById(golfStatistics.StatLineID);
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
        /// Tests the GetHockeyStatisticsById() method of Repo
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

                var sportStastic = await r.GetHockeyStatisticsById(hockeyStatistics.StatLineID);
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
        /// Tests the GetSoccerStatisticsById() method of Repo
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

                var sportStastic = await r.GetSoccerStatisticsById(soccerStatistics.StatLineID);
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
        /// Tests the GetBasketballStatistics() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetBasketballStatistics()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
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

                var sportStasticList = await r.GetBasketballStatistic();
                var convertStasticList = (List<BasketballStatistic>)sportStasticList;
                Assert.Contains<BasketballStatistic>(convertStasticList[0], context.BasketballStatistics);
            }
        }

        /// <summary>
        /// Tests the GetBaseballStatistics() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetBaseballStatistics()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
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

                var sportStasticList = await r.GetBaseballStatistic();
                var convertStasticList = (List<BaseballStatistic>)sportStasticList;
                Assert.Contains<BaseballStatistic>(convertStasticList[0], context.BaseballStatistics);
            }
        }

        /// <summary>
        /// Tests the GetFootballStatistics() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetFootballStatistics()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
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

                var sportStasticList = await r.GetFootBallStatistic();
                var convertStasticList = (List<FootBallStatistic>)sportStasticList;
                Assert.Contains<FootBallStatistic>(convertStasticList[0], context.FootballStatistics);
            }
        }

        /// <summary>
        /// Tests the GetGolfStatistics() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetGolfStatistics()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
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

                var sportStasticList = await r.GetGolfStatistic();
                var convertStasticList = (List<GolfStatistic>)sportStasticList;
                Assert.Contains<GolfStatistic>(convertStasticList[0], context.GolfStatistics);
            }
        }

        /// <summary>
        /// Tests the GetHockeyStatistics() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetHockeyStatistics()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
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

                var sportStasticList = await r.GetHockeyStatistic();
                var convertStasticList = (List<HockeyStatistic>)sportStasticList;
                Assert.Contains<HockeyStatistic>(convertStasticList[0], context.HockeyStatistics);
            }
        }

        /// <summary>
        /// Tests the GetSoccerStatistics() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetSoccerStatistics()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
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

                var sportStasticList = await r.GetSoccerStatistic();
                var convertStasticList = (List<SoccerStatistic>)sportStasticList;
                Assert.Contains<SoccerStatistic>(convertStasticList[0], context.SoccerStatistics);
            }
        }

        /*****************************************************************************************/

        /// <summary>
        /// Tests the GetBasketballGameStatistic() method of Repo
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

                var sportStastic = await r.GetBasketballGameStatistic(playerStatstic.UserID, playerStatstic.GameID);
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
        /// Tests the GetBaseballGameStatistic() method of Repo
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

                var sportStastic = await r.GetBaseballGameStatistic(playerStatstic.UserID, playerStatstic.GameID);
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
        /// Tests the GetFootballGameStatistic() method of Repo
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

                var sportStastic = await r.GetFootballGameStatistic(playerStatstic.UserID, playerStatstic.GameID);
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
        /// Tests the GetGolfGameStatistic() method of Repo
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

                var sportStastic = await r.GetGolfGameStatistic(playerStatstic.UserID, playerStatstic.GameID);
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
        /// Tests the GetHockeyGameStatistic() method of Repo
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

                var sportStastic = await r.GetHockeyGameStatistic(playerStatstic.UserID, playerStatstic.GameID);
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
        /// Tests the GetSoccerGameStatistic() method of Repo
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

                var sportStastic = await r.GetSoccerGameStatistic(playerStatstic.UserID, playerStatstic.GameID);
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
        /// Tests the GetBasketballStatisticByPlayerId() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetBasketballStatisticByPlayerId()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
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

                var sportStasticList = await r.GetBasketballStatisticByPlayerId(playerStatstic.UserID);
                var convertStasticList = (List<BasketballStatistic>)sportStasticList;
                Assert.Contains<BasketballStatistic>(convertStasticList[0], context.BasketballStatistics);
            }
        }

        /// <summary>
        /// Tests the GetBaseballStatisticByPlayerId() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetBaseballStatisticByPlayerId()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
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

                var sportStasticList = await r.GetBaseballStatisticByPlayerId(playerStatstic.UserID);
                var convertStasticList = (List<BaseballStatistic>)sportStasticList;
                Assert.Contains<BaseballStatistic>(convertStasticList[0], context.BaseballStatistics);
            }
        }


        /// <summary>
        /// Tests the GetFootballStatisticByPlayerId() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetFootballStatisticByPlayerId()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
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

                var sportStasticList = await r.GetFootballStatisticByPlayerId(playerStatstic.UserID);
                var convertStasticList = (List<FootBallStatistic>)sportStasticList;
                Assert.Contains<FootBallStatistic>(convertStasticList[0], context.FootballStatistics);
            }
        }

        /// <summary>
        /// Tests the GetGolfStatisticByPlayerId() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetGolfStatisticByPlayerId()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
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

                var sportStasticList = await r.GetGolfStatisticByPlayerId(playerStatstic.UserID);
                var convertStasticList = (List<GolfStatistic>)sportStasticList;
                Assert.Contains<GolfStatistic>(convertStasticList[0], context.GolfStatistics);
            }
        }

        /// <summary>
        /// Tests the GetHockeyStatisticByPlayerId() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetHockeyStatisticByPlayerId()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
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

                var sportStasticList = await r.GetHockeyStatisticByPlayerId(playerStatstic.UserID);
                var convertStasticList = (List<HockeyStatistic>)sportStasticList;
                Assert.Contains<HockeyStatistic>(convertStasticList[0], context.HockeyStatistics);
            }
        }

        /// <summary>
        /// Tests the GetSoccerStatisticByPlayerId() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetSoccerStatisticByPlayerId()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
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

                var sportStasticList = await r.GetSoccerStatisticByPlayerId(playerStatstic.UserID);
                var convertStasticList = (List<SoccerStatistic>)sportStasticList;
                Assert.Contains<SoccerStatistic>(convertStasticList[0], context.SoccerStatistics);
            }
        }

        /*****************************************************************************************/

        /// <summary>
        /// Tests the UpdateStatistic(basketball) method of Repo
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
                var sportStastic = await r.UpdateStatistic(basketballStatistics);
                Assert.Equal(21, sportStastic.FGoals);     
            }
        }

        /// <summary>
        /// Tests the UpdateStatistic(baseball) method of Repo
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
                var sportStastic = await r.UpdateStatistic(baseballStatistics);
                Assert.Equal(31, sportStastic.Runs);
            }
        }

        /// <summary>
        /// Tests the UpdateStatistic(football) method of Repo
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
                var sportStastic = await r.UpdateStatistic(footballStatistics);
                Assert.Equal(41, sportStastic.YardsRec);
            }
        }

        /// <summary>
        /// Tests the UpdateStatistic(golf) method of Repo
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
                var sportStastic = await r.UpdateStatistic(golfStatistics);
                Assert.Equal(55, sportStastic.ScoreToPar);
            }
        }

        /// <summary>
        /// Tests the UpdateStatistic(hockey) method of Repo
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
                var sportStastic = await r.UpdateStatistic(hockeyStatistics);
                Assert.Equal(24, sportStastic.Goals);
            }
        }

        /// <summary>
        /// Tests the UpdateStatistic(soccer) method of Repo
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
                var sportStastic = await r.UpdateStatistic(soccerStatistics);
                Assert.Equal(41, sportStastic.Goals);
            }
        }

        /*****************************************************************************************/

        /// <summary>
        /// Tests the DeleteStatistic(basketball) method of Repo
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
                await r.DeleteStatistic(basketballStatistics);
                var returnNull = await context.BasketballStatistics.FindAsync(basketballStatistics.StatLineID);
                Assert.Null(returnNull);
            }
        }

        /// <summary>
        /// Tests the DeleteStatistic(baseball) method of Repo
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
                await r.DeleteStatistic(baseballStatistics);
                var returnNull = await context.BaseballStatistics.FindAsync(baseballStatistics.StatLineID);
                Assert.Null(returnNull);
            }
        }

        /// <summary>
        /// Tests the DeleteStatistic(football) method of Repo
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
                await r.DeleteStatistic(footballStatistics);
                var returnNull = await context.FootballStatistics.FindAsync(footballStatistics.StatLineID);
                Assert.Null(returnNull);
            }
        }

        /// <summary>
        /// Tests the DeleteStatistic(golf) method of Repo
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
                await r.DeleteStatistic(golfStatistics);
                var returnNull = await context.GolfStatistics.FindAsync(golfStatistics.StatLineID);
                Assert.Null(returnNull);
            }
        }

        /// <summary>
        /// Tests the DeleteStatistic(hockey) method of Repo
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
                await r.DeleteStatistic(hockeyStatistics);
                var returnNull = await context.GolfStatistics.FindAsync(hockeyStatistics.StatLineID);
                Assert.Null(returnNull);
            }
        }

        /// <summary>
        /// Tests the DeleteStatistic(soccer) method of Repo
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
                await r.DeleteStatistic(soccerStatistics);
                var returnNull = await context.SoccerStatistics.FindAsync(soccerStatistics.StatLineID);
                Assert.Null(returnNull);
            }
        }

    }
}
