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
    public class SchedulesController : ControllerBase
    {
        private SchedulesService _scheduleService;

        public SchedulesController(SchedulesService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        // GET: api/Clubs
        [HttpGet("get-schedule")]
        public IActionResult GetSchedule()
        {
            var schedule = _scheduleService.GetSchedule();
            return Ok(schedule);
        }

        [HttpPost("add-match")]
        public IActionResult AddMatch([FromBody] ScheduleVM scheduleVM)
        {
            try
            {
                _scheduleService.AddMatch(scheduleVM);
                return Created(nameof(AddMatch), scheduleVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-match-by-id/{id}")]
        public IActionResult UpdateMatchById(int id, [FromBody] ScheduleVM countryCodeVM)
        {
            try
            {
                var updatedClub = _scheduleService.UpdateMatchById(id, countryCodeVM);
                return Ok(updatedClub);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-match-by-id/{id}")]
        public IActionResult GetMatchById(int id)
        {
            try
            {
                var club = _scheduleService.GetMatchById(id);
                return Ok(club);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-match-by-id/{id}")]
        public IActionResult DeleteMatchById(int id)
        {
            _scheduleService.DeleteMatchById(id);
            return Ok();
        }
    }
}
