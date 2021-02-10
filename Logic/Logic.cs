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

        /**************************************************
         * TODO:
         *      Update player statistic -- in progress
         *      Get player statistic for one game
         *
         *      Fix naming conventions
         *      Make sure all functions are saving changes.
         **************************************************/


        public async Task<BasketballStatistic> GetPlayerStatistic(int id){
            return await _repo.GetBasketballStatisticsById(id);
        }

        public async Task<BaseballStatistic> UpdatePlayerStatistic(BaseballStatistic b, int id)
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

        public async Task<BasketballStatistic> UpdatePlayerStatistic(BasketballStatistic b, int id)
        {
            // Get player stat line id
            BasketballStatistic bs = await _repo.GetBasketballStatisticsById(id);

            // Add new stats
            bs.Assists += b.Assists;
            bs.FGoals += b.FGoals;
            bs.Fouls += b.Fouls;
            bs.FThrows += b.FThrows;
            bs.Rebounds += b.Rebounds;
            bs.Steals += b.Steals;
            bs.Turnovers += b.Turnovers;

            // Update Player and return
            return await _repo.UpdateStatistic(bs, id);
        }

        public async Task<FootBallStatistic> UpdatePlayerStatistic(FootBallStatistic b, int id)
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
        public async Task<GolfStatistic> UpdatePlayerStatistic(GolfStatistic b, int id)
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

        public async Task<HockeyStatistic> UpdatePlayerStatistic(HockeyStatistic b, int id)
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
        public async Task<SoccerStatistic> UpdatePlayerStatistic(SoccerStatistic b, int id)
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
    }
}
