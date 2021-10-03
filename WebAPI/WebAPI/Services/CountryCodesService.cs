using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Services
{
    public class CountryCodesService
    {
        private AppDbContext _context;

        public CountryCodesService(AppDbContext context)
        {
            _context = context;
        }

        public void AddCountry(CountryCodeVM countryCodeVM)
        {
            var countryCode = new CountryCode()
            {
                Code2 = countryCodeVM.Code2,
                Code3 = countryCodeVM.Code3,
                Name = countryCodeVM.Name,
                Status = 1,
                Timestamp = DateTime.Now
            };
            _context.CountryCodes.Add(countryCode);
            _context.SaveChanges();
        }

        public CountryCodeVM GetCountryById(int id)
        {
            CountryCodeVM countryCodeVM = new CountryCodeVM();

            var countryCode = _context.CountryCodes.FirstOrDefault(m => m.Id == id);
            if (countryCode != null)
            {
                countryCodeVM.Code2 = countryCode.Code2;
                countryCodeVM.Code3 = countryCode.Code3;
                countryCodeVM.Name = countryCode.Name;
            }

            return countryCodeVM;
        }

        public List<CountryCode> GetCountries()
        {
            return _context.CountryCodes.ToList();
        }

        public CountryCode UpdateCountryById(int id, CountryCodeVM countryCodeVM)
        {
            var countryCode = _context.CountryCodes.FirstOrDefault(n => n.Id == id);
            if (countryCode != null)
            {
                countryCode.Code3 = countryCodeVM.Code3;
                countryCode.Code2 = countryCodeVM.Code3;
                countryCode.Name = countryCodeVM.Name;
                countryCode.Timestamp = DateTime.Now;

                _context.SaveChanges();
            }

            return countryCode;
        }

        public void DeleteCountryById(int id)
        {
            var countryCode = _context.CountryCodes.FirstOrDefault(cc => cc.Id == id);
            if (countryCode != null)
            {
                _context.CountryCodes.Remove(countryCode);
                _context.SaveChanges();
            }
        }
    }
}
