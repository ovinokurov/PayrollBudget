﻿#nullable disable
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
    public class PayrollDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public PayrollDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PayrollDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PayrollDetail>>> GetPayrollDetails()
        {
            return await _context.PayrollDetails.ToListAsync();
        }

        // GET: api/PayrollDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayrollDetail>> GetPayrollDetail(int id)
        {
            var payrollDetail = await _context.PayrollDetails.FindAsync(id);

            if (payrollDetail == null)
            {
                return NotFound();
            }

            return payrollDetail;
        }

        // PUT: api/PayrollDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayrollDetail(int id, PayrollDetail payrollDetail)
        {
            if (id != payrollDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(payrollDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayrollDetailExists(id))
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

        // POST: api/PayrollDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PayrollDetail>> PostPayrollDetail(PayrollDetail payrollDetail)
        {
            _context.PayrollDetails.Add(payrollDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayrollDetail", new { id = payrollDetail.Id }, payrollDetail);
        }

        // DELETE: api/PayrollDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayrollDetail(int id)
        {
            var payrollDetail = await _context.PayrollDetails.FindAsync(id);
            if (payrollDetail == null)
            {
                return NotFound();
            }

            _context.PayrollDetails.Remove(payrollDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PayrollDetailExists(int id)
        {
            return _context.PayrollDetails.Any(e => e.Id == id);
        }
    }
}
