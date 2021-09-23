using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class PlayerVM
    {
        public string PCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public decimal? Height { get; set; }
        public sbyte Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string CountryCode2 { get; set; }
        public string CountryCode3 { get; set; }
        public string CountryName { get; set; }
        public ICollection<PlayerInfoVM> PlayerInfo { get; set; }
    }
}
