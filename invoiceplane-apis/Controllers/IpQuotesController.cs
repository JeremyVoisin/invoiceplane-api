using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using invoiceplane_apis.Models;

namespace invoiceplane_apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpQuotesController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpQuotesController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpQuotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpQuotes>>> GetIpQuotes()
        {
            return await _context.IpQuotes.ToListAsync();
        }

        // GET: api/IpQuotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpQuotes>> GetIpQuotes(int id)
        {
            var ipQuotes = await _context.IpQuotes.FindAsync(id);

            if (ipQuotes == null)
            {
                return NotFound();
            }

            return ipQuotes;
        }

        // PUT: api/IpQuotes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpQuotes(int id, IpQuotes ipQuotes)
        {
            if (id != ipQuotes.QuoteId)
            {
                return BadRequest();
            }

            _context.Entry(ipQuotes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpQuotesExists(id))
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

        // POST: api/IpQuotes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpQuotes>> PostIpQuotes(IpQuotes ipQuotes)
        {
            _context.IpQuotes.Add(ipQuotes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpQuotes", new { id = ipQuotes.QuoteId }, ipQuotes);
        }

        // DELETE: api/IpQuotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpQuotes>> DeleteIpQuotes(int id)
        {
            var ipQuotes = await _context.IpQuotes.FindAsync(id);
            if (ipQuotes == null)
            {
                return NotFound();
            }

            _context.IpQuotes.Remove(ipQuotes);
            await _context.SaveChangesAsync();

            return ipQuotes;
        }

        private bool IpQuotesExists(int id)
        {
            return _context.IpQuotes.Any(e => e.QuoteId == id);
        }
    }
}
