#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollBudget.API.Data;
using PayrollBudget.API.Models;

namespace PayrollBudget.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubtotalsController : ControllerBase
    {
        private readonly DataContext _context;

        public SubtotalsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Subtotals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subtotal>>> GetSubtotals()
        {
            return await _context.Subtotals.ToListAsync();
        }

        // GET: api/Subtotals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subtotal>> GetSubtotal(int id)
        {
            var subtotal = await _context.Subtotals.FindAsync(id);

            if (subtotal == null)
            {
                return NotFound();
            }

            return subtotal;
        }

        // PUT: api/Subtotals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubtotal(int id, Subtotal subtotal)
        {
            if (id != subtotal.Id)
            {
                return BadRequest();
            }

            _context.Entry(subtotal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubtotalExists(id))
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

        // POST: api/Subtotals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subtotal>> PostSubtotal(Subtotal subtotal)
        {
            _context.Subtotals.Add(subtotal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubtotal", new { id = subtotal.Id }, subtotal);
        }

        // DELETE: api/Subtotals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubtotal(int id)
        {
            var subtotal = await _context.Subtotals.FindAsync(id);
            if (subtotal == null)
            {
                return NotFound();
            }

            _context.Subtotals.Remove(subtotal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubtotalExists(int id)
        {
            return _context.Subtotals.Any(e => e.Id == id);
        }
    }
}
