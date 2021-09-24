using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class CountryCode
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        public string Name { get; set; }
        public sbyte Status { get; set; }
        public DateTime Timestamp { get; set; }

        public List<Club> Clubs { get; set; }
        public List<Player> Players { get; set; }
    }
}
