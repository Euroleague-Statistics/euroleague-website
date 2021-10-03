using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryCodeController : ControllerBase
    {
        private CountryCodesService _countryCodesService;

        public CountryCodeController(CountryCodesService countryCodesService)
        {
            _countryCodesService = countryCodesService;
        }

        // GET: api/Clubs
        [HttpGet("get-countries")]
        public IActionResult GetCountries()
        {
            var countries = _countryCodesService.GetCountries();
            return Ok(countries);
        }

        [HttpPost("add-country")]
        public IActionResult AddCountry([FromBody] CountryCodeVM countryCodeVM)
        {
            try
            {
                _countryCodesService.AddCountry(countryCodeVM);
                return Created(nameof(AddCountry), countryCodeVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-country-by-id/{id}")]
        public IActionResult UpdateCountryById(int id, [FromBody] CountryCodeVM countryCodeVM)
        {
            try
            {
                var updatedClub = _countryCodesService.UpdateCountryById(id, countryCodeVM);
                return Ok(updatedClub);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-country-by-id/{id}")]
        public IActionResult GetCountryById(int id)
        {
            var club = _countryCodesService.GetCountryById(id);
            return Ok(club);
        }

        [HttpDelete("delete-country-by-id/{id}")]
        public IActionResult DeleteCountryById(int id)
        {
            _countryCodesService.DeleteCountryById(id);
            return Ok();
        }
    }
}
