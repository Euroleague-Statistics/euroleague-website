using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;

namespace WebAPI.ViewModels
{
    public class PlayerStatisticVM
    {
        public string WL { get; set; }
        public string Game { get; set; }
        public int? Starter { get; set; }
        public string Round { get; set; }
        public string HomeOrAway { get; set; }
        public string Min { get; set; }
        public decimal? MinDecimal { get; set; }
        public int? PTS { get; set; }
        public int? FGA { get; set; }
        public int? FG { get; set; }
        public decimal? FGP { get; set; }
        public int? FG2A { get; set; }
        public int? FG2 { get; set; }
        public decimal? FG2P { get; set; }
        public int? FG3A { get; set; }
        public int? FG3 { get; set; }
        public decimal? FG3P { get; set; }
        public int? FTA { get; set; }
        public int? FT { get; set; }
        public decimal? FTP { get; set; }
        public int? ORB { get; set; }
        public int? DRB { get; set; }
        public int? TRB { get; set; }
        public int? AST { get; set; }
        public int? STL { get; set; }
        public int? TOV { get; set; }
        public int? BLK { get; set; }
        public int? BAG { get; set; }
        public int? FLC { get; set; }
        public int? FLA { get; set; }
        public StaticData.GameTypeEnum Playoff { get; set; }
        public DateTime? DatePlayed { get; set; }
        public string DNP { get; set; }
        public string Season { get; set; }
        public sbyte Status { get; set; }
        public DateTime Timestamp { get; set; }

        public Guid HomeClubId { get; set; }
        public string HomeClubName { get; set; }
        public Guid AwayClubId { get; set; }
        public string AwayClubName { get; set; }
    }
}
