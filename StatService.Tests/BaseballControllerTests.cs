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

                //var sportStasticList = await controller.GetBaseballStatistics();
                //var convertStasticList = (List<BaseballStatistic>)sportStasticList;
                //Assert.Contains<BaseballStatistic>(convertStasticList[0], context.BaseballStatistics);
            }
        }
    }
}
