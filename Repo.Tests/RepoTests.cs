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
        [Fact]
        public async void TestCreateStatistic() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("create-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);

            var createBasketball = new BasketballStatistic() { StatLineID = Guid.NewGuid() };
            var basketball = await repo.CreateStatistic(createBasketball);
            Assert.Equal(basketball.StatLineID, createBasketball.StatLineID);

            var createBaseball = new BaseballStatistic() { StatLineID = Guid.NewGuid() };
            var baseball = await repo.CreateStatistic(createBaseball);
            Assert.Equal(baseball.StatLineID, createBaseball.StatLineID);

            var createFootball = new FootBallStatistic() { StatLineID = Guid.NewGuid() };
            var football = await repo.CreateStatistic(createFootball);
            Assert.Equal(football.StatLineID, createFootball.StatLineID);

            var createGolf = new GolfStatistic() { StatLineID = Guid.NewGuid() };
            var golf = await repo.CreateStatistic(createGolf);
            Assert.Equal(golf.StatLineID, createGolf.StatLineID);

            var createHockey = new HockeyStatistic() { StatLineID = Guid.NewGuid() };
            var hockey = await repo.CreateStatistic(createHockey);
            Assert.Equal(hockey.StatLineID, createHockey.StatLineID);
            
            var createSoccer = new SoccerStatistic() { StatLineID = Guid.NewGuid() };
            var soccer = await repo.CreateStatistic(createSoccer);
            Assert.Equal(soccer.StatLineID, createSoccer.StatLineID);
        }
        [Fact]
        public async void TestUpdateStatistic() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("update-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);

            var basketball = await repo.CreateStatistic(new BasketballStatistic() { StatLineID = Guid.NewGuid() });
            basketball.Assists = 1;
            basketball = await repo.UpdateStatistic(basketball);
            Assert.NotEqual(0, basketball.Assists);
            
            var baseball = await repo.CreateStatistic(new BaseballStatistic() { StatLineID = Guid.NewGuid() });
            baseball.BattingAve = 1;
            baseball = await repo.UpdateStatistic(baseball);
            Assert.NotEqual(0, baseball.BattingAve);

            var football = await repo.CreateStatistic(new FootBallStatistic() { StatLineID = Guid.NewGuid() });
            football.FirstDownCons = 1;
            football = await repo.UpdateStatistic(football);
            Assert.NotEqual(0, football.FirstDownCons);

            var golf = await repo.CreateStatistic(new GolfStatistic() { StatLineID = Guid.NewGuid() });
            golf.Birdies = 1;
            golf = await repo.UpdateStatistic(golf);
            Assert.NotEqual(0, golf.Birdies);

            var hockey = await repo.CreateStatistic(new HockeyStatistic() { StatLineID = Guid.NewGuid() });
            hockey.Blocks = 1;
            hockey = await repo.UpdateStatistic(hockey);
            Assert.NotEqual(0, hockey.Blocks);

            var soccer = await repo.CreateStatistic(new SoccerStatistic() { StatLineID = Guid.NewGuid() });
            soccer.CornerKicks = 1;
            soccer = await repo.UpdateStatistic(soccer);
            Assert.NotEqual(0, soccer.CornerKicks);
        }
        [Fact]
        public async void TestDeleteStatistic() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("delete-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);

            var basketball = await repo.CreateStatistic(new BasketballStatistic() { StatLineID = Guid.NewGuid() });
            await repo.DeleteStatistic(basketball);
            basketball = await repo.GetBasketballStatisticsById(basketball.StatLineID);
            Assert.Null(basketball);

            var baseball = await repo.CreateStatistic(new BaseballStatistic() { StatLineID = Guid.NewGuid() });
            await repo.DeleteStatistic(baseball);
            baseball = await repo.GetBaseballStatisticsById(baseball.StatLineID);
            Assert.Null(baseball);

            var football = await repo.CreateStatistic(new FootBallStatistic() { StatLineID = Guid.NewGuid() });
            await repo.DeleteStatistic(football);
            football = await repo.GetFootballStatisticsById(football.StatLineID);
            Assert.Null(football);

            var golf = await repo.CreateStatistic(new GolfStatistic() { StatLineID = Guid.NewGuid() });
            await repo.DeleteStatistic(golf);
            golf = await repo.GetGolfStatisticsById(golf.StatLineID);
            Assert.Null(golf);

            var hockey = await repo.CreateStatistic(new HockeyStatistic() { StatLineID = Guid.NewGuid() });
            await repo.DeleteStatistic(hockey);
            hockey = await repo.GetHockeyStatisticsById(hockey.StatLineID);
            Assert.Null(hockey);

            var soccer = await repo.CreateStatistic(new SoccerStatistic() { StatLineID = Guid.NewGuid() });
            await repo.DeleteStatistic(soccer);
            soccer = await repo.GetSoccerStatisticsById(soccer.StatLineID);
            Assert.Null(soccer);
        }
    }
}
