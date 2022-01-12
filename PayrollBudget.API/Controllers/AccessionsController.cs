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
    public class AccessionsController : ControllerBase
    {
        private readonly DataContext _context;

        public AccessionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Accessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accession>>> GetAccessions()
        {
            return await _context.Accessions.ToListAsync();
        }

        // GET: api/Accessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accession>> GetAccession(int id)
        {
            var accession = await _context.Accessions.FindAsync(id);

            if (accession == null)
            {
                return NotFound();
            }

            return accession;
        }

        // PUT: api/Accessions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccession(int id, Accession accession)
        {
            if (id != accession.Id)
            {
                return BadRequest();
            }

            _context.Entry(accession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessionExists(id))
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

        // POST: api/Accessions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Accession>> PostAccession(Accession accession)
        {
            _context.Accessions.Add(accession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccession", new { id = accession.Id }, accession);
        }

        // DELETE: api/Accessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccession(int id)
        {
            var accession = await _context.Accessions.FindAsync(id);
            if (accession == null)
            {
                return NotFound();
            }

            _context.Accessions.Remove(accession);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccessionExists(int id)
        {
            return _context.Accessions.Any(e => e.Id == id);
        }
    }
}
