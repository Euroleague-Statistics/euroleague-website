using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Services
{
    public class PlayerStatisticsService
    {
        private AppDbContext _context;

        public PlayerStatisticsService(AppDbContext context)
        {
            _context = context;
        }

        public List<PlayerStatisticVM> GetPlayerStatisticsById(Guid id)
        {
            List<PlayerStatisticVM> playerStatisticsVM = new List<PlayerStatisticVM>();

            var playerStatistics = _context.PlayerStatistics.ToList().FindAll(player => player.Player.Id == id);
            if (playerStatistics.Count > 0 && playerStatistics != null)
            {
                foreach (var playerStatistic in playerStatistics)
                {
                    PlayerStatisticVM playerStatisticVM = new PlayerStatisticVM();

                    playerStatisticVM.WL = playerStatistic.WL;
                    playerStatisticVM.Game = playerStatistic.Game;
                    playerStatisticVM.Starter = playerStatistic.Starter;
                    playerStatisticVM.Round = playerStatistic.Round;
                    playerStatisticVM.HomeOrAway = playerStatistic.HomeOrAway;
                    playerStatisticVM.Min = playerStatistic.Min;
                    playerStatisticVM.MinDecimal = playerStatistic.MinDecimal;
                    playerStatisticVM.PTS = playerStatistic.PTS;
                    playerStatisticVM.FGA = playerStatistic.FGA;
                    playerStatisticVM.FG = playerStatistic.FG;
                    playerStatisticVM.FGP = playerStatistic.FGP;
                    playerStatisticVM.FG2A = playerStatistic.FG2A;
                    playerStatisticVM.FG2 = playerStatistic.FG2;
                    playerStatisticVM.FG2P = playerStatistic.FG2P;
                    playerStatisticVM.FG3A = playerStatistic.FG3A;
                    playerStatisticVM.FG3 = playerStatistic.FG3;
                    playerStatisticVM.FG3P = playerStatistic.FG3P;
                    playerStatisticVM.FTA = playerStatistic.FTA;
                    playerStatisticVM.FT = playerStatistic.FT;
                    playerStatisticVM.FTP = playerStatistic.FTP;
                    playerStatisticVM.ORB = playerStatistic.ORB;
                    playerStatisticVM.DRB = playerStatistic.DRB;
                    playerStatisticVM.TRB = playerStatistic.TRB;
                    playerStatisticVM.AST = playerStatistic.AST;
                    playerStatisticVM.STL = playerStatistic.STL;
                    playerStatisticVM.TOV = playerStatistic.TOV;
                    playerStatisticVM.BLK = playerStatistic.BLK;
                    playerStatisticVM.BAG = playerStatistic.BAG;
                    playerStatisticVM.FLC = playerStatistic.FLC;
                    playerStatisticVM.FLA = playerStatistic.FLA;
                    playerStatisticVM.DNP = playerStatistic.DNP;
                    playerStatisticVM.Season = playerStatistic.Season;

                    var homeClub = _context.PlayerStatistics.FirstOrDefault(m => m.HomeClubId == playerStatistic.HomeClub.Id);
                    if (homeClub != null)
                    {
                        playerStatisticVM.HomeClubId = playerStatistic.HomeClub.Id;
                        playerStatisticVM.HomeClubName = playerStatistic.HomeClub.Name;
                    }

                    var awayClub = _context.PlayerStatistics.FirstOrDefault(m => m.AwayClubId == playerStatistic.AwayClub.Id);
                    if (awayClub != null)
                    {
                        playerStatisticVM.AwayClubId = playerStatistic.AwayClub.Id;
                        playerStatisticVM.AwayClubName = playerStatistic.AwayClub.Name;
                    }

                    playerStatisticsVM.Add(playerStatisticVM);
                }

            }

            return playerStatisticsVM;
        }
    }
}
