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
        public DbSet<BaseballStatistic> BaseballStatistics { get; set; }
        public DbSet<BasketballStatistic> BasketballStatistics { get; set; }
        public DbSet<FootBallStatistic> FootballStatistics { get; set; }
        public DbSet<GolfStatistic> GolfStatistics { get; set; }
        public DbSet<HockeyStatistic> HockeyStatistics { get; set; }
        public DbSet<SoccerStatistic> SoccerStatistics { get; set; }
        public DbSet<PlayerGame> PlayerGames { get; set; }
        public DbSet<TeamGame> TeamGames { get; set; }

        public StatsContext() { }
        public StatsContext(DbContextOptions<StatsContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=LeagueDB;Trusted_Connection = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerGame>()
                .HasKey(p => new { p.UserID, p.GameID });
            modelBuilder.Entity<TeamGame>()
                .HasKey(p => new { p.TeamID, p.GameID });
        }
    }
}
