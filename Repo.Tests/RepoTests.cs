using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

using Repository;
using Models;

namespace Repository.Tests {
    public class RepoTests {
        [Fact]
        public async void TestGetBaseballStatistics() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("get-baseball-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            IEnumerable<BaseballStatistic> estats = await repo.GetBaseballStatistic();
            List<BaseballStatistic> lstats = estats.ToList();
            Assert.Empty(lstats);
        }
        [Fact]
        public async void TestGetBasketballStatistics() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("get-basketball-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            IEnumerable<BasketballStatistic> estats = await repo.GetBasketballStatistic();
            List<BasketballStatistic> lstats = estats.ToList();
            Assert.Empty(lstats);
        }
        [Fact]
        public async void TestGetFootballStatistics() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("get-football-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            IEnumerable<FootBallStatistic> estats = await repo.GetFootBallStatistic();
            List<FootBallStatistic> lstats = estats.ToList();
            Assert.Empty(lstats);
        }
        [Fact]
        public async void TestGetGolfStatistics() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("get-golf-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            IEnumerable<GolfStatistic> estats = await repo.GetGolfStatistic();
            List<GolfStatistic> lstats = estats.ToList();
            Assert.Empty(lstats);
        }
        [Fact]
        public async void TestGetHockeyStatistics() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("get-hockey-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            IEnumerable<HockeyStatistic> estats = await repo.GetHockeyStatistic();
            List<HockeyStatistic> lstats = estats.ToList();
            Assert.Empty(lstats);
        }
        [Fact]
        public async void TestGetSoccerStatistics() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("get-soccer-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            IEnumerable<SoccerStatistic> estats = await repo.GetSoccerStatistic();
            List<SoccerStatistic> lstats = estats.ToList();
            Assert.Empty(lstats);
        }
    }
}
