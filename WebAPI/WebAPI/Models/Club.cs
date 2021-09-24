using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Club
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string ClubCode { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public sbyte Status { get; set; }
        public DateTime Timestamp { get; set; }
        public int? CountryCodeId { get; set; }

        public CountryCode CountryCode { get; set; }
        public List<PlayerInfo> PlayerInfos { get; set; }
        public List<PlayerStatistic> HomePlayerStatistics { get; set; }
        public List<PlayerStatistic> AwayPlayerStatistics { get; set; }
        public List<Schedule> HomeClubSchedule { get; set; }
        public List<Schedule> AwayClubSchedule { get; set; }
    }
}
