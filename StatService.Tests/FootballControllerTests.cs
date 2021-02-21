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
    public class FootballControllerTests
    {
        /// <summary>
        /// Tests the GetFootballStatistics() method of FootballController
        /// </summary>
        [Fact]
        public async void TestForGetFootballStatistics()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetFootballStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                FootBallStatisticsController controller = new FootBallStatisticsController(context);
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

                var sportStatisticList = await controller.GetFootballStatistics();
                var convertStatisticList = (List<FootBallStatistic>)sportStatisticList.Value;
                Assert.Contains<FootBallStatistic>(convertStatisticList[0], context.FootballStatistics);
            }
        }

        /// <summary>
        /// Tests the GetFootballStatistic(id) method of FootballController
        /// </summary>
        [Fact]
        public async void TestForGetFootballStatisticById()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                FootBallStatisticsController controller = new FootBallStatisticsController(context);
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

                var sportStatistic = await controller.GetFootBallStatistic(Guid.NewGuid());
                Assert.IsAssignableFrom<NotFoundResult>((sportStatistic.Result as NotFoundResult));
                var sportStatistic2 = await controller.GetFootBallStatistic(footballStatistics.StatLineID);
                Assert.True(sportStatistic2.Value.Sacks.Equals(19));
            }
        }

        /// <summary>
        /// Tests the PutFootballStatistic() method of FootballController
        /// </summary>
        [Fact]
        public async void TestForPutFootballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                FootBallStatisticsController controller = new FootBallStatisticsController(context);
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
                var footballStatistics2 = new FootBallStatistic()
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

                var sportStatistic = await controller.PutFootBallStatistic(footballStatistics.StatLineID, footballStatistics2);
                Assert.IsAssignableFrom<BadRequestResult>((sportStatistic as BadRequestResult));

                var sportStatistic2 = await controller.PutFootBallStatistic(footballStatistics.StatLineID, footballStatistics);
                Assert.IsAssignableFrom<NotFoundResult>((sportStatistic2 as NotFoundResult));

                r.FootballStatistics.Add(footballStatistics);
                await r.CommitSave();

                var sportStatistic3 = await controller.PutFootBallStatistic(footballStatistics.StatLineID, footballStatistics);
                Assert.IsAssignableFrom<NoContentResult>((sportStatistic3 as NoContentResult));
            }
        }

        /// <summary>
        /// Tests the PostFootballStatistic() method of FootballController
        /// </summary>
        [Fact]
        public async void TestForPostFootballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                FootBallStatisticsController controller = new FootBallStatisticsController(context);
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

                var sportStatistic = await controller.PostFootBallStatistic(footballStatistics);
                Assert.IsAssignableFrom<CreatedAtActionResult>(sportStatistic.Result as CreatedAtActionResult);
            }
        }

        /// <summary>
        /// Tests the DeleteFootballStatistic() method of FootballController
        /// </summary>
        [Fact]
        public async void TestForDeleteFootballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3FootballController")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                FootBallStatisticsController controller = new FootBallStatisticsController(context);
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

                var sportStatistic = await controller.DeleteFootBallStatistic(Guid.NewGuid());
                Assert.IsAssignableFrom<NotFoundResult>(sportStatistic as NotFoundResult);
                var sportStatistic2 = await controller.DeleteFootBallStatistic(footballStatistics.StatLineID);
                Assert.IsAssignableFrom<NoContentResult>(sportStatistic2 as NoContentResult);
            }
        }
    }
}
