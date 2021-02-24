using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DataTransfer;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamGamesController : ControllerBase
    {

        private readonly StatsContext _context;
        private readonly Logic _logic;

        public TeamGamesController(StatsContext context, Logic logic)
        {
            _context = context;
            _logic = logic;
        }

        // GET: api/PlayerGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamGameStatDto>>> GetTeamGames()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return await _logic.GetAllTeamGameStats(token);
        }

        // GET: api/PlayerGames/5
        [HttpGet("{teamId}/{gameId}")]
        public async Task<ActionResult<TeamGameStatDto>> GetPlayerGame(Guid teamId, Guid gameId)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return await _logic.GetTeamGameStat(teamId, gameId, token);
        }

        [HttpPost]
        public async Task<ActionResult<TeamGameStatDto>> PostTeamGame([FromBody] CreateTeamGameDto createTeamGameDto)
        {

            return Ok(await _logic.CreateTeamStatistic(createTeamGameDto.TeamID, createTeamGameDto.GameID, createTeamGameDto.BaseballStatistic));
        }
    }
}
