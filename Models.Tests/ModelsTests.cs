using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Models.Tests {
    public class ModelsTests {

        /// <summary>
        /// Checks the data annotations of Models to make sure they aren't being violated
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private IList<ValidationResult> ValidateModel(object model)
        {
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);
            Validator.TryValidateObject(model, validationContext, result, true);
            // if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);

            return result;
        }

        /// <summary>
        /// Makes sure BaseballStatistic model works with valid data
        /// </summary>
        [Fact]
        public void ValidateBaseballStatistic()
        {
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

            var results = ValidateModel(baseballStatistics);
            Assert.True(results.Count == 0);
        }

        /// <summary>
        /// Makes sure BasketballStatistic model works with valid data
        /// </summary>
        [Fact]
        public void ValidateBasketballStatistic()
        {
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

            var results = ValidateModel(basketballStatistics);
            Assert.True(results.Count == 0);
        }

        /// <summary>
        /// Makes sure FootballStatistic model works with valid data
        /// </summary>
        [Fact]
        public void ValidateFootballStatistic()
        {
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

            var results = ValidateModel(footballStatistics);
            Assert.True(results.Count == 0);
        }

        /// <summary>
        /// Makes sure GolfStatistic model works with valid data
        /// </summary>
        [Fact]
        public void ValidateGolfStatistic()
        {
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

            var results = ValidateModel(golfStatistics);
            Assert.True(results.Count == 0);
        }

        /// <summary>
        /// Makes sure HockeyStatistic model works with valid data
        /// </summary>
        [Fact]
        public void ValidateHockeyStatistic()
        {
            var hockeyStatistics = new HockeyStatistic()
            {
                StatLineID = Guid.NewGuid(),
                Goals = 16,
                Shots = 51,
                Hits = 27,
                FaceOffWins = 7,
                PowerPlayOpps = 23,
                PenaltyMins = 45,
                Blocks = 21,
                TakeAWays = 12,
                GiveAways = 19
            };

            var results = ValidateModel(hockeyStatistics);
            Assert.True(results.Count == 0);
        }

        /// <summary>
        /// Makes sure PlayerGame model works with valid data
        /// </summary>
        [Fact]
        public void ValidatePlayerGame()
        {
            var game = new PlayerGame()
            {
                StatLineID = Guid.NewGuid(),
                GameID = Guid.NewGuid(),
                UserID = "rob"
            };

            var results = ValidateModel(game);
            Assert.True(results.Count == 0);
        }

        /// <summary>
        /// Makes sure SoccerStatistic model works with valid data
        /// </summary>
        [Fact]
        public void ValidateSoccerStatistic()
        {
            var soccerStatistics = new SoccerStatistic()
            {
                StatLineID = Guid.NewGuid(),
                Goals = 33,
                ShotOnGoal = 55,
                Fouls = 73,
                yellowCards = 47,
                RedCards = 31,
                OffSides = 26,
                CornerKicks = 67,
                PossessionTime = 44
            };

            var results = ValidateModel(soccerStatistics);
            Assert.True(results.Count == 0);
        }

        /// <summary>
        /// Makes sure TeamGame model works with valid data
        /// </summary>
        [Fact]
        public void ValidateTeamGame()
        {
            var game = new TeamGame()
            {
                StatLineID = Guid.NewGuid(),
                GameID = Guid.NewGuid(),
                TeamID = "tigers"
            };

            var results = ValidateModel(game);
            Assert.True(results.Count == 0);
        }


    }
}
