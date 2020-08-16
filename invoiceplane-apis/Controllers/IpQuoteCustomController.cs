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
    public class IpQuoteCustomController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpQuoteCustomController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpQuoteCustom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpQuoteCustom>>> GetIpQuoteCustom()
        {
            return await _context.IpQuoteCustom.ToListAsync();
        }

        // GET: api/IpQuoteCustom/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpQuoteCustom>> GetIpQuoteCustom(int id)
        {
            var ipQuoteCustom = await _context.IpQuoteCustom.FindAsync(id);

            if (ipQuoteCustom == null)
            {
                return NotFound();
            }

            return ipQuoteCustom;
        }

        // PUT: api/IpQuoteCustom/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpQuoteCustom(int id, IpQuoteCustom ipQuoteCustom)
        {
            if (id != ipQuoteCustom.QuoteCustomId)
            {
                return BadRequest();
            }

            _context.Entry(ipQuoteCustom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpQuoteCustomExists(id))
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

        // POST: api/IpQuoteCustom
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpQuoteCustom>> PostIpQuoteCustom(IpQuoteCustom ipQuoteCustom)
        {
            _context.IpQuoteCustom.Add(ipQuoteCustom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpQuoteCustom", new { id = ipQuoteCustom.QuoteCustomId }, ipQuoteCustom);
        }

        // DELETE: api/IpQuoteCustom/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpQuoteCustom>> DeleteIpQuoteCustom(int id)
        {
            var ipQuoteCustom = await _context.IpQuoteCustom.FindAsync(id);
            if (ipQuoteCustom == null)
            {
                return NotFound();
            }

            _context.IpQuoteCustom.Remove(ipQuoteCustom);
            await _context.SaveChangesAsync();

            return ipQuoteCustom;
        }

        private bool IpQuoteCustomExists(int id)
        {
            return _context.IpQuoteCustom.Any(e => e.QuoteCustomId == id);
        }
    }
}
