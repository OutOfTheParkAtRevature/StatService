using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Repository;

namespace Repopository
{
    public class Repo
    {
        private readonly StatsContext _StatsContext;
        private readonly ILogger _logger;
        public DbSet<BaseballStatistic> baseballStatistics;
        public DbSet<BasketballStatistic> basketballStatistics;
        public DbSet<FootBallStatistic> footBallStatistics;
        public DbSet<GolfStatistic> golfStatistics;
        public DbSet<HockeyStatistic> hockeyStatistics;
        public DbSet<SoccerStatistic> soccerStatistics;

        public Repo(StatsContext teamContext, ILogger<Repo> logger)
        {
            _StatsContext = teamContext;
            _logger = logger;
            this.baseballStatistics = _StatsContext.baseballStatistics;
            this.basketballStatistics = _StatsContext.basketballStatistics;
            this.footBallStatistics = _StatsContext.footBallStatistics;
            this.golfStatistics = _StatsContext.golfStatistics;
            this.hockeyStatistics = _StatsContext.hockeyStatistics;
            this.soccerStatistics = _StatsContext.soccerStatistics;
        }

        public async Task CommitSave()
        {
            await _StatsContext.SaveChangesAsync();
        }

        public async Task<BaseballStatistic> GetBaseballStatisticsById(int id)
        {
            return await baseballStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<BaseballStatistic>> GetBaseballStatistics()
        {
            return await baseballStatistics.ToListAsync();
        }


        public async Task<BasketballStatistic> GetBasketballStatisticsById(int id)
        {
            return await basketballStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<BasketballStatistic>> GetBasketballStatistic()
        {
            return await basketballStatistics.ToListAsync();
        }

        public async Task<FootBallStatistic> GetFootBallStatisticsById(int id)
        {
            return await footBallStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<FootBallStatistic>> GetFootBallStatistic()
        {
            return await footBallStatistics.ToListAsync();
        }
        public async Task<GolfStatistic> GetGolfStatisticsById(int id)
        {
            return await golfStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<GolfStatistic>> GetGolfStatistic()
        {
            return await golfStatistics.ToListAsync();
        }
        public async Task<HockeyStatistic> GetHockeyStatisticsById(int id)
        {
            return await hockeyStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<HockeyStatistic>> GetHockeyStatistic()
        {
            return await hockeyStatistics.ToListAsync();
        }

        public async Task<SoccerStatistic> GetSoccerStatisticsById(int id)
        {
            return await soccerStatistics.FindAsync(id);
        }
        public async Task<IEnumerable<SoccerStatistic>> GetSoccerStatistic()
        {
            return await soccerStatistics.ToListAsync();
        }
    }
}
