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

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private ClubsService _clubsService;

        public ClubsController(ClubsService clubsService)
        {
            _clubsService = clubsService;
        }

        // GET: api/Clubs
        [HttpGet("get-clubs")]
        public IActionResult GetClubs()
        {
            var clubs = _clubsService.GetClubs();
            return Ok(clubs);
        }

        [HttpGet("get-club-by-id/{id}")]
        public IActionResult GetClubById(Guid id)
        {
            var club = _clubsService.GetClubById(id);
            return Ok(club);
        }

        [HttpGet("get-club-by-code/{code}")]
        public IActionResult GetClubByClubCode(string code)
        {
            var club = _clubsService.GetClubByClubCode(code);
            return Ok(club);
        }

        [HttpGet("get-club-by-name/{name}")]
        public IActionResult GetClubByClubName(string name)
        {
            var club = _clubsService.GetClubByClubName(name);
            return Ok(club);
        }
    }
}
