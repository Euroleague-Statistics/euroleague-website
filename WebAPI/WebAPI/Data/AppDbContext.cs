using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<CountryCode> CountryCodes { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerInfo> PlayerInfos { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
