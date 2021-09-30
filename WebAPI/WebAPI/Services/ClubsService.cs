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

                var countryCode = _context.CountryCodes.FirstOrDefault(c => c.Id == club.CountryCodeId);
                if (countryCode == null)
                {
                    throw new Exception("Country Not Found");
                }

                clubVM.CountryCode2 = countryCode.Code2;
                clubVM.CountryCode3 = countryCode.Code3;
                clubVM.CountryName = countryCode.Name;
                clubVMs.Add(clubVM);      
            }

            return clubVMs;
        }

        public Club AddClubWithId(ClubVM clubVM)
        {
            var countryCode = _context.CountryCodes.FirstOrDefault(c => c.Code3 == clubVM.CountryCode3);
            if (countryCode == null)
            {
                throw new Exception("Country Not Found");
            }

            var _club = new Club()
            {
                ClubCode = clubVM.ClubCode,
                Name = clubVM.Name,
                City = clubVM.City,
                CountryCode = countryCode,
                CountryCodeId = countryCode.Id
            };

            _context.Clubs.Add(_club);
            _context.SaveChanges();

            return _club;         
        }

        public void DeleteClubById(Guid id)
        {
            var club = _context.Clubs.FirstOrDefault(c => c.Id == id);
            if (club != null)
            {
                _context.Clubs.Remove(club);
                _context.SaveChanges();
            }
        }

        public Club UpdateClubById(Guid id, ClubVM clubVM)
        {
            var club = _context.Clubs.FirstOrDefault(n => n.Id == id);
            if (club != null)
            {
                var countryCode = _context.CountryCodes.FirstOrDefault(c => c.Code3 == clubVM.CountryCode3);
                if (countryCode == null)
                {
                    throw new Exception("Country Not Found");
                }

                club.ClubCode = clubVM.ClubCode;
                club.Name = clubVM.Name;
                club.City = clubVM.City;
                club.CountryCode = countryCode;
                club.CountryCodeId = countryCode.Id;
                _context.SaveChanges();
            }

            return club;
        }

        public ClubVM GetClubById(Guid id)
        {
            ClubVM clubVM = new ClubVM();

            var club = _context.Clubs.FirstOrDefault(club => club.Id == id);
            if (club != null)
            {
                var countryCode = _context.CountryCodes.FirstOrDefault(c => c.Id == club.CountryCodeId);
                if (countryCode == null)
                {
                    throw new Exception("CountryCode not found!");
                }
                
                clubVM.Name = club.Name;
                clubVM.City = club.City;
                clubVM.ClubCode = club.ClubCode;
                clubVM.CountryCode2 = countryCode.Code2;
                clubVM.CountryCode3 = countryCode.Code3;
                clubVM.CountryName = countryCode.Name;
            }

            return clubVM;
        }

        public ClubVM GetClubByClubCode(string code)
        {
            ClubVM clubVM = new ClubVM();

            var club = _context.Clubs.FirstOrDefault(club => club.ClubCode == code);
            if (club != null)
            {

                var countryCode = _context.CountryCodes.FirstOrDefault(c => c.Id == club.CountryCodeId);
                if (countryCode == null)
                {
                    throw new Exception("CountryCode not found!");
                }

                clubVM.Name = club.Name;
                clubVM.City = club.City;
                clubVM.ClubCode = club.ClubCode;
                clubVM.CountryCode2 = countryCode.Code2;
                clubVM.CountryCode3 = countryCode.Code3;
                clubVM.CountryName = countryCode.Name;                
            }

            return clubVM;
        }

        public ClubVM GetClubByClubName(string name)
        {
            ClubVM clubVM = new ClubVM();

            var club = _context.Clubs.FirstOrDefault(club => club.Name == name);
            if (club != null)
            {
                var countryCode = _context.CountryCodes.FirstOrDefault(c => c.Id == club.CountryCodeId);
                if (countryCode == null)
                {
                    throw new Exception("CountryCode not found!");
                }

                clubVM.Name = club.Name;
                clubVM.City = club.City;
                clubVM.ClubCode = club.ClubCode;
                clubVM.CountryCode2 = countryCode.Code2;
                clubVM.CountryCode3 = countryCode.Code3;
                clubVM.CountryName = countryCode.Name;        
            }

            return clubVM;
        }
    }
}
