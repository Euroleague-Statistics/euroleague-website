using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Services
{
    public class ClubsService
    {
        private AppDbContext _context;

        public ClubsService(AppDbContext context)
        {
            _context = context;
        }

        public List<ClubVM> GetClubs()
        {
            var clubVMs = new List<ClubVM>();

            var clubs = _context.Clubs.ToList();
            foreach (var club in clubs)
            {
                ClubVM clubVM = new ClubVM();
                clubVM.Name = club.Name;
                clubVM.City = club.City;
                clubVM.ClubCode = club.ClubCode;

                clubVM.CountryCode2 = club.CountryCode.Code2;
                clubVM.CountryCode3 = club.CountryCode.Code3;
                clubVM.CountryName = club.CountryCode.Name;

                clubVMs.Add(clubVM);
            }

            return clubVMs;
        }

        public ClubVM GetClubById(Guid id)
        {
            ClubVM clubVM = new ClubVM();

            var club = _context.Clubs.FirstOrDefault(club => club.Id == id);
            if (club != null)
            {
                clubVM.Name = club.Name;
                clubVM.City = club.City;
                clubVM.ClubCode = club.ClubCode;

                clubVM.CountryCode2 = club.CountryCode.Code2;
                clubVM.CountryCode3 = club.CountryCode.Code3;
                clubVM.CountryName = club.CountryCode.Name;
            }

            return clubVM;
        }

        public ClubVM GetClubByClubCode(string code)
        {
            ClubVM clubVM = new ClubVM();

            var club = _context.Clubs.FirstOrDefault(club => club.ClubCode == code);
            if (club != null)
            {
                clubVM.Name = club.Name;
                clubVM.City = club.City;
                clubVM.ClubCode = club.ClubCode;

                clubVM.CountryCode2 = club.CountryCode.Code2;
                clubVM.CountryCode3 = club.CountryCode.Code3;
                clubVM.CountryName = club.CountryCode.Name;
            }

            return clubVM;
        }

        public ClubVM GetClubByClubName(string name)
        {
            ClubVM clubVM = new ClubVM();

            var club = _context.Clubs.FirstOrDefault(club => club.Name == name);
            if (club != null)
            {
                clubVM.Name = club.Name;
                clubVM.City = club.City;
                clubVM.ClubCode = club.ClubCode;

                clubVM.CountryCode2 = club.CountryCode.Code2;
                clubVM.CountryCode3 = club.CountryCode.Code3;
                clubVM.CountryName = club.CountryCode.Name;
            }

            return clubVM;
        }
    }
}
