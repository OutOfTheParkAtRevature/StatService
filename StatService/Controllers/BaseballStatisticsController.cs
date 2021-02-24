﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;
using Service;

namespace StatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseballStatisticsController : ControllerBase
    {
        private readonly StatsContext _context;
        private readonly Logic _logic;

        public BaseballStatisticsController(StatsContext context, Logic logic)
        {
            _context = context;
            _logic = logic;
        }

        // GET: api/BaseballStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseballStatistic>>> GetBaseballStatistics()
        {
           // return await _logic.GetBaseballGameStatistic();
            return await _context.BaseballStatistics.ToListAsync();
        }

        // GET: api/BaseballStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseballStatistic>> GetBaseballStatistic(Guid id)
        {
            return await _logic.GetBaseballStatisticById(id);
        }

        // GET: api/BaseballStatistics/1/1
        [HttpGet("{userId}/{gameId}")]
        public async Task<ActionResult<BaseballStatistic>> GetBaseballGameStatistic(string userId, Guid gameId)
        {
            return await _logic.GetBaseballGameStatistic(userId, gameId);
        }

        // PUT: api/BaseballStatistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseballStatistic(Guid id, BaseballStatistic baseballStatistic)
        {
            if (id != baseballStatistic.StatLineID)
            {
                return BadRequest();
            }

            _context.Entry(baseballStatistic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseballStatisticExists(id))
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

        // POST: api/BaseballStatistics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaseballStatistic>> PostBaseballStatistic(BaseballStatistic baseballStatistic)
        {
            _context.BaseballStatistics.Add(baseballStatistic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaseballStatistic", new { id = baseballStatistic.StatLineID }, baseballStatistic);
        }

        // DELETE: api/BaseballStatistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaseballStatistic(Guid id)
        {
            var baseballStatistic = await _context.BaseballStatistics.FindAsync(id);
            if (baseballStatistic == null)
            {
                return NotFound();
            }

            _context.BaseballStatistics.Remove(baseballStatistic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaseballStatisticExists(Guid id)
        {
            return _context.BaseballStatistics.Any(e => e.StatLineID == id);
        }

        [HttpGet("player")]
        public async Task<IActionResult> GetAllPlayerOverallStats()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return Ok(await _logic.GetAllPlayerOverallStatistics(token));
        }
        [HttpGet("player/{id}")]
        public async Task<IActionResult> GetOverallStatsForPlayer(string id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return Ok(await _logic.GetPlayerOverallBaseballStatistic(id, token));
        }
        [HttpGet("team")]
        public async Task<IActionResult> GetAllTeamOverallStats()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return Ok(await _logic.GetAllTeamOverallStatistics(token));
        }
        [HttpGet("team/{id}")]
        public async Task<IActionResult> GetOverallStatsForTeam(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return Ok(await _logic.GetTeamOverallBaseballStatistic(id, token));
        }
    }
}
