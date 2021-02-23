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
    public class SoccerStatisticsController : ControllerBase
    {
        private readonly StatsContext _context;

        public SoccerStatisticsController(StatsContext context)
        {
            _context = context;
        }

        // GET: api/SoccerStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoccerStatistic>>> GetSoccerStatistics()
        {
            return await _context.SoccerStatistics.ToListAsync();
        }

        // GET: api/SoccerStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoccerStatistic>> GetSoccerStatistic(Guid id)
        {
            var soccerStatistic = await _context.SoccerStatistics.FindAsync(id);

            if (soccerStatistic == null)
            {
                return NotFound();
            }

            return soccerStatistic;
        }

        // PUT: api/SoccerStatistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoccerStatistic(Guid id, SoccerStatistic soccerStatistic)
        {
            if (id != soccerStatistic.StatLineID)
            {
                return BadRequest();
            }

            _context.Entry(soccerStatistic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoccerStatisticExists(id))
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

        // POST: api/SoccerStatistics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SoccerStatistic>> PostSoccerStatistic(SoccerStatistic soccerStatistic)
        {
            _context.SoccerStatistics.Add(soccerStatistic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoccerStatistic", new { id = soccerStatistic.StatLineID }, soccerStatistic);
        }

        // DELETE: api/SoccerStatistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoccerStatistic(Guid id)
        {
            var soccerStatistic = await _context.SoccerStatistics.FindAsync(id);
            if (soccerStatistic == null)
            {
                return NotFound();
            }

            _context.SoccerStatistics.Remove(soccerStatistic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoccerStatisticExists(Guid id)
        {
            return _context.SoccerStatistics.Any(e => e.StatLineID == id);
        }
    }
}
