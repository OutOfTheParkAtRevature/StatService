using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DataTransfer;
using Repository;
using Service;

namespace StatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerGamesController : ControllerBase
    {
        private readonly StatsContext _context;
        private readonly Logic _logic;

        public PlayerGamesController(StatsContext context, Logic logic)
        {
            _context = context;
            _logic = logic;
        }

        // GET: api/PlayerGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerGameStatDto>>> GetPlayerGames()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return await _logic.GetAllPlayerGameStats(token);
        }

        // GET: api/PlayerGames/5
        [HttpGet("{userId}/{gameId}")]
        public async Task<ActionResult<PlayerGameStatDto>> GetPlayerGame(string userId, Guid gameId)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return await _logic.GetPlayerGameStat(userId, gameId, token);
        }

        //// PUT: api/PlayerGames/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPlayerGame(Guid id, PlayerGame playerGame)
        //{
        //    if (id != playerGame.UserID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(playerGame).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlayerGameExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/PlayerGames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerGameStatDto>> PostPlayerGame([FromBody]CreatePlayerGameDto createPlayerGameDto)
        {

            return Ok(await _logic.CreateStatistic(createPlayerGameDto.playerId, createPlayerGameDto.gameId, createPlayerGameDto.baseballStatistic));
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (PlayerGameExists(playerGame.UserID))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
        }

        //// DELETE: api/PlayerGames/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePlayerGame(string id)
        //{
        //    var playerGame = await _context.PlayerGames.FindAsync(id);
        //    if (playerGame == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.PlayerGames.Remove(playerGame);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PlayerGameExists(Guid id)
        //{
        //    return _context.PlayerGames.Any(e => e.UserID == id);
        //}
    }
}
