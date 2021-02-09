using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class StatsContext : DbContext
    {
        public DbSet<BaseballStatistic> baseballStatistics { get; set; }
        public DbSet<BasketballStatistic> basketballStatistics { get; set; }
        public DbSet<FootBallStatistic> footBallStatistics { get; set; }
        public DbSet<GolfStatistic> golfStatistics { get; set; }
        public DbSet<HockeyStatistic> hockeyStatistics { get; set; }
        public DbSet<SoccerStatistic> soccerStatistics { get; set; }

        public StatsContext() { }
        public StatsContext(DbContextOptions<StatsContext> options) : base(options) { }
    }
}
