using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Models;
using Repository;

namespace Service
{
    public class Logic
    {
        public Logic() { }
        public Logic(Repo repo, ILogger<Repo> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        private readonly Repo _repo;
        private readonly ILogger<Repo> _logger;

        /********************************************************************************
         * What we can do:
         *      Create empty statistic
         *      Get statistic by guid
         *      Get player's overall statistics
         *      Update statistics for a particular game
         *      Delete statistic from the database
         *      
         * TODO:
         *      Model Dto's
         *      Send appropriate Dto's back based on frontend needs
         *      Implement all methods for other sports
         *
         ********************************************************************************/

        // May change this method to create statistic with passed parameters -- allows overloading
        /// <summary>
        /// Creates an empty basketball statistic for a player. Statistic can be updated with UpdateStatistic method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> CreateStatistic()
        {
            BasketballStatistic bs = new BasketballStatistic();
            return await _repo.CreateStatistic(bs);
        }
 
        /// <summary>
        /// Takes an id and retrieves matching specified basketball statistic for a team or an individual.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> GetBasketballStatisticById(Guid id){
            return await _repo.GetBasketballStatisticsById(id);
        }

        
        /// <summary>
        /// Takes a game id and a user id  to retrieve statline from PlayerGame db set. Returns stats from that game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> GetGameStatistic(Guid userId, Guid gameId)
        {
            return await _repo.GetGameStatistic(userId, gameId);
        }   

        
        /// <summary>
        /// Summarizes player statistics from the season.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> GetPlayerOverallStatistic(Guid id)
        {
            // create basketball statistic to return
            BasketballStatistic basketballStatistic = new BasketballStatistic();
            // get list of all stats with userId filtering result
            IEnumerable<BasketballStatistic> basketballStatisticList = await _repo.GetBasketballStatisticByPlayerId(id);
            // add all stats together
            foreach(BasketballStatistic b in basketballStatisticList)
            {
                basketballStatistic.Assists += b.Assists;
                basketballStatistic.FGoals += b.FGoals;
                basketballStatistic.Fouls += b.Fouls;
                basketballStatistic.FThrows += b.FThrows;
                basketballStatistic.Rebounds += b.Rebounds;
                basketballStatistic.Steals += b.Steals;
                basketballStatistic.Turnovers += b.Turnovers;
            }
            // return total
            return basketballStatistic;
        }

        // May be redundant to send id in since we can grab the id from the basketball statistic model
        /// <summary>
        /// Takes an id and additional basketball statistics, retrieves matching specified basketball statistic to update for a team or an individual and adds the stats.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> UpdateStatistic(BasketballStatistic updatedBasketballStatistic/*, Guid id*/)
        {
            // Get player stat line id
            BasketballStatistic basketballStatistic = await _repo.GetBasketballStatisticsById(updatedBasketballStatistic.StatLineID);

            // Add new stats
            basketballStatistic.Assists = updatedBasketballStatistic.Assists;
            basketballStatistic.FGoals = updatedBasketballStatistic.FGoals;
            basketballStatistic.Fouls = updatedBasketballStatistic.Fouls;
            basketballStatistic.FThrows = updatedBasketballStatistic.FThrows;
            basketballStatistic.Rebounds = updatedBasketballStatistic.Rebounds;
            basketballStatistic.Steals = updatedBasketballStatistic.Steals;
            basketballStatistic.Turnovers = updatedBasketballStatistic.Turnovers;

            // Update statistics and return updated statistics
            return await _repo.UpdateStatistic(basketballStatistic);
        }

        /// <summary>
        /// Takes a basketball statistic and removes it from the database.
        /// </summary>
        /// <param name="basketballStatistic"></param>
        /// <returns></returns>
        public async Task DeleteStatistic(BasketballStatistic basketballStatistic)
        {
            await _repo.DeleteStatistic(basketballStatistic);
        }

        /*
        public async Task<BaseballStatistic> UpdatePlayerStatistic(BaseballStatistic b, Guid id)
        {
            // Get player stat line id
            BaseballStatistic bs = await _repo.GetBaseballStatisticsById(id);

            // Add new stats
            bs.Hits += b.Hits;
            bs.Steals += b.Steals;
            bs.Saves += b.Saves;
            bs.StrikeOuts += b.StrikeOuts;
            bs.RBI += b.RBI;

            // The arithmetic needs to be changed to reflect averages for these variables
            bs.ERA += b.ERA;
            bs.BattingAve += b.BattingAve;


            // Update Player and return
            return await _repo.UpdateStatistic(bs, id);
        }

        public async Task<FootBallStatistic> UpdatePlayerStatistic(FootBallStatistic b, Guid id)
        {
            // Get player stat line id
            FootBallStatistic bs = await _repo.GetFootBallStatisticsById(id);

            // Add new stats
            bs.FirstDownCons += b.FirstDownCons;
            bs.Penalties += b.Penalties;
            bs.Plays += b.Plays;
            bs.Sacks += b.Sacks;
            bs.Turnovers += b.Turnovers;
            bs.YardsRec += b.YardsRec;
            bs.YardsRun += b.YardsRun;

            // Update Player and return
            return await _repo.UpdateStatistic(bs, id);
        }

        // This one may be handled differently because golf statistics are handled on a game by game basis.
        public async Task<GolfStatistic> UpdatePlayerStatistic(GolfStatistic b, Guid id)
        {
            // Get player stat line id
            GolfStatistic bs = await _repo.GetGolfStatisticsById(id);

            // Add new stats
            bs.Birdies += b.Birdies;
            bs.Bogeys += b.Bogeys;
            bs.DriveAccuracy += b.DriveAccuracy;
            bs.DriveDistance += b.DriveDistance;
            bs.Eagles += b.Eagles;
            bs.GIR += b.GIR;
            bs.PutsperGIR += b.PutsperGIR;
            bs.SandSaves += b.SandSaves;
            bs.ScoreToPar += b.ScoreToPar;
            bs.Scrambles += b.Scrambles;

            // Update Player and return
            return await _repo.UpdateStatistic(bs, id);
        }

        public async Task<HockeyStatistic> UpdatePlayerStatistic(HockeyStatistic b, Guid id)
        {
            // Get player stat line id
            HockeyStatistic bs = await _repo.GetHockeyStatisticsById(id);

            // Add new stats
            bs.Blocks += b.Blocks;
            bs.FaceOffWins += b.FaceOffWins;
            bs.GiveAways += b.GiveAways;
            bs.Goals += b.Goals;
            bs.Hits += b.Hits;
            bs.PenaltyMins += b.PenaltyMins;
            bs.PowerPlayOpps += b.PowerPlayOpps;
            bs.Shots += b.Shots;
            bs.TakeAWays += b.TakeAWays;

            // Update Player and return
            return await _repo.UpdateStatistic(bs, id);
        }

        // This function written slightly different at the end.
        // Experimenting with just making repo use 'async Task' instead of returning something.
        public async Task<SoccerStatistic> UpdatePlayerStatistic(SoccerStatistic b, Guid id)
        {
            // Get player stat line id
            SoccerStatistic bs = await _repo.GetSoccerStatisticsById(id);

            // Add new stats
            bs.CornerKicks += b.CornerKicks;
            bs.Fouls += b.Fouls;
            bs.Goals += b.Goals;
            bs.OffSides += b.OffSides;
            bs.RedCards += b.RedCards;
            bs.ShotOnGoal += b.ShotOnGoal;
            bs.yellowCards += b.yellowCards;

            // Update Player and return
            await _repo.UpdateStatistic(bs, id);
            await _repo.CommitSave();

            return bs;
        }
        */
    }
}
