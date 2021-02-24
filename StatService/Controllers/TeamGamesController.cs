using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;
using Service;

namespace StatService.Controllers
{
    public class TeamGamesController : ControllerBase
    {
        private readonly StatsContext _context;
        private readonly Logic _logic;

        public TeamGamesController(StatsContext context, Logic logic)
        {
            _context = context;
            _logic = logic;
        }

        // GET: api/TeamGames
        // GetTeamGames
        /// <summary>
        /// return list of team games
        /// 
        /// </summary>
        /// <param name="none"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamGame>>> GetTeamGames()
        {
            return await _context.TeamGames.ToListAsync();
        }

        // GET: api/PlayerGames/5
        // GetPlayerGame by id
        /// <summary>
        /// return the player game that match the id
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{teamId}/{gameId}")]
        public async Task<ActionResult<BaseballStatistic>> GetTeamGame(Guid teamId, Guid gameId)
        {
            return await _logic.GetBaseballGameStatistic(teamId, gameId);
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
        public async Task<IActionResult> PutTeamGame(Guid id, TeamGame teamGame)
        {
            if (id != teamGame.TeamID)
            {
                return BadRequest();
            }

            _context.Entry(teamGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamGameExists(id))
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

        // POST: api/TeamGames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // Post PostTeamGame
        /// <summary>
        /// return TeamGame if post successed. 
        /// 
        /// </summary>
        /// <param name="playerGame"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseballStatistic>> PostTeamGame(Guid teamId, Guid gameId, BaseballStatistic baseballStatistic)
        {
            return await _logic.CreateTeamStatistic(teamId, gameId, baseballStatistic);
        }

        // DELETE: api/TeamGames/5
        // 
        /// <summary>
        /// return status response: success, errors, or redirect
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamGame(Guid id)
        {
            var teamGame = await _context.TeamGames.FindAsync(id);
            if (teamGame == null)
            {
                return NotFound();
            }

            _context.TeamGames.Remove(teamGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // TeamGameExists
        /// <summary>
        /// return boolean value: true or false
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool TeamGameExists(Guid id)
        {
            return _context.TeamGames.Any(e => e.TeamID == id);
        }
    }
}
