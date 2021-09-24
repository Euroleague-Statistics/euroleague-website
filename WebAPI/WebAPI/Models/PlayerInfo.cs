using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class PlayerInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public decimal? uPER { get; set; }
        public decimal? aPER { get; set; }
        public decimal? PER { get; set; }
        public int? GamesPlayed { get; set; }
        public string Number { get; set; }
        public string Position { get; set; }
        public sbyte Status { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid? ClubId { get; set; }
        public Guid? PlayerId { get; set; }

        public Club Club { get; set; }
        public Player Player { get; set; }
    }
}
