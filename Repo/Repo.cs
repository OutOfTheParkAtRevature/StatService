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
        }

        public async Task CommitSave()
        {
            await _statsContext.SaveChangesAsync();
        }

        public async Task<BaseballStatistic> GetBaseballStatisticsById(int id)
        {
            return await BaseballStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<BaseballStatistic>> GetBaseballStatistics()
        {
            return await BaseballStatistics.ToListAsync();
        }


        public async Task<BasketballStatistic> GetBasketballStatisticsById(int id)
        {
            return await BasketballStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<BasketballStatistic>> GetBasketballStatistic()
        {
            return await BasketballStatistics.ToListAsync();
        }

        public async Task<FootBallStatistic> GetFootBallStatisticsById(int id)
        {
            return await FootballStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<FootBallStatistic>> GetFootBallStatistic()
        {
            return await FootballStatistics.ToListAsync();
        }
        public async Task<GolfStatistic> GetGolfStatisticsById(int id)
        {
            return await GolfStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<GolfStatistic>> GetGolfStatistic()
        {
            return await GolfStatistics.ToListAsync();
        }
        public async Task<HockeyStatistic> GetHockeyStatisticsById(int id)
        {
            return await HockeyStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<HockeyStatistic>> GetHockeyStatistic()
        {
            return await HockeyStatistics.ToListAsync();
        }

        public async Task<SoccerStatistic> GetSoccerStatisticsById(int id)
        {
            return await SoccerStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<SoccerStatistic>> GetSoccerStatistic()
        {
            return await SoccerStatistics.ToListAsync();
        }
    }
}
