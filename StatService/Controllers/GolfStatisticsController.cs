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
    public class GolfStatisticsController : ControllerBase
    {
        private readonly StatsContext _context;

        public GolfStatisticsController(StatsContext context)
        {
            _context = context;
        }

        // GET: api/GolfStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GolfStatistic>>> GetGolfStatistics()
        {
            return await _context.GolfStatistics.ToListAsync();
        }

        // GET: api/GolfStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GolfStatistic>> GetGolfStatistic(Guid id)
        {
            var golfStatistic = await _context.GolfStatistics.FindAsync(id);

            if (golfStatistic == null)
            {
                return NotFound();
            }

            return golfStatistic;
        }

        // PUT: api/GolfStatistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGolfStatistic(Guid id, GolfStatistic golfStatistic)
        {
            if (id != golfStatistic.StatLineID)
            {
                return BadRequest();
            }

            _context.Entry(golfStatistic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GolfStatisticExists(id))
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

        // POST: api/GolfStatistics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GolfStatistic>> PostGolfStatistic(GolfStatistic golfStatistic)
        {
            _context.GolfStatistics.Add(golfStatistic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGolfStatistic", new { id = golfStatistic.StatLineID }, golfStatistic);
        }

        // DELETE: api/GolfStatistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGolfStatistic(Guid id)
        {
            var golfStatistic = await _context.GolfStatistics.FindAsync(id);
            if (golfStatistic == null)
            {
                return NotFound();
            }

            _context.GolfStatistics.Remove(golfStatistic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GolfStatisticExists(Guid id)
        {
            return _context.GolfStatistics.Any(e => e.StatLineID == id);
        }
    }
}
