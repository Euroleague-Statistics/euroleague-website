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

        public void AddStatisticForPlayerId(Guid id, PlayerStatisticVM playerStatisticVM)
        {
            var player = _context.Players.ToList().FindAll(p => p.Id == id);
            if (player == null)
            {
                throw new Exception("player not found!");
            }

            PlayerStatistic playerStatistic = new PlayerStatistic();

            playerStatistic.WL = playerStatisticVM.WL;
            playerStatistic.Game = playerStatisticVM.Game;
            playerStatistic.Starter = playerStatisticVM.Starter;
            playerStatistic.Round = playerStatisticVM.Round;
            playerStatistic.HomeOrAway = playerStatisticVM.HomeOrAway;
            playerStatistic.Min = playerStatisticVM.Min;
            playerStatistic.MinDecimal = playerStatisticVM.MinDecimal;
            playerStatistic.PTS = playerStatisticVM.PTS;
            playerStatistic.FGA = playerStatisticVM.FGA;
            playerStatistic.FG = playerStatisticVM.FG;
            playerStatistic.FGP = playerStatisticVM.FGP;
            playerStatistic.FG2A = playerStatisticVM.FG2A;
            playerStatistic.FG2 = playerStatisticVM.FG2;
            playerStatistic.FG2P = playerStatisticVM.FG2P;
            playerStatistic.FG3A = playerStatisticVM.FG3A;
            playerStatistic.FG3 = playerStatisticVM.FG3;
            playerStatistic.FG3P = playerStatisticVM.FG3P;
            playerStatistic.FTA = playerStatisticVM.FTA;
            playerStatistic.FT = playerStatisticVM.FT;
            playerStatistic.FTP = playerStatisticVM.FTP;
            playerStatistic.ORB = playerStatisticVM.ORB;
            playerStatistic.DRB = playerStatisticVM.DRB;
            playerStatistic.TRB = playerStatisticVM.TRB;
            playerStatistic.AST = playerStatisticVM.AST;
            playerStatistic.STL = playerStatisticVM.STL;
            playerStatistic.TOV = playerStatisticVM.TOV;
            playerStatistic.BLK = playerStatisticVM.BLK;
            playerStatistic.BAG = playerStatisticVM.BAG;
            playerStatistic.FLC = playerStatisticVM.FLC;
            playerStatistic.FLA = playerStatisticVM.FLA;
            playerStatistic.DNP = playerStatisticVM.DNP;
            playerStatistic.Season = playerStatisticVM.Season;

            var homeClub = _context.Clubs.FirstOrDefault(c => c.Id == playerStatisticVM.HomeClubId);
            if (homeClub != null)
            {
                playerStatistic.HomeClubId = homeClub.Id;
                playerStatistic.HomeClub = homeClub;
            }

            var awayClub = _context.Clubs.FirstOrDefault(c => c.Id == playerStatisticVM.AwayClubId);
            if (awayClub != null)
            {
                playerStatistic.AwayClubId = awayClub.Id;
                playerStatistic.AwayClub = awayClub;
            }

            _context.PlayerStatistics.Add(playerStatistic);
            _context.SaveChanges();      
        }

        public PlayerStatistic UpdateStatisticsForPlayerId(Guid id, PlayerStatisticVM playerStatisticVM)
        {
            var player = _context.Players.ToList().FindAll(p => p.Id == id);
            if (player == null)
            {
                throw new Exception("player not found!");
            }
            else
            {
                var playerStatistic = _context.PlayerStatistics.FirstOrDefault(player => player.Player.Id == id);
                
                if (playerStatistic == null)
                {
                    throw new Exception("player statistic not found!");
                }

                playerStatistic.WL = playerStatisticVM.WL;
                playerStatistic.Game = playerStatisticVM.Game;
                playerStatistic.Starter = playerStatisticVM.Starter;
                playerStatistic.Round = playerStatisticVM.Round;
                playerStatistic.HomeOrAway = playerStatisticVM.HomeOrAway;
                playerStatistic.Min = playerStatisticVM.Min;
                playerStatistic.MinDecimal = playerStatisticVM.MinDecimal;
                playerStatistic.PTS = playerStatisticVM.PTS;
                playerStatistic.FGA = playerStatisticVM.FGA;
                playerStatistic.FG = playerStatisticVM.FG;
                playerStatistic.FGP = playerStatisticVM.FGP;
                playerStatistic.FG2A = playerStatisticVM.FG2A;
                playerStatistic.FG2 = playerStatisticVM.FG2;
                playerStatistic.FG2P = playerStatisticVM.FG2P;
                playerStatistic.FG3A = playerStatisticVM.FG3A;
                playerStatistic.FG3 = playerStatisticVM.FG3;
                playerStatistic.FG3P = playerStatisticVM.FG3P;
                playerStatistic.FTA = playerStatisticVM.FTA;
                playerStatistic.FT = playerStatisticVM.FT;
                playerStatistic.FTP = playerStatisticVM.FTP;
                playerStatistic.ORB = playerStatisticVM.ORB;
                playerStatistic.DRB = playerStatisticVM.DRB;
                playerStatistic.TRB = playerStatisticVM.TRB;
                playerStatistic.AST = playerStatisticVM.AST;
                playerStatistic.STL = playerStatisticVM.STL;
                playerStatistic.TOV = playerStatisticVM.TOV;
                playerStatistic.BLK = playerStatisticVM.BLK;
                playerStatistic.BAG = playerStatisticVM.BAG;
                playerStatistic.FLC = playerStatisticVM.FLC;
                playerStatistic.FLA = playerStatisticVM.FLA;
                playerStatistic.DNP = playerStatisticVM.DNP;
                playerStatistic.Season = playerStatisticVM.Season;

                var homeClub = _context.Clubs.FirstOrDefault(c => c.Id == playerStatisticVM.HomeClubId);
                if (homeClub != null)
                {
                    playerStatistic.HomeClubId = homeClub.Id;
                    playerStatistic.HomeClub = homeClub;
                }

                var awayClub = _context.Clubs.FirstOrDefault(c => c.Id == playerStatisticVM.AwayClubId);
                if (awayClub != null)
                {
                    playerStatistic.AwayClubId = awayClub.Id;
                    playerStatistic.AwayClub = awayClub;
                }

                _context.PlayerStatistics.Add(playerStatistic);
                _context.SaveChanges();

                return playerStatistic;
            }
        }

        public void DeletePlayerStatisticsById(Guid id)
        {
            var playerStatistics = _context.PlayerStatistics.FirstOrDefault(p => p.Id == id);
            if (playerStatistics != null)
            {
                _context.PlayerStatistics.Remove(playerStatistics);
                _context.SaveChanges();
            }

        }
    }
}
