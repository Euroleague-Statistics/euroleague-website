using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;

namespace WebAPI.Models
{
    public class Schedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? GameNumber { get; set; }
        public int? Round { get; set; }
        public DateTime? Date { get; set; }
        public string? Time { get; set; }
        public string Season { get; set; }
        public int? HomePoints { get; set; }
        public int? AwayPoints { get; set; }
        public StaticData.GameTypeEnum GamePhase { get; set; }
        public sbyte Status { get; set; }
        public DateTime Timestamp { get; set; }

        public Club? HomeClub { get; set; }
        public Club? AwayClub { get; set; }
    }
}
