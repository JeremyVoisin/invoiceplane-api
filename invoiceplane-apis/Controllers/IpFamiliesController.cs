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
    public class IpFamiliesController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpFamiliesController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpFamilies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpFamilies>>> GetIpFamilies()
        {
            return await _context.IpFamilies.ToListAsync();
        }

        // GET: api/IpFamilies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpFamilies>> GetIpFamilies(int id)
        {
            var ipFamilies = await _context.IpFamilies.FindAsync(id);

            if (ipFamilies == null)
            {
                return NotFound();
            }

            return ipFamilies;
        }

        // PUT: api/IpFamilies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpFamilies(int id, IpFamilies ipFamilies)
        {
            if (id != ipFamilies.FamilyId)
            {
                return BadRequest();
            }

            _context.Entry(ipFamilies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpFamiliesExists(id))
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

        // POST: api/IpFamilies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpFamilies>> PostIpFamilies(IpFamilies ipFamilies)
        {
            _context.IpFamilies.Add(ipFamilies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpFamilies", new { id = ipFamilies.FamilyId }, ipFamilies);
        }

        // DELETE: api/IpFamilies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpFamilies>> DeleteIpFamilies(int id)
        {
            var ipFamilies = await _context.IpFamilies.FindAsync(id);
            if (ipFamilies == null)
            {
                return NotFound();
            }

            _context.IpFamilies.Remove(ipFamilies);
            await _context.SaveChangesAsync();

            return ipFamilies;
        }

        private bool IpFamiliesExists(int id)
        {
            return _context.IpFamilies.Any(e => e.FamilyId == id);
        }
    }
}
