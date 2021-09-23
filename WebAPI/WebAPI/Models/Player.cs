using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string PCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public decimal? Height { get; set; }
        public sbyte Status { get; set; }
        public DateTime Timestamp { get; set; }

        public CountryCode CountryCode { get; set; }
        public ICollection<PlayerInfo> PlayerInfo { get; set; }

    }
}
