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
        [Fact]
        public async void TestCreateStatistic() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("create-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            var logic = new Logic(repo, null);

            var createBasketball = new BasketballStatistic() { StatLineID = Guid.NewGuid() };
            var basketball = await logic.CreateStatistic(createBasketball);
            Assert.Equal(basketball.StatLineID, createBasketball.StatLineID);

            var createBaseball = new BaseballStatistic() { StatLineID = Guid.NewGuid() };
            var baseball = await logic.CreateStatistic(createBaseball);
            Assert.Equal(baseball.StatLineID, createBaseball.StatLineID);

            var createFootball = new FootBallStatistic() { StatLineID = Guid.NewGuid() };
            var football = await logic.CreateStatistic(createFootball);
            Assert.Equal(football.StatLineID, createFootball.StatLineID);

            var createGolf = new GolfStatistic() { StatLineID = Guid.NewGuid() };
            var golf = await logic.CreateStatistic(createGolf);
            Assert.Equal(golf.StatLineID, createGolf.StatLineID);

            var createHockey = new HockeyStatistic() { StatLineID = Guid.NewGuid() };
            var hockey = await logic.CreateStatistic(createHockey);
            Assert.Equal(hockey.StatLineID, createHockey.StatLineID);

            var createSoccer = new SoccerStatistic() { StatLineID = Guid.NewGuid() };
            var soccer = await logic.CreateStatistic(createSoccer);
            Assert.Equal(soccer.StatLineID, createSoccer.StatLineID);
        }
        [Fact]
        public async void TestUpdateStatistic() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("update-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            var logic = new Logic(repo, null);

            var basketball = await logic.CreateStatistic(new BasketballStatistic() { StatLineID = Guid.NewGuid() });
            basketball.Assists = 1;
            basketball = await logic.UpdateStatistic(basketball);
            Assert.NotEqual(0, basketball.Assists);
            
            var baseball = await logic.CreateStatistic(new BaseballStatistic() { StatLineID = Guid.NewGuid() });
            baseball.BattingAve = 1;
            baseball = await logic.UpdateStatistic(baseball);
            Assert.NotEqual(0, baseball.BattingAve);

            var football = await logic.CreateStatistic(new FootBallStatistic() { StatLineID = Guid.NewGuid() });
            football.FirstDownCons = 1;
            football = await logic.UpdateStatistic(football);
            Assert.NotEqual(0, football.FirstDownCons);

            var golf = await logic.CreateStatistic(new GolfStatistic() { StatLineID = Guid.NewGuid() });
            golf.Birdies = 1;
            golf = await logic.UpdateStatistic(golf);
            Assert.NotEqual(0, golf.Birdies);

            var hockey = await logic.CreateStatistic(new HockeyStatistic() { StatLineID = Guid.NewGuid() });
            hockey.Blocks = 1;
            hockey = await logic.UpdateStatistic(hockey);
            Assert.NotEqual(0, hockey.Blocks);

            var soccer = await logic.CreateStatistic(new SoccerStatistic() { StatLineID = Guid.NewGuid() });
            soccer.CornerKicks = 1;
            soccer = await logic.UpdateStatistic(soccer);
            Assert.NotEqual(0, soccer.CornerKicks);
        }
        [Fact]
        public async void TestDeleteStatistic() {
            var opt = new DbContextOptionsBuilder<StatsContext>()
                .UseInMemoryDatabase("delete-stats")
                .Options;
            var ctx = new StatsContext(opt);
            var repo = new Repo(ctx, null);
            var logic = new Logic(repo, null);

            var basketball = await logic.CreateStatistic(new BasketballStatistic() { StatLineID = Guid.NewGuid() });
            await logic.DeleteStatistic(basketball);
            basketball = await logic.GetBasketballStatisticById(basketball.StatLineID);
            Assert.Null(basketball);

            var baseball = await logic.CreateStatistic(new BaseballStatistic() { StatLineID = Guid.NewGuid() });
            await logic.DeleteStatistic(baseball);
            baseball = await logic.GetBaseballStatisticById(baseball.StatLineID);
            Assert.Null(baseball);

            var football = await logic.CreateStatistic(new FootBallStatistic() { StatLineID = Guid.NewGuid() });
            await logic.DeleteStatistic(football);
            football = await logic.GetFootballStatisticById(football.StatLineID);
            Assert.Null(football);

            var golf = await logic.CreateStatistic(new GolfStatistic() { StatLineID = Guid.NewGuid() });
            await logic.DeleteStatistic(golf);
            golf = await logic.GetGolfStatisticById(golf.StatLineID);
            Assert.Null(golf);

            var hockey = await logic.CreateStatistic(new HockeyStatistic() { StatLineID = Guid.NewGuid() });
            await logic.DeleteStatistic(hockey);
            hockey = await logic.GetHockeyStatisticById(hockey.StatLineID);
            Assert.Null(hockey);

            var soccer = await logic.CreateStatistic(new SoccerStatistic() { StatLineID = Guid.NewGuid() });
            await logic.DeleteStatistic(soccer);
            soccer = await logic.GetSoccerStatisticById(soccer.StatLineID);
            Assert.Null(soccer);
        }
    }
}
