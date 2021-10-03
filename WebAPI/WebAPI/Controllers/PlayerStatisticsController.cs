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
    public class PlayerStatisticsController : ControllerBase
    {
        private PlayerStatisticsService _playerStatisticsService;

        public PlayerStatisticsController(PlayerStatisticsService playerStatisticsService)
        {
            _playerStatisticsService = playerStatisticsService;
        }


        [HttpGet("get-statistics-by-player-id/{id}")]
        public IActionResult GetStatisticsByPlayerId(Guid id)
        {
            try
            {
                var playerStatistics = _playerStatisticsService.GetPlayerStatisticsById(id);
                return Ok(playerStatistics);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-statistic-for-player-id/{id}")]
        public IActionResult AddStatisticForPlayerId(Guid id, [FromBody] PlayerStatisticVM playerStatisticVM)
        {
            try
            {
                _playerStatisticsService.AddStatisticForPlayerId(id, playerStatisticVM);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-statistics-for-player-id/{id}")]
        public IActionResult UpdateStatisticsForPlayerId(Guid id, [FromBody] PlayerStatisticVM playerStatisticVM)
        {
            try
            {
                var playerStatistics = _playerStatisticsService.UpdateStatisticsForPlayerId(id, playerStatisticVM);
                return Ok(playerStatistics);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-statistics-for-player-id/{id}")]
        public IActionResult DeletePlayerStatisticsById(Guid id)
        {
            try
            {
                _playerStatisticsService.DeletePlayerStatisticsById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
