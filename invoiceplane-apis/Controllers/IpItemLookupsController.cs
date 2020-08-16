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
    public class IpItemLookupsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpItemLookupsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpItemLookups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpItemLookups>>> GetIpItemLookups()
        {
            return await _context.IpItemLookups.ToListAsync();
        }

        // GET: api/IpItemLookups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpItemLookups>> GetIpItemLookups(int id)
        {
            var ipItemLookups = await _context.IpItemLookups.FindAsync(id);

            if (ipItemLookups == null)
            {
                return NotFound();
            }

            return ipItemLookups;
        }

        // PUT: api/IpItemLookups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpItemLookups(int id, IpItemLookups ipItemLookups)
        {
            if (id != ipItemLookups.ItemLookupId)
            {
                return BadRequest();
            }

            _context.Entry(ipItemLookups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpItemLookupsExists(id))
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

        // POST: api/IpItemLookups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpItemLookups>> PostIpItemLookups(IpItemLookups ipItemLookups)
        {
            _context.IpItemLookups.Add(ipItemLookups);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpItemLookups", new { id = ipItemLookups.ItemLookupId }, ipItemLookups);
        }

        // DELETE: api/IpItemLookups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpItemLookups>> DeleteIpItemLookups(int id)
        {
            var ipItemLookups = await _context.IpItemLookups.FindAsync(id);
            if (ipItemLookups == null)
            {
                return NotFound();
            }

            _context.IpItemLookups.Remove(ipItemLookups);
            await _context.SaveChangesAsync();

            return ipItemLookups;
        }

        private bool IpItemLookupsExists(int id)
        {
            return _context.IpItemLookups.Any(e => e.ItemLookupId == id);
        }
    }
}
