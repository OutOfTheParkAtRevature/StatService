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
            IEnumerable<BaseballStatistic> estats = await repo.GetBaseballStatistics();
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
    }
}
