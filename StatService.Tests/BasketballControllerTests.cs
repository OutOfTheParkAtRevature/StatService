using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Models;
using Repository;
using Service;
using StatService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StatService.Tests
{
    public class BasketballControllerTests
    {
        /// <summary>
        /// Tests the GetBasketballStatistics() method of BasketballController
        /// </summary>
        [Fact]
        public async void TestForGetBasketballStatistics()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetBasketballStatistics")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                BasketballStatisticsController controller = new BasketballStatisticsController(context);
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

                var sportStatisticList = await controller.GetBasketballStatistics();
                var convertStatisticList = (List<BasketballStatistic>)sportStatisticList.Value;
                Assert.Contains<BasketballStatistic>(convertStatisticList[0], context.BasketballStatistics);
            }
        }

        /// <summary>
        /// Tests the GetBasketballStatisticById() method of BasketballController
        /// </summary>
        [Fact]
        public async void TestForGetBasketballStatisticById()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                BasketballStatisticsController controller = new BasketballStatisticsController(context);
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

                var sportStatistic = await controller.GetBasketballStatistic(Guid.NewGuid());
                Assert.IsAssignableFrom<NotFoundResult>((sportStatistic.Result as NotFoundResult));
                var sportStatistic2 = await controller.GetBasketballStatistic(basketballStatistics.StatLineID);
                Assert.True(sportStatistic2.Value.Fouls.Equals(7));
            }
        }

        /// <summary>
        /// Tests the PutBasketballStatistic() method of BasketballController
        /// </summary>
        [Fact]
        public async void TestForPutBasketballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                BasketballStatisticsController controller = new BasketballStatisticsController(context);
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
                var basketballStatistics2 = new BasketballStatistic()
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
                var sportStatistic = await controller.PutBasketballStatistic(basketballStatistics.StatLineID, basketballStatistics2);
                Assert.IsAssignableFrom<BadRequestResult>((sportStatistic as BadRequestResult));

                var sportStatistic2 = await controller.PutBasketballStatistic(basketballStatistics.StatLineID, basketballStatistics);
                Assert.IsAssignableFrom<NotFoundResult>((sportStatistic2 as NotFoundResult));

                r.BasketballStatistics.Add(basketballStatistics);
                await r.CommitSave();

                var sportStatistic3 = await controller.PutBasketballStatistic(basketballStatistics.StatLineID, basketballStatistics);
                Assert.IsAssignableFrom<NoContentResult>((sportStatistic3 as NoContentResult));
            }
        }

        /// <summary>
        /// Tests the PostBasketballStatistic() method of BasketballController
        /// </summary>
        [Fact]
        public async void TestForPostBasketballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3StatService")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                BasketballStatisticsController controller = new BasketballStatisticsController(context);
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

                var sportStatistic = await controller.PostBasketballStatistic(basketballStatistics);
                Assert.IsAssignableFrom<CreatedAtActionResult>(sportStatistic.Result as CreatedAtActionResult);
            }
        }

        /// <summary>
        /// Tests the DeleteBasketballStatistic() method of BasketballController
        /// </summary>
        [Fact]
        public async void TestForDeleteBasketballStatistic()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3BasketballController")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                BasketballStatisticsController controller = new BasketballStatisticsController(context);
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

                var sportStatistic = await controller.DeleteBasketballStatistic(Guid.NewGuid());
                Assert.IsAssignableFrom<NotFoundResult>(sportStatistic as NotFoundResult);
                var sportStatistic2 = await controller.DeleteBasketballStatistic(basketballStatistics.StatLineID);
                Assert.IsAssignableFrom<NoContentResult>(sportStatistic2 as NoContentResult);
            }
        }
    }
}
