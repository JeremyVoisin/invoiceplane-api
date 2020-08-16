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
    public class IpUnitsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpUnitsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpUnits>>> GetIpUnits()
        {
            return await _context.IpUnits.ToListAsync();
        }

        // GET: api/IpUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpUnits>> GetIpUnits(int id)
        {
            var ipUnits = await _context.IpUnits.FindAsync(id);

            if (ipUnits == null)
            {
                return NotFound();
            }

            return ipUnits;
        }

        // PUT: api/IpUnits/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpUnits(int id, IpUnits ipUnits)
        {
            if (id != ipUnits.UnitId)
            {
                return BadRequest();
            }

            _context.Entry(ipUnits).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpUnitsExists(id))
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

        // POST: api/IpUnits
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpUnits>> PostIpUnits(IpUnits ipUnits)
        {
            _context.IpUnits.Add(ipUnits);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpUnits", new { id = ipUnits.UnitId }, ipUnits);
        }

        // DELETE: api/IpUnits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpUnits>> DeleteIpUnits(int id)
        {
            var ipUnits = await _context.IpUnits.FindAsync(id);
            if (ipUnits == null)
            {
                return NotFound();
            }

            _context.IpUnits.Remove(ipUnits);
            await _context.SaveChangesAsync();

            return ipUnits;
        }

        private bool IpUnitsExists(int id)
        {
            return _context.IpUnits.Any(e => e.UnitId == id);
        }
    }
}
