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

        public CountryCode CountryCode { get; set; }
    }
}
