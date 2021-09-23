using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class PlayerInfoVM
    {
        public decimal? uPER { get; set; }
        public decimal? aPER { get; set; }
        public decimal? PER { get; set; }
        public int? GamesPlayed { get; set; }
        public string Number { get; set; }
        public string Position { get; set; }
        public sbyte Status { get; set; }
        public string Club { get; set; }
        public Guid ClubId { get; set; }
    }
}
