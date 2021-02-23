using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

namespace StatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootBallStatisticsController : ControllerBase
    {
        private readonly StatsContext _context;

        public FootBallStatisticsController(StatsContext context)
        {
            _context = context;
        }

        // GET: api/FootBallStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FootBallStatistic>>> GetFootballStatistics()
        {
            return await _context.FootballStatistics.ToListAsync();
        }

        // GET: api/FootBallStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FootBallStatistic>> GetFootBallStatistic(Guid id)
        {
            var footBallStatistic = await _context.FootballStatistics.FindAsync(id);

            if (footBallStatistic == null)
            {
                return NotFound();
            }

            return footBallStatistic;
        }

        // PUT: api/FootBallStatistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFootBallStatistic(Guid id, FootBallStatistic footBallStatistic)
        {
            if (id != footBallStatistic.StatLineID)
            {
                return BadRequest();
            }

            _context.Entry(footBallStatistic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FootBallStatisticExists(id))
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

        // POST: api/FootBallStatistics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FootBallStatistic>> PostFootBallStatistic(FootBallStatistic footBallStatistic)
        {
            _context.FootballStatistics.Add(footBallStatistic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFootBallStatistic", new { id = footBallStatistic.StatLineID }, footBallStatistic);
        }

        // DELETE: api/FootBallStatistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFootBallStatistic(Guid id)
        {
            var footBallStatistic = await _context.FootballStatistics.FindAsync(id);
            if (footBallStatistic == null)
            {
                return NotFound();
            }

            _context.FootballStatistics.Remove(footBallStatistic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FootBallStatisticExists(Guid id)
        {
            return _context.FootballStatistics.Any(e => e.StatLineID == id);
        }
    }
}
