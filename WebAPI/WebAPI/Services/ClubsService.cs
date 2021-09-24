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
                if (countryCode != null)
                {
                    clubVM.CountryCode2 = countryCode.Code2;
                    clubVM.CountryCode3 = countryCode.Code3;
                    clubVM.CountryName = countryCode.Name;
                }

                clubVMs.Add(clubVM);
            }

            return clubVMs;
        }

        public Club AddClubWithId(ClubVM clubVM)
        {
            var _club = new Club()
            {
                ClubCode = clubVM.ClubCode,
                Name = clubVM.Name,
                City = clubVM.City
            };

            var countryCode = _context.CountryCodes.FirstOrDefault(c => c.Code3 == clubVM.CountryCode3);
            if (countryCode == null)
            {
                // throw new Exception("Country Not Found");
                CountryCode _countryCode = new CountryCode();
                _countryCode.Code2 = clubVM.CountryCode2;
                _countryCode.Code3 = clubVM.CountryCode3;
                _countryCode.Name = clubVM.CountryName;
                _countryCode.Status = 1;
                _countryCode.Timestamp = DateTime.Now;

                _club.CountryCode = _countryCode;
                _club.CountryCodeId = _countryCode.Id;
                _context.CountryCodes.Add(_countryCode);
            }
            else
            {
                _club.CountryCode = countryCode;
                _club.CountryCodeId = countryCode.Id;
            }

            _context.Clubs.Add(_club);
            _context.SaveChanges();

            return _club;
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

                var countryCode = _context.CountryCodes.FirstOrDefault(c => c.Id == club.CountryCodeId);
                if (countryCode != null)
                {
                    clubVM.CountryCode2 = countryCode.Code2;
                    clubVM.CountryCode3 = countryCode.Code3;
                    clubVM.CountryName = countryCode.Name;
                }
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

                var countryCode = _context.CountryCodes.FirstOrDefault(c => c.Id == club.CountryCodeId);
                if (countryCode != null)
                {
                    clubVM.CountryCode2 = countryCode.Code2;
                    clubVM.CountryCode3 = countryCode.Code3;
                    clubVM.CountryName = countryCode.Name;
                }
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

                var countryCode = _context.CountryCodes.FirstOrDefault(c => c.Id == club.CountryCodeId);
                if (countryCode != null)
                {
                    clubVM.CountryCode2 = countryCode.Code2;
                    clubVM.CountryCode3 = countryCode.Code3;
                    clubVM.CountryName = countryCode.Name;
                }
            }

            return clubVM;
        }
    }
}
