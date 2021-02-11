using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Repository;

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
        public DbSet<ApplicationUser> Users;

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
            this.Users = _statsContext.Users;
        }

        public async Task CommitSave()
        {
            await _statsContext.SaveChangesAsync();
        }
        
        // CreateStatistic
        public async Task<BasketballStatistic> CreateStatistic(BasketballStatistic bs)
        {
            await BasketballStatistics.AddAsync(bs);
            await CommitSave();
            return await GetBasketballStatisticsById(bs.StatLineID);
        }

        // GetStatistic
        public async Task<BasketballStatistic> GetBasketballStatisticsById(Guid id)
        {
            return await BasketballStatistics.FindAsync(id);
        }

        // TODO: Double check that Find does what is expected.
        /// <summary>
        /// Gets the specified player's statistics for a single game.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> GetGameStatistic(Guid userId, Guid gameId)
        {
            // Get stat line id
            Guid statLineId = PlayerGames.Find(userId, gameId).StatLineID;
            // Return stats for that game.
            return await BasketballStatistics.FindAsync(statLineId);
        }

        /// <summary>
        /// Gets all basketball statistics in the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BasketballStatistic>> GetBasketballStatistic()
        {
            return await BasketballStatistics.ToListAsync();
        }

        // UpdateStatistic
        /// <summary>
        /// Updates basketball statistics with passed data.
        /// </summary>
        /// <param name="basketballStatistic"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BasketballStatistic> UpdateStatistic(BasketballStatistic basketballStatistic, Guid id)
        {
            BasketballStatistics.Update(basketballStatistic);
            await CommitSave();
            return await BasketballStatistics.FindAsync(id);
        }

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


        /*
        public async Task<BaseballStatistic> GetBaseballStatisticsById(Guid id)
        {
            return await BaseballStatistics.FindAsync(id);
        }

        public async Task<IEnumerable<BaseballStatistic>> GetBaseballStatistics()
        {
            return await BaseballStatistics.ToListAsync();
        }


        public async Task<FootBallStatistic> GetFootBallStatisticsById(Guid id)
        {
            return await FootballStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<FootBallStatistic>> GetFootBallStatistic()
        {
            return await FootballStatistics.ToListAsync();
        }

        public async Task<GolfStatistic> GetGolfStatisticsById(Guid id)
        {
            return await GolfStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<GolfStatistic>> GetGolfStatistic()
        {
            return await GolfStatistics.ToListAsync();
        }
        public async Task<HockeyStatistic> GetHockeyStatisticsById(Guid id)
        {
            return await HockeyStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<HockeyStatistic>> GetHockeyStatistic()
        {
            return await HockeyStatistics.ToListAsync();
        }

        public async Task<SoccerStatistic> GetSoccerStatisticsById(Guid id)
        {
            return await SoccerStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<SoccerStatistic>> GetSoccerStatistic()
        {
            return await SoccerStatistics.ToListAsync();
        }

        // UpdateStatistic
        public async Task<BaseballStatistic> UpdateStatistic(BaseballStatistic baseballStatistic, Guid id)
        {
            BaseballStatistics.Update(baseballStatistic);
            return await BaseballStatistics.FindAsync(id);
        }

        public async Task<FootBallStatistic> UpdateStatistic(FootBallStatistic footballStatistic, Guid id)
        {
            FootballStatistics.Update(footballStatistic);
            return await FootballStatistics.FindAsync(id);
        }

        public async Task<GolfStatistic> UpdateStatistic(GolfStatistic golfStatistic, Guid id)
        {
            GolfStatistics.Update(golfStatistic);
            return await GolfStatistics.FindAsync(id);
        }

        public async Task<HockeyStatistic> UpdateStatistic(HockeyStatistic hockeyStatistic, Guid id)
        {
            HockeyStatistics.Update(hockeyStatistic);
            return await HockeyStatistics.FindAsync(id);
        }

        public async Task<SoccerStatistic> UpdateStatistic(SoccerStatistic soccerStatistic, Guid id)
        {
            SoccerStatistics.Update(soccerStatistic);
            return await SoccerStatistics.FindAsync(id);
        }

        */
    }
}
