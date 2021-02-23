using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace Repository
{
    public class Repo
    {
        private readonly StatsContext _statsContext;
        private readonly ILogger _logger;
        public DbSet<BaseballStatistic> BaseballStatistics;
        public DbSet<BasketballStatistic> BasketballStatistics;
        public DbSet<FootBallStatistic> FootballStatistics;
        public DbSet<GolfStatistic> GolfStatistics;
        public DbSet<HockeyStatistic> HockeyStatistics;
        public DbSet<SoccerStatistic> SoccerStatistics;
        public DbSet<PlayerGame> PlayerGames;
        public DbSet<TeamGame> TeamGames;

        public Repo(StatsContext teamContext, ILogger<Repo> logger)
        {
            _statsContext = teamContext;
            _logger = logger;
            this.BaseballStatistics = _statsContext.BaseballStatistics;
            this.BasketballStatistics = _statsContext.BasketballStatistics;
            this.FootballStatistics = _statsContext.FootballStatistics;
            this.GolfStatistics = _statsContext.GolfStatistics;
            this.HockeyStatistics = _statsContext.HockeyStatistics;
            this.SoccerStatistics = _statsContext.SoccerStatistics;
            this.PlayerGames = _statsContext.PlayerGames;
            this.TeamGames = _statsContext.TeamGames;
        }

        public async Task CommitSave()
        {
            await _statsContext.SaveChangesAsync();
        }

        // CreateStatistic
        public async Task<BasketballStatistic> CreateStatistic(BasketballStatistic basketballStatistic)
        {
            await BasketballStatistics.AddAsync(basketballStatistic);
            await CommitSave();
            return await GetBasketballStatisticsById(basketballStatistic.StatLineID);
        }

        public async Task<BaseballStatistic> CreateStatistic(BaseballStatistic baseballStatistic)
        {
            await BaseballStatistics.AddAsync(baseballStatistic);
            await CommitSave();
            return await GetBaseballStatisticsById(baseballStatistic.StatLineID);
        }

        public async Task<FootBallStatistic> CreateStatistic(FootBallStatistic footballStatistic)
        {
            await FootballStatistics.AddAsync(footballStatistic);
            await CommitSave();
            return await GetFootballStatisticsById(footballStatistic.StatLineID);
        }

        public async Task<GolfStatistic> CreateStatistic(GolfStatistic golfStatistic)
        {
            await GolfStatistics.AddAsync(golfStatistic);
            await CommitSave();
            return await GetGolfStatisticsById(golfStatistic.StatLineID);
        }

        public async Task<HockeyStatistic> CreateStatistic(HockeyStatistic hockeyStatistic)
        {
            await HockeyStatistics.AddAsync(hockeyStatistic);
            await CommitSave();
            return await GetHockeyStatisticsById(hockeyStatistic.StatLineID);
        }

        public async Task<SoccerStatistic> CreateStatistic(SoccerStatistic soccerStatistic)
        {
            await SoccerStatistics.AddAsync(soccerStatistic);
            await CommitSave();
            return await GetSoccerStatisticsById(soccerStatistic.StatLineID);
        }


        /*****************************************************************************************/


        // GetSportStatisticById
        public async Task<BasketballStatistic> GetBasketballStatisticsById(Guid id)
        {
            return await BasketballStatistics.FindAsync(id);
        }

        public async Task<BaseballStatistic> GetBaseballStatisticsById(Guid id)
        {
            return await BaseballStatistics.FindAsync(id);
        }

        public async Task<FootBallStatistic> GetFootballStatisticsById(Guid id)
        {
            return await FootballStatistics.FindAsync(id);
        }

        public async Task<GolfStatistic> GetGolfStatisticsById(Guid id)
        {
            return await GolfStatistics.FindAsync(id);
        }

        public async Task<HockeyStatistic> GetHockeyStatisticsById(Guid id)
        {
            return await HockeyStatistics.FindAsync(id);
        }

        public async Task<SoccerStatistic> GetSoccerStatisticsById(Guid id)
        {
            return await SoccerStatistics.FindAsync(id);
        }


        /*****************************************************************************************/


        // GetSportStatistic -- returns list of all statistics for that sport
        /// <summary>
        /// Gets all basketball statistics in the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BasketballStatistic>> GetBasketballStatistic()
        {
            return await BasketballStatistics.ToListAsync();
        }

        /// <summary>
        /// Gets all baseball statistics in the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BaseballStatistic>> GetBaseballStatistic()
        {
            return await BaseballStatistics.ToListAsync();
        }

        /// <summary>
        /// Gets all football statistics in the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<FootBallStatistic>> GetFootBallStatistic()
        {
            return await FootballStatistics.ToListAsync();
        }

        /// <summary>
        /// Gets all golf statistics in the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GolfStatistic>> GetGolfStatistic()
        {
            return await GolfStatistics.ToListAsync();
        }

        /// <summary>
        /// Gets all hockey statistics in the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<HockeyStatistic>> GetHockeyStatistic()
        {
            return await HockeyStatistics.ToListAsync();
        }

        /// <summary>
        /// Gets all soccer statistics in the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SoccerStatistic>> GetSoccerStatistic()
        {
            return await SoccerStatistics.ToListAsync();
        }


        /*****************************************************************************************/


        // GetSportGameStatistic
        /// <summary>
        /// Takes user id and game id, then gets the specified player's statistics for a single 
        /// game.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> GetBasketballGameStatistic(string userId, Guid gameId)
        {
            // Get stat line id
            Guid statLineId = PlayerGames.FirstOrDefaultAsync(x=>x.UserID == userId && x.GameID == gameId).Result.StatLineID;
            // Return stats for that game.
            return await BasketballStatistics.FindAsync(statLineId);
        }

        /// <summary>
        /// Takes user id and game id, then gets the specified player's statistics for a single 
        /// game.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public async Task<BaseballStatistic> GetBaseballGameStatistic(string userId, Guid gameId)
        {
            // Get stat line id
            Guid statLineId = PlayerGames.FirstOrDefaultAsync(x => x.UserID == userId && x.GameID == gameId).Result.StatLineID;
            // Return stats for that game.
            return await BaseballStatistics.FindAsync(statLineId);
        }

        /// <summary>
        /// Takes user id and game id, then gets the specified player's statistics for a single 
        /// game.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public async Task<FootBallStatistic> GetFootballGameStatistic(string userId, Guid gameId)
        {
            // Get stat line id
            Guid statLineId = PlayerGames.FirstOrDefaultAsync(x => x.UserID == userId && x.GameID == gameId).Result.StatLineID;
            // Return stats for that game.
            return await FootballStatistics.FindAsync(statLineId);
        }

        /// <summary>
        /// Takes user id and game id, then gets the specified player's statistics for a single 
        /// game.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public async Task<GolfStatistic> GetGolfGameStatistic(string userId, Guid gameId)
        {
            // Get stat line id
            Guid statLineId = PlayerGames.FirstOrDefaultAsync(x => x.UserID == userId && x.GameID == gameId).Result.StatLineID;
            // Return stats for that game.
            return await GolfStatistics.FindAsync(statLineId);
        }

        /// <summary>
        /// Takes user id and game id, then gets the specified player's statistics for a single 
        /// game.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public async Task<HockeyStatistic> GetHockeyGameStatistic(string userId, Guid gameId)
        {
            // Get stat line id
            Guid statLineId = PlayerGames.FirstOrDefaultAsync(x => x.UserID == userId && x.GameID == gameId).Result.StatLineID;
            // Return stats for that game.
            return await HockeyStatistics.FindAsync(statLineId);
        }

        /// <summary>
        /// Takes user id and game id, then gets the specified player's statistics for a single 
        /// game.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public async Task<SoccerStatistic> GetSoccerGameStatistic(string userId, Guid gameId)
        {
            // Get stat line id
            Guid statLineId = PlayerGames.FirstOrDefaultAsync(x => x.UserID == userId && x.GameID == gameId).Result.StatLineID;
            // Return stats for that game.
            return await SoccerStatistics.FindAsync(statLineId);
        }


        /*****************************************************************************************/


        // GetSportStatisticByPlayerId
        /// <summary>
        /// Takes user id and finds all basketball stat lines for that user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<BasketballStatistic>> GetBasketballStatisticByPlayerId(string id)
        {
            // some generic setup
            List<BasketballStatistic> basketballStatisticList = new List<BasketballStatistic>();
            List<Guid> statLineIdList = new List<Guid>();
            // get all stat line ids where player id matches
            IEnumerable<PlayerGame> playerGameEnumerable = PlayerGames.Where(x=>x.UserID == id);
            // grab stat lines from player games
            foreach (PlayerGame p in playerGameEnumerable)
            {
                statLineIdList.Add(p.StatLineID);
            }
            // grab basketball stats using that list
            foreach(Guid s in statLineIdList)
            {
                // add stats where stat line id matches
                basketballStatisticList.Add(await BasketballStatistics.SingleOrDefaultAsync(x=>x.StatLineID == s));
            }
            // return that list
            return basketballStatisticList;
        }

        /// <summary>
        /// Takes user id and finds all baseball stat lines for that user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<BaseballStatistic>> GetBaseballStatisticByPlayerId(string id)
        {
            // some generic setup
            List<BaseballStatistic> baseballStatisticList = new List<BaseballStatistic>();
            List<Guid> statLineIdList = new List<Guid>();
            // get all stat line ids where player id matches
            IEnumerable<PlayerGame> playerGameEnumerable = PlayerGames.Where(x => x.UserID == id);
            // grab stat lines from player games
            foreach (PlayerGame p in playerGameEnumerable)
            {
                statLineIdList.Add(p.StatLineID);
            }
            // grab basketball stats using that list
            foreach (Guid s in statLineIdList)
            {
                // add stats where stat line id matches
                baseballStatisticList.Add(await BaseballStatistics.SingleOrDefaultAsync(x => x.StatLineID == s));
            }
            // return that list
            return baseballStatisticList;
        }

        /// <summary>
        /// Takes user id and finds all football stat lines for that user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<FootBallStatistic>> GetFootballStatisticByPlayerId(string id)
        {
            // some generic setup
            List<FootBallStatistic> footballStatisticList = new List<FootBallStatistic>();
            List<Guid> statLineIdList = new List<Guid>();
            // get all stat line ids where player id matches
            IEnumerable<PlayerGame> playerGameEnumerable = PlayerGames.Where(x => x.UserID == id);
            // grab stat lines from player games
            foreach (PlayerGame p in playerGameEnumerable)
            {
                statLineIdList.Add(p.StatLineID);
            }
            // grab basketball stats using that list
            foreach (Guid s in statLineIdList)
            {
                // add stats where stat line id matches
                footballStatisticList.Add(await FootballStatistics.SingleOrDefaultAsync(x => x.StatLineID == s));
            }
            // return that list
            return footballStatisticList;
        }

        /// <summary>
        /// Takes user id and finds all golf stat lines for that user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<GolfStatistic>> GetGolfStatisticByPlayerId(string id)
        {
            // some generic setup
            List<GolfStatistic> golfStatisticList = new List<GolfStatistic>();
            List<Guid> statLineIdList = new List<Guid>();
            // get all stat line ids where player id matches
            IEnumerable<PlayerGame> playerGameEnumerable = PlayerGames.Where(x => x.UserID == id);
            // grab stat lines from player games
            foreach (PlayerGame p in playerGameEnumerable)
            {
                statLineIdList.Add(p.StatLineID);
            }
            // grab basketball stats using that list
            foreach (Guid s in statLineIdList)
            {
                // add stats where stat line id matches
                golfStatisticList.Add(await GolfStatistics.SingleOrDefaultAsync(x => x.StatLineID == s));
            }
            // return that list
            return golfStatisticList;
        }

        /// <summary>
        /// Takes user id and finds all hockey stat lines for that user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<HockeyStatistic>> GetHockeyStatisticByPlayerId(string id)
        {
            // some generic setup
            List<HockeyStatistic> hockeyStatisticList = new List<HockeyStatistic>();
            List<Guid> statLineIdList = new List<Guid>();
            // get all stat line ids where player id matches
            IEnumerable<PlayerGame> playerGameEnumerable = PlayerGames.Where(x => x.UserID == id);
            // grab stat lines from player games
            foreach (PlayerGame p in playerGameEnumerable)
            {
                statLineIdList.Add(p.StatLineID);
            }
            // grab basketball stats using that list
            foreach (Guid s in statLineIdList)
            {
                // add stats where stat line id matches
                hockeyStatisticList.Add(await HockeyStatistics.SingleOrDefaultAsync(x => x.StatLineID == s));
            }
            // return that list
            return hockeyStatisticList;
        }

        /// <summary>
        /// Takes user id and finds all soccer stat lines for that user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SoccerStatistic>> GetSoccerStatisticByPlayerId(string id)
        {
            // some generic setup
            List<SoccerStatistic> soccerStatisticList = new List<SoccerStatistic>();
            List<Guid> statLineIdList = new List<Guid>();
            // get all stat line ids where player id matches
            IEnumerable<PlayerGame> playerGameEnumerable = PlayerGames.Where(x => x.UserID == id);
            // grab stat lines from player games
            foreach (PlayerGame p in playerGameEnumerable)
            {
                statLineIdList.Add(p.StatLineID);
            }
            // grab basketball stats using that list
            foreach (Guid s in statLineIdList)
            {
                // add stats where stat line id matches
                soccerStatisticList.Add(await SoccerStatistics.SingleOrDefaultAsync(x => x.StatLineID == s));
            }
            // return that list
            return soccerStatisticList;
        }


        /**********************************************************************************/


        // UpdateStatistic
        /// <summary>
        /// Updates basketball statistics with passed data.
        /// </summary>
        /// <param name="basketballStatistic"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> UpdateStatistic(BasketballStatistic basketballStatistic)
        {
            BasketballStatistics.Update(basketballStatistic);
            await CommitSave();
            return await BasketballStatistics.FindAsync(basketballStatistic.StatLineID);
        }

        /// <summary>
        /// Updates baseball statistics with passed data.
        /// </summary>
        /// <param name="baseballStatistic"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseballStatistic> UpdateStatistic(BaseballStatistic baseballStatistic)
        {
            BaseballStatistics.Update(baseballStatistic);
            await CommitSave();
            return await BaseballStatistics.FindAsync(baseballStatistic.StatLineID);
        }

        /// <summary>
        /// Updates football statistics with passed data.
        /// </summary>
        /// <param name="footballStatistic"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FootBallStatistic> UpdateStatistic(FootBallStatistic footballStatistic)
        {
            FootballStatistics.Update(footballStatistic);
            await CommitSave();
            return await FootballStatistics.FindAsync(footballStatistic.StatLineID);
        }

        /// <summary>
        /// Updates golf statistics with passed data.
        /// </summary>
        /// <param name="golfStatistic"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GolfStatistic> UpdateStatistic(GolfStatistic golfStatistic)
        {
            GolfStatistics.Update(golfStatistic);
            await CommitSave();
            return await GolfStatistics.FindAsync(golfStatistic.StatLineID);
        }

        /// <summary>
        /// Updates hockey statistics with passed data.
        /// </summary>
        /// <param name="hockeyStatistic"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HockeyStatistic> UpdateStatistic(HockeyStatistic hockeyStatistic)
        {
            HockeyStatistics.Update(hockeyStatistic);
            await CommitSave();
            return await HockeyStatistics.FindAsync(hockeyStatistic.StatLineID);
        }

        /// <summary>
        /// Updates soccer statistics with passed data.
        /// </summary>
        /// <param name="soccerStatistic"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SoccerStatistic> UpdateStatistic(SoccerStatistic soccerStatistic)
        {
            SoccerStatistics.Update(soccerStatistic);
            await CommitSave();
            return await SoccerStatistics.FindAsync(soccerStatistic.StatLineID);
        }


        /*************************************************************************************/


        // DeleteStatistic
        /// <summary>
        /// Removes specific basketball statistic instance from database.
        /// </summary>
        /// <param name="basketballStatistic"></param>
        /// <returns></returns>
        public async Task DeleteStatistic(BasketballStatistic basketballStatistic)
        {
            BasketballStatistics.Remove(basketballStatistic);
            await CommitSave();
        }

        /// <summary>
        /// Removes specific baseball statistic instance from database.
        /// </summary>
        /// <param name="baseballStatistic"></param>
        /// <returns></returns>
        public async Task DeleteStatistic(BaseballStatistic baseballStatistic)
        {
            BaseballStatistics.Remove(baseballStatistic);
            await CommitSave();
        }

        /// <summary>
        /// Removes specific football statistic instance from database.
        /// </summary>
        /// <param name="footballStatistic"></param>
        /// <returns></returns>
        public async Task DeleteStatistic(FootBallStatistic footballStatistic)
        {
            FootballStatistics.Remove(footballStatistic);
            await CommitSave();
        }

        /// <summary>
        /// Removes specific golf statistic instance from database.
        /// </summary>
        /// <param name="golfStatistic"></param>
        /// <returns></returns>
        public async Task DeleteStatistic(GolfStatistic golfStatistic)
        {
            GolfStatistics.Remove(golfStatistic);
            await CommitSave();
        }

        /// <summary>
        /// Removes specific hockey statistic instance from database.
        /// </summary>
        /// <param name="hockeyStatistic"></param>
        /// <returns></returns>
        public async Task DeleteStatistic(HockeyStatistic hockeyStatistic)
        {
            HockeyStatistics.Remove(hockeyStatistic);
            await CommitSave();
        }

        /// <summary>
        /// Removes specific soccer statistic instance from database.
        /// </summary>
        /// <param name="soccerStatistic"></param>
        /// <returns></returns>
        public async Task DeleteStatistic(SoccerStatistic soccerStatistic)
        {
            SoccerStatistics.Remove(soccerStatistic);
            await CommitSave();
        }
    }
}
