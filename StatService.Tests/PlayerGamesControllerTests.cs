using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Models;
using Models.DataTransfer;
using Repository;
using Service;
using StatService.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace StatService.Tests
{
    public class PlayerGamesControllerTests
    {
        /// <summary>
        /// Tests the GetPlayerGames() method of PlayerGamesController
        /// </summary>
        [Fact]
        public async void TestForGetPlayerGames()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetPlayerGames")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                PlayerGamesController controller = new PlayerGamesController(context, l);
                var player = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = Guid.NewGuid(),
                    GameID = Guid.NewGuid()
                };
                r.PlayerGames.Add(player);
                await r.CommitSave();

                var playerList = await controller.GetPlayerGames();
                var convertList = (List<PlayerGame>)playerList.Value;
                Assert.Contains<PlayerGame>(convertList[0], context.PlayerGames);
            }
        }

        /// <summary>
        /// Tests the GetPlayerGame(id) method of PlayerGamesController
        /// TODO: figure out composite key to test
        /// </summary>
        [Fact]
        public async void TestForGetPlayerGameById()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetPlayerGameById")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                PlayerGamesController controller = new PlayerGamesController(context, l);
                var player = new PlayerGame
                {
                    UserID = "rob",
                    StatLineID = Guid.NewGuid(),
                    GameID = Guid.NewGuid()
                };
                r.PlayerGames.Add(player);
                await r.CommitSave();

                var getPlayer = await controller.GetPlayerGame(player.UserID, Guid.NewGuid());
                Assert.IsAssignableFrom<NotFoundResult>((getPlayer.Result as NotFoundResult));
                var getPlayer2 = await controller.GetPlayerGame(player.UserID, player.GameID);
                Assert.True(getPlayer2.Value.playerId.Equals("rob"));
            }
        }

        /// <summary>
        /// Tests the PutPlayerGame() method of PlayerGamesController
        /// </summary>
        //[Fact]
        //public async void TestForPutPlayerGame()
        //{
        //    var options = new DbContextOptionsBuilder<StatsContext>()
        //    .UseInMemoryDatabase(databaseName: "p3GetPlayerGames")
        //    .Options;

        //    using (var context = new StatsContext(options))
        //    {
        //        context.Database.EnsureDeleted();
        //        context.Database.EnsureCreated();

        //        Repo r = new Repo(context, new NullLogger<Repo>());
        //        PlayerGamesController controller = new PlayerGamesController(context);
        //        var player = new PlayerGame
        //        {
        //            UserID = "rob",
        //            StatLineID = Guid.NewGuid(),
        //            GameID = Guid.NewGuid()
        //        };
        //        var player2 = new PlayerGame
        //        {
        //            UserID = "george",
        //            StatLineID = Guid.NewGuid(),
        //            GameID = Guid.NewGuid()
        //        };

        //        var getPlayer = await controller.PutPlayerGame(player.UserID, player2);
        //        Assert.IsAssignableFrom<BadRequestResult>((getPlayer as BadRequestResult));

        //        var getPlayer2 = await controller.PutPlayerGame(player.UserID, player);
        //        Assert.IsAssignableFrom<NotFoundResult>((getPlayer2 as NotFoundResult));

        //        r.PlayerGames.Add(player);
        //        await r.CommitSave();

        //        var getPlayer3 = await controller.PutPlayerGame(player.UserID, player);
        //        Assert.IsAssignableFrom<NoContentResult>((getPlayer3 as NoContentResult));
        //    }
        //}

        /// <summary>
        /// Tests the PostPlayerGame() method of PlayerGamesController
        /// </summary>
        [Fact]
        public async void TestForPostPlayerGame()
        {
            var options = new DbContextOptionsBuilder<StatsContext>()
            .UseInMemoryDatabase(databaseName: "p3GetPlayerGames")
            .Options;

            using (var context = new StatsContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                Logic l = new Logic(r, new NullLogger<Repo>());
                PlayerGamesController controller = new PlayerGamesController(context, l);
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
                var player = new CreatePlayerGameDto
                {
                    playerId = "rob",
                    gameId = Guid.NewGuid(),
                    baseballStatistic = baseballStatistics
                };

                var getPlayer = await controller.PostPlayerGame(player);
                Assert.IsAssignableFrom<OkObjectResult>(getPlayer.Result as OkObjectResult);
            }
        }

        /// <summary>
        /// Tests the DeletePlayerGame() method of PlayerGamesController
        /// TODO: figure out composite key to test
        /// </summary>
        //[Fact]
        //public async void TestForDeletePlayerGame()
        //{
        //    var options = new DbContextOptionsBuilder<StatsContext>()
        //    .UseInMemoryDatabase(databaseName: "p3DeletePlayerGames")
        //    .Options;

        //    using (var context = new StatsContext(options))
        //    {
        //        context.Database.EnsureDeleted();
        //        context.Database.EnsureCreated();

        //        Repo r = new Repo(context, new NullLogger<Repo>());
        //        Logic l = new Logic(r, new NullLogger<Repo>());
        //        PlayerGamesController controller = new PlayerGamesController(context, l);
        //        var player = new PlayerGame
        //        {
        //            UserID = "rob",
        //            StatLineID = Guid.NewGuid(),
        //            GameID = Guid.NewGuid()
        //        };
        //        r.PlayerGames.Add(player);
        //        await r.CommitSave();

        //        //var getPlayer = await controller.DeletePlayerGame("");
        //        //Assert.IsAssignableFrom<NotFoundResult>(getPlayer as NotFoundResult);
        //        //var getPlayer2 = await controller.DeletePlayerGame(player.UserID);
        //        //Assert.IsAssignableFrom<NoContentResult>(getPlayer2 as NoContentResult);
        //    }
        //}
    }
}
