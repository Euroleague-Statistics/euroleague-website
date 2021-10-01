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
    public class PlayersController : ControllerBase
    {
        private PlayersService _playersService;
        //private PlayerStatisticsService _playerStatisticsService;

        public PlayersController(PlayersService playersService/*, PlayerStatisticsService playerStatisticsService*/)
        {
            _playersService = playersService;
            //_playerStatisticsService = playerStatisticsService;
        }

        // GET: api/Clubs
        [HttpGet("get-players")]
        public IActionResult GetPlayers()
        {
            var players = _playersService.GetPlayers();
            return Ok(players);
        }

        [HttpGet("get-player-by-id/{id}")]
        public IActionResult GetPlayerById(Guid id)
        {
            var player = _playersService.GetPlayerById(id);
            return Ok(player);
        }

        [HttpGet("get-player-by-code/{code}")]
        public IActionResult GetPlayerByPlayerCode(string pcode)
        {
            var player = _playersService.GetPlayerByPlayerCode(pcode);
            return Ok(player);
        }

        [HttpGet("get-player-by-name/{name}")]
        public IActionResult GetPlayerByName(string name)
        {
            var player = _playersService.GetPlayerByPlayerName(name);
            return Ok(player);
        }

        [HttpGet("get-player-by-surname/{surname}")]
        public IActionResult GetPlayerBySurname(string surname)
        {
            var player = _playersService.GetPlayerByPlayerSurname(surname);
            return Ok(player);
        }

        //[HttpGet("get-statistics-by-player-id/{id}")]
        //public IActionResult GetStatisticsByPlayerId(Guid id)
        //{
        //    var playerStatistics = _playerStatisticsService.GetPlayerStatisticsById(id);
        //    return Ok(playerStatistics);
        //}

        [HttpPost("add-player")]
        public IActionResult AddPlayer([FromBody] PlayerVM playerVM)
        {
            try
            {
                _playersService.AddPlayer(playerVM);
                return Created(nameof(AddPlayer), playerVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-player-by-id/{id}")]
        public IActionResult UpdateCountryById(Guid id, [FromBody] PlayerVM playerVM)
        {
            try
            {
                var updatedClub = _playersService.UpdatePlayerById(id, playerVM);
                return Ok(updatedClub);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-player-by-id/{id}")]
        public IActionResult DeletePlayerById(Guid id)
        {
            try
            {
                _playersService.DeletePlayerById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
