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
    public class IpCustomValuesController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpCustomValuesController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpCustomValues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpCustomValues>>> GetIpCustomValues()
        {
            return await _context.IpCustomValues.ToListAsync();
        }

        // GET: api/IpCustomValues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpCustomValues>> GetIpCustomValues(int id)
        {
            var ipCustomValues = await _context.IpCustomValues.FindAsync(id);

            if (ipCustomValues == null)
            {
                return NotFound();
            }

            return ipCustomValues;
        }

        // PUT: api/IpCustomValues/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpCustomValues(int id, IpCustomValues ipCustomValues)
        {
            if (id != ipCustomValues.CustomValuesId)
            {
                return BadRequest();
            }

            _context.Entry(ipCustomValues).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpCustomValuesExists(id))
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

        // POST: api/IpCustomValues
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpCustomValues>> PostIpCustomValues(IpCustomValues ipCustomValues)
        {
            _context.IpCustomValues.Add(ipCustomValues);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpCustomValues", new { id = ipCustomValues.CustomValuesId }, ipCustomValues);
        }

        // DELETE: api/IpCustomValues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpCustomValues>> DeleteIpCustomValues(int id)
        {
            var ipCustomValues = await _context.IpCustomValues.FindAsync(id);
            if (ipCustomValues == null)
            {
                return NotFound();
            }

            _context.IpCustomValues.Remove(ipCustomValues);
            await _context.SaveChangesAsync();

            return ipCustomValues;
        }

        private bool IpCustomValuesExists(int id)
        {
            return _context.IpCustomValues.Any(e => e.CustomValuesId == id);
        }
    }
}
