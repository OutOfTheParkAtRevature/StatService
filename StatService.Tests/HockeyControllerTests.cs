using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Models;
using Repository;
using StatService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StatService.Tests
{
    public class HockeyControllerTests
    {
        /// <summary>
        /// Tests the GetHockeyStatistics() method of HockeyController
        /// </summary>
        [Fact]
        public async void TestForGetHockeyStatistics()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetHockeyStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                HockeyStatisticsController controller = new HockeyStatisticsController(context);
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

                var sportStatisticList = await controller.GetHockeyStatistics();
                var convertStatisticList = (List<HockeyStatistic>)sportStatisticList.Value;
                Assert.Contains<HockeyStatistic>(convertStatisticList[0], context.HockeyStatistics);
            }
        }

        /// <summary>
        /// Tests the GetHockeyStatistic(id) method of HockeyController
        /// </summary>
        [Fact]
        public async void TestForGetHockeyStatisticById()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetHockeyStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                HockeyStatisticsController controller = new HockeyStatisticsController(context);
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

                var sportStatistic = await controller.GetHockeyStatistic(Guid.NewGuid());
                Assert.IsAssignableFrom<NotFoundResult>((sportStatistic.Result as NotFoundResult));
                var sportStatistic2 = await controller.GetHockeyStatistic(hockeyStatistics.StatLineID);
                Assert.True(sportStatistic2.Value.Hits.Equals(27));
            }
        }

        /// <summary>
        /// Tests the PutHockeyStatistic() method of HockeyController
        /// </summary>
        [Fact]
        public async void TestForPutHockeyStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetHockeyStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                HockeyStatisticsController controller = new HockeyStatisticsController(context);
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
                var hockeyStatistics2 = new HockeyStatistic()
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

                var sportStatistic = await controller.PutHockeyStatistic(hockeyStatistics.StatLineID, hockeyStatistics2);
                Assert.IsAssignableFrom<BadRequestResult>((sportStatistic as BadRequestResult));

                var sportStatistic2 = await controller.PutHockeyStatistic(hockeyStatistics.StatLineID, hockeyStatistics);
                Assert.IsAssignableFrom<NotFoundResult>((sportStatistic2 as NotFoundResult));

                r.HockeyStatistics.Add(hockeyStatistics);
                await r.CommitSave();

                var sportStatistic3 = await controller.PutHockeyStatistic(hockeyStatistics.StatLineID, hockeyStatistics);
                Assert.IsAssignableFrom<NoContentResult>((sportStatistic3 as NoContentResult));
            }
        }

        /// <summary>
        /// Tests the PostHockeyStatistic() method of HockeyController
        /// </summary>
        [Fact]
        public async void TestForPostHockeyStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetHockeyStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                HockeyStatisticsController controller = new HockeyStatisticsController(context);
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

                var sportStatistic = await controller.PostHockeyStatistic(hockeyStatistics);
                Assert.IsAssignableFrom<CreatedAtActionResult>(sportStatistic.Result as CreatedAtActionResult);
            }
        }

        /// <summary>
        /// Tests the DeleteHockeyStatistic() method of HockeyController
        /// </summary>
        [Fact]
        public async void TestForDeleteHockeyStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3DeleteHockeyStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                HockeyStatisticsController controller = new HockeyStatisticsController(context);
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

                var sportStatistic = await controller.DeleteHockeyStatistic(Guid.NewGuid());
                Assert.IsAssignableFrom<NotFoundResult>(sportStatistic as NotFoundResult);
                var sportStatistic2 = await controller.DeleteHockeyStatistic(hockeyStatistics.StatLineID);
                Assert.IsAssignableFrom<NoContentResult>(sportStatistic2 as NoContentResult);
            }
        }
    }
}
