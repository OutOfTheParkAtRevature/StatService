using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Models;
using Repository;
using Service;
using StatService.Controllers;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace StatService.Tests
{
    public class BaseballControllerTests {

        /// <summary>
        /// Tests the GetBaseballStatistics() method of BaseballController
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
                Logic l = new Logic(r, new NullLogger<Repo>());
                BaseballStatisticsController controller = new BaseballStatisticsController(context, l);
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

                var sportStasticList = await controller.GetBaseballStatistics();
                var convertStasticList = (List<BaseballStatistic>)sportStasticList.Value;
                Assert.Contains<BaseballStatistic>(convertStasticList[0], context.BaseballStatistics);
            }
        }

        /// <summary>
        /// Tests the GetBaseballStatistic(id) method of BaseballController
        /// </summary>
        [Fact]
        public async void TestForGetBaseballStatisticById()
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
                BaseballStatisticsController controller = new BaseballStatisticsController(context, l);
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

                var sportStastic = await controller.GetBaseballStatistic(baseballStatistics.StatLineID);
                Assert.Equal(4.7689M, sportStastic.Value.BattingAve);
                Assert.Equal(17, sportStastic.Value.Runs);
                Assert.Equal(2.3156M, sportStastic.Value.RBI);
                Assert.Equal(13, sportStastic.Value.Hits);
                Assert.Equal(23, sportStastic.Value.Steals);
                Assert.Equal(3.1114M, sportStastic.Value.ERA);
                Assert.Equal(32, sportStastic.Value.StrikeOuts);
                Assert.Equal(25, sportStastic.Value.Saves);
            }
        }

        /// <summary>
        /// Tests the GetBaseballStatistic(userId, gameId) method of BaseballController
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
                BaseballStatisticsController controller = new BaseballStatisticsController(context, l);
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

                var sportStastic = await controller.GetBaseballGameStatistic(playerStatstic.UserID, playerStatstic.GameID);
                Assert.Equal(4.7689M, sportStastic.Value.BattingAve);
                Assert.Equal(17, sportStastic.Value.Runs);
                Assert.Equal(2.3156M, sportStastic.Value.RBI);
                Assert.Equal(13, sportStastic.Value.Hits);
                Assert.Equal(23, sportStastic.Value.Steals);
                Assert.Equal(3.1114M, sportStastic.Value.ERA);
                Assert.Equal(32, sportStastic.Value.StrikeOuts);
                Assert.Equal(25, sportStastic.Value.Saves);
            }
        }
    }
}
