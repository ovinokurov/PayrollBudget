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
    public class PayPeriodsController : ControllerBase
    {
        private readonly DataContext _context;

        public PayPeriodsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PayPeriods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayPeriod>>> GetPayPeriods()
        {
            return await _context.PayPeriods.ToListAsync();
        }

        // GET: api/PayPeriods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayPeriod>> GetPayPeriod(int id)
        {
            var payPeriod = await _context.PayPeriods.FindAsync(id);

            if (payPeriod == null)
            {
                return NotFound();
            }

            return payPeriod;
        }

        // PUT: api/PayPeriods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayPeriod(int id, PayPeriod payPeriod)
        {
            if (id != payPeriod.Id)
            {
                return BadRequest();
            }

            _context.Entry(payPeriod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayPeriodExists(id))
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

        // POST: api/PayPeriods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PayPeriod>> PostPayPeriod(PayPeriod payPeriod)
        {
            _context.PayPeriods.Add(payPeriod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayPeriod", new { id = payPeriod.Id }, payPeriod);
        }

        // DELETE: api/PayPeriods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayPeriod(int id)
        {
            var payPeriod = await _context.PayPeriods.FindAsync(id);
            if (payPeriod == null)
            {
                return NotFound();
            }

            _context.PayPeriods.Remove(payPeriod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PayPeriodExists(int id)
        {
            return _context.PayPeriods.Any(e => e.Id == id);
        }
    }
}
