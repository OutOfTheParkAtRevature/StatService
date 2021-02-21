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
    public class GolfControllerTests
    {
        /// <summary>
        /// Tests the GetGolfStatistics() method of GolfController
        /// </summary>
        [Fact]
        public async void TestForGetGolfStatistics()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetGolfStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                GolfStatisticsController controller = new GolfStatisticsController(context);
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

                var sportStatisticList = await controller.GetGolfStatistics();
                var convertStatisticList = (List<GolfStatistic>)sportStatisticList.Value;
                Assert.Contains<GolfStatistic>(convertStatisticList[0], context.GolfStatistics);
            }
        }

        /// <summary>
        /// Tests the GetGolfStatistic(id) method of GolfController
        /// </summary>
        [Fact]
        public async void TestForGetGolfStatisticById()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetGolfStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                GolfStatisticsController controller = new GolfStatisticsController(context);
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

                var sportStatistic = await controller.GetGolfStatistic(Guid.NewGuid());
                Assert.IsAssignableFrom<NotFoundResult>((sportStatistic.Result as NotFoundResult));
                var sportStatistic2 = await controller.GetGolfStatistic(golfStatistics.StatLineID);
                Assert.True(sportStatistic2.Value.Eagles.Equals(7));
            }
        }

        /// <summary>
        /// Tests the PutGolfStatistic() method of GolfController
        /// </summary>
        [Fact]
        public async void TestForPutGolfStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetGolfStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                GolfStatisticsController controller = new GolfStatisticsController(context);
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
                var golfStatistics2 = new GolfStatistic()
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

                var sportStatistic = await controller.PutGolfStatistic(golfStatistics.StatLineID, golfStatistics2);
                Assert.IsAssignableFrom<BadRequestResult>((sportStatistic as BadRequestResult));

                var sportStatistic2 = await controller.PutGolfStatistic(golfStatistics.StatLineID, golfStatistics);
                Assert.IsAssignableFrom<NotFoundResult>((sportStatistic2 as NotFoundResult));

                r.GolfStatistics.Add(golfStatistics);
                await r.CommitSave();

                var sportStatistic3 = await controller.PutGolfStatistic(golfStatistics.StatLineID, golfStatistics);
                Assert.IsAssignableFrom<NoContentResult>((sportStatistic3 as NoContentResult));
            }
        }

        /// <summary>
        /// Tests the PostGolfStatistic() method of GolfController
        /// </summary>
        [Fact]
        public async void TestForPostGolfStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetGolfStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                GolfStatisticsController controller = new GolfStatisticsController(context);
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

                var sportStatistic = await controller.PostGolfStatistic(golfStatistics);
                Assert.IsAssignableFrom<CreatedAtActionResult>(sportStatistic.Result as CreatedAtActionResult);
            }
        }

        /// <summary>
        /// Tests the DeleteGolfStatistic() method of GolfController
        /// </summary>
        [Fact]
        public async void TestForDeleteGolfStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3DeleteGolfStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                GolfStatisticsController controller = new GolfStatisticsController(context);
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

                var sportStatistic = await controller.DeleteGolfStatistic(Guid.NewGuid());
                Assert.IsAssignableFrom<NotFoundResult>(sportStatistic as NotFoundResult);
                var sportStatistic2 = await controller.DeleteGolfStatistic(golfStatistics.StatLineID);
                Assert.IsAssignableFrom<NoContentResult>(sportStatistic2 as NoContentResult);
            }
        }
    }
}
