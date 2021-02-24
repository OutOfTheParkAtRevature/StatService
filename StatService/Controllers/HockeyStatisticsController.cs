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
    public class HockeyStatisticsController : ControllerBase
    {
        private readonly StatsContext _context;

        public HockeyStatisticsController(StatsContext context)
        {
            _context = context;
        }

        // GET: api/HockeyStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HockeyStatistic>>> GetHockeyStatistics()
        {
            return await _context.HockeyStatistics.ToListAsync();
        }

        // GET: api/HockeyStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HockeyStatistic>> GetHockeyStatistic(Guid id)
        {
            var hockeyStatistic = await _context.HockeyStatistics.FindAsync(id);

            if (hockeyStatistic == null)
            {
                return NotFound();
            }

            return hockeyStatistic;
        }

        // PUT: api/HockeyStatistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHockeyStatistic(Guid id, HockeyStatistic hockeyStatistic)
        {
            if (id != hockeyStatistic.StatLineID)
            {
                return BadRequest();
            }

            _context.Entry(hockeyStatistic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HockeyStatisticExists(id))
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

        // POST: api/HockeyStatistics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HockeyStatistic>> PostHockeyStatistic(HockeyStatistic hockeyStatistic)
        {
            _context.HockeyStatistics.Add(hockeyStatistic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHockeyStatistic", new { id = hockeyStatistic.StatLineID }, hockeyStatistic);
        }

        // DELETE: api/HockeyStatistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHockeyStatistic(Guid id)
        {
            var hockeyStatistic = await _context.HockeyStatistics.FindAsync(id);
            if (hockeyStatistic == null)
            {
                return NotFound();
            }

            _context.HockeyStatistics.Remove(hockeyStatistic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HockeyStatisticExists(Guid id)
        {
            return _context.HockeyStatistics.Any(e => e.StatLineID == id);
        }
    }
}
