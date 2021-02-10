using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

namespace StatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketballStatisticsController : ControllerBase
    {
        private readonly StatsContext _context;

        public BasketballStatisticsController(StatsContext context)
        {
            _context = context;
        }

        // GET: api/BasketballStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketballStatistic>>> GetBasketballStatistics()
        {
            return await _context.BasketballStatistics.ToListAsync();
        }

        // GET: api/BasketballStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasketballStatistic>> GetBasketballStatistic(Guid id)
        {
            var basketballStatistic = await _context.BasketballStatistics.FindAsync(id);

            if (basketballStatistic == null)
            {
                return NotFound();
            }

            return basketballStatistic;
        }

        // PUT: api/BasketballStatistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasketballStatistic(Guid id, BasketballStatistic basketballStatistic)
        {
            if (id != basketballStatistic.StatLineID)
            {
                return BadRequest();
            }

            _context.Entry(basketballStatistic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasketballStatisticExists(id))
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

        // POST: api/BasketballStatistics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BasketballStatistic>> PostBasketballStatistic(BasketballStatistic basketballStatistic)
        {
            _context.BasketballStatistics.Add(basketballStatistic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasketballStatistic", new { id = basketballStatistic.StatLineID }, basketballStatistic);
        }

        // DELETE: api/BasketballStatistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasketballStatistic(Guid id)
        {
            var basketballStatistic = await _context.BasketballStatistics.FindAsync(id);
            if (basketballStatistic == null)
            {
                return NotFound();
            }

            _context.BasketballStatistics.Remove(basketballStatistic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BasketballStatisticExists(Guid id)
        {
            return _context.BasketballStatistics.Any(e => e.StatLineID == id);
        }
    }
}
