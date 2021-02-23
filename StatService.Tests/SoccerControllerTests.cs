using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Models;
using Repository;
using StatService.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace StatService.Tests
{
    public class SoccerControllerTests
    {
        /// <summary>
        /// Tests the GetSoccerStatistics() method of SoccerController
        /// </summary>
        [Fact]
        public async void TestForGetSoccerStatistics()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetSoccerStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                SoccerStatisticsController controller = new SoccerStatisticsController(context);
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

                var sportStatisticList = await controller.GetSoccerStatistics();
                var convertStatisticList = (List<SoccerStatistic>)sportStatisticList.Value;
                Assert.Contains<SoccerStatistic>(convertStatisticList[0], context.SoccerStatistics);
            }
        }

        /// <summary>
        /// Tests the GetSoccerStatistic(id) method of SoccerController
        /// </summary>
        [Fact]
        public async void TestForGetSoccerStatisticById()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetSoccerStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                SoccerStatisticsController controller = new SoccerStatisticsController(context);
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

                var sportStatistic = await controller.GetSoccerStatistic(Guid.NewGuid());
                Assert.IsAssignableFrom<NotFoundResult>((sportStatistic.Result as NotFoundResult));
                var sportStatistic2 = await controller.GetSoccerStatistic(soccerStatistics.StatLineID);
                Assert.True(sportStatistic2.Value.Fouls.Equals(73));
            }
        }

        /// <summary>
        /// Tests the PutSoccerStatistic() method of SoccerController
        /// </summary>
        [Fact]
        public async void TestForPutSoccerStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetSoccerStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                SoccerStatisticsController controller = new SoccerStatisticsController(context);
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
                var soccerStatistics2 = new SoccerStatistic()
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

                var sportStatistic = await controller.PutSoccerStatistic(soccerStatistics.StatLineID, soccerStatistics2);
                Assert.IsAssignableFrom<BadRequestResult>((sportStatistic as BadRequestResult));

                var sportStatistic2 = await controller.PutSoccerStatistic(soccerStatistics.StatLineID, soccerStatistics);
                Assert.IsAssignableFrom<NotFoundResult>((sportStatistic2 as NotFoundResult));

                r.SoccerStatistics.Add(soccerStatistics);
                await r.CommitSave();

                var sportStatistic3 = await controller.PutSoccerStatistic(soccerStatistics.StatLineID, soccerStatistics);
                Assert.IsAssignableFrom<NoContentResult>((sportStatistic3 as NoContentResult));
            }
        }

        /// <summary>
        /// Tests the PostSoccerStatistic() method of SoccerController
        /// </summary>
        [Fact]
        public async void TestForPostSoccerStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetSoccerStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                SoccerStatisticsController controller = new SoccerStatisticsController(context);
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

                var sportStatistic = await controller.PostSoccerStatistic(soccerStatistics);
                Assert.IsAssignableFrom<CreatedAtActionResult>(sportStatistic.Result as CreatedAtActionResult);
            }
        }

        /// <summary>
        /// Tests the DeleteSoccerStatistic() method of SoccerController
        /// </summary>
        [Fact]
        public async void TestForDeleteSoccerStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3DeleteSoccerStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                SoccerStatisticsController controller = new SoccerStatisticsController(context);
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

                var sportStatistic = await controller.DeleteSoccerStatistic(Guid.NewGuid());
                Assert.IsAssignableFrom<NotFoundResult>(sportStatistic as NotFoundResult);
                var sportStatistic2 = await controller.DeleteSoccerStatistic(soccerStatistics.StatLineID);
                Assert.IsAssignableFrom<NoContentResult>(sportStatistic2 as NoContentResult);
            }
        }
    }
}
