using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

using Repository;
using Models;

namespace Service.Tests {
    public class LogicTests {
        [Fact]
        public async void TestGetBaseballStatistics() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("get-baseball-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            var logic = new Logic(repo, null);
            BaseballStatistic stats = await logic.GetBaseballStatisticById(new Guid());
            Assert.Null(stats);
        }
        [Fact]
        public async void TestGetBasketballStatistics() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("get-basketball-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            var logic = new Logic(repo, null);
            BasketballStatistic stats = await logic.GetBasketballStatisticById(new Guid());
            Assert.Null(stats);
        }
        [Fact]
        public async void TestGetFootballStatistics() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("get-football-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            var logic = new Logic(repo, null);
            FootBallStatistic stats = await logic.GetFootballStatisticById(new Guid());
            Assert.Null(stats);
        }
        [Fact]
        public async void TestGetGolfStatistics() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("get-golf-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            var logic = new Logic(repo, null);
            GolfStatistic stats = await logic.GetGolfStatisticById(new Guid());
            Assert.Null(stats);
        }
        [Fact]
        public async void TestGetHockeyStatistics() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("get-hockey-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            var logic = new Logic(repo, null);
            HockeyStatistic stats = await logic.GetHockeyStatisticById(new Guid());
            Assert.Null(stats);
        }
        [Fact]
        public async void TestGetSoccerStatistics() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("get-soccer-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            var logic = new Logic(repo, null);
            SoccerStatistic stats = await logic.GetSoccerStatisticById(new Guid());
            Assert.Null(stats);
        }
    }
}
