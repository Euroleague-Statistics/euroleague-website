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
            modelBuilder.Entity<Club>().HasMany(c => c.HomePlayerStatistics)
                .WithOne(ps => ps.HomeClub)
                .HasForeignKey(ps => ps.HomeClubId);

            modelBuilder.Entity<Club>().HasMany(c => c.AwayPlayerStatistics)
                .WithOne(ps => ps.AwayClub)
                .HasForeignKey(ps => ps.AwayClubId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Club>().HasMany(c => c.HomeClubSchedule)
                .WithOne(s => s.HomeClub)
                .HasForeignKey(s => s.HomeClubId);

            modelBuilder.Entity<Club>().HasMany(c => c.AwayClubSchedule)
                .WithOne(s => s.AwayClub)
                .HasForeignKey(s => s.AwayClubId).OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<CountryCode> CountryCodes { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerInfo> PlayerInfos { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
