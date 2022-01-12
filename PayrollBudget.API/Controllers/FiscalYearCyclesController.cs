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
    public class FiscalYearCyclesController : ControllerBase
    {
        private readonly DataContext _context;

        public FiscalYearCyclesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FiscalYearCycles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FiscalYearCycle>>> GetFiscalYearCycles()
        {
            return await _context.FiscalYearCycles.ToListAsync();
        }

        // GET: api/FiscalYearCycles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FiscalYearCycle>> GetFiscalYearCycle(int id)
        {
            var fiscalYearCycle = await _context.FiscalYearCycles.FindAsync(id);

            if (fiscalYearCycle == null)
            {
                return NotFound();
            }

            return fiscalYearCycle;
        }

        // PUT: api/FiscalYearCycles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFiscalYearCycle(int id, FiscalYearCycle fiscalYearCycle)
        {
            if (id != fiscalYearCycle.Id)
            {
                return BadRequest();
            }

            _context.Entry(fiscalYearCycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiscalYearCycleExists(id))
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

        // POST: api/FiscalYearCycles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FiscalYearCycle>> PostFiscalYearCycle(FiscalYearCycle fiscalYearCycle)
        {
            _context.FiscalYearCycles.Add(fiscalYearCycle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFiscalYearCycle", new { id = fiscalYearCycle.Id }, fiscalYearCycle);
        }

        // DELETE: api/FiscalYearCycles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFiscalYearCycle(int id)
        {
            var fiscalYearCycle = await _context.FiscalYearCycles.FindAsync(id);
            if (fiscalYearCycle == null)
            {
                return NotFound();
            }

            _context.FiscalYearCycles.Remove(fiscalYearCycle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FiscalYearCycleExists(int id)
        {
            return _context.FiscalYearCycles.Any(e => e.Id == id);
        }
    }
}
