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
    public class IpVersionsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpVersionsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpVersions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpVersions>>> GetIpVersions()
        {
            return await _context.IpVersions.ToListAsync();
        }

        // GET: api/IpVersions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpVersions>> GetIpVersions(int id)
        {
            var ipVersions = await _context.IpVersions.FindAsync(id);

            if (ipVersions == null)
            {
                return NotFound();
            }

            return ipVersions;
        }

        // PUT: api/IpVersions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpVersions(int id, IpVersions ipVersions)
        {
            if (id != ipVersions.VersionId)
            {
                return BadRequest();
            }

            _context.Entry(ipVersions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpVersionsExists(id))
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

        // POST: api/IpVersions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpVersions>> PostIpVersions(IpVersions ipVersions)
        {
            _context.IpVersions.Add(ipVersions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpVersions", new { id = ipVersions.VersionId }, ipVersions);
        }

        // DELETE: api/IpVersions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpVersions>> DeleteIpVersions(int id)
        {
            var ipVersions = await _context.IpVersions.FindAsync(id);
            if (ipVersions == null)
            {
                return NotFound();
            }

            _context.IpVersions.Remove(ipVersions);
            await _context.SaveChangesAsync();

            return ipVersions;
        }

        private bool IpVersionsExists(int id)
        {
            return _context.IpVersions.Any(e => e.VersionId == id);
        }
    }
}
