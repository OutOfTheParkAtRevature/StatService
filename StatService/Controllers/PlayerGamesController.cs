using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
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
        // GetPlayerGames
        /// <summary>
        /// return list of player games
        /// 
        /// </summary>
        /// <param name="none"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerGame>>> GetPlayerGames()
        {
            return await _context.PlayerGames.ToListAsync();
        }

        // GET: api/PlayerGames/5
        // GetPlayerGame by id
        /// <summary>
        /// return the player game that match the id
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerGame>> GetPlayerGame(Guid id)
        {
            var playerGame = await _context.PlayerGames.FindAsync(id);

            if (playerGame == null)
            {
                return NotFound();
            }

            return playerGame;
        }

        // PUT: api/PlayerGames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // Put PutPlayerGame
        /// <summary>
        /// return response status code: success, errors, or redirect
        /// 
        /// </summary>
        /// <param name="id, playerGame"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerGame(Guid id, PlayerGame playerGame)
        {
            if (id != playerGame.UserID)
            {
                return BadRequest();
            }

            _context.Entry(playerGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerGameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlayerGames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // Post PostPlayerGame
        /// <summary>
        /// return PlayerGame if post successed. 
        /// 
        /// </summary>
        /// <param name="playerGame"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PlayerGame>> PostPlayerGame(PlayerGame playerGame)
        {
            _context.PlayerGames.Add(playerGame);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerGameExists(playerGame.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerGame", new { id = playerGame.UserID }, playerGame);
        }

        // DELETE: api/PlayerGames/5
        // 
        /// <summary>
        /// return status response: success, errors, or redirect
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerGame(Guid id)
        {
            var playerGame = await _context.PlayerGames.FindAsync(id);
            if (playerGame == null)
            {
                return NotFound();
            }

            _context.PlayerGames.Remove(playerGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // PlayerGameExists
        /// <summary>
        /// return boolean value: true or false
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool PlayerGameExists(Guid id)
        {
            return _context.PlayerGames.Any(e => e.UserID == id);
        }
    }
}
