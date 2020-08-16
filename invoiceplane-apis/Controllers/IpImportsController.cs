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
    public class IpImportsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpImportsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpImports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpImports>>> GetIpImports()
        {
            return await _context.IpImports.ToListAsync();
        }

        // GET: api/IpImports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpImports>> GetIpImports(int id)
        {
            var ipImports = await _context.IpImports.FindAsync(id);

            if (ipImports == null)
            {
                return NotFound();
            }

            return ipImports;
        }

        // PUT: api/IpImports/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpImports(int id, IpImports ipImports)
        {
            if (id != ipImports.ImportId)
            {
                return BadRequest();
            }

            _context.Entry(ipImports).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpImportsExists(id))
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

        // POST: api/IpImports
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpImports>> PostIpImports(IpImports ipImports)
        {
            _context.IpImports.Add(ipImports);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpImports", new { id = ipImports.ImportId }, ipImports);
        }

        // DELETE: api/IpImports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpImports>> DeleteIpImports(int id)
        {
            var ipImports = await _context.IpImports.FindAsync(id);
            if (ipImports == null)
            {
                return NotFound();
            }

            _context.IpImports.Remove(ipImports);
            await _context.SaveChangesAsync();

            return ipImports;
        }

        private bool IpImportsExists(int id)
        {
            return _context.IpImports.Any(e => e.ImportId == id);
        }
    }
}
