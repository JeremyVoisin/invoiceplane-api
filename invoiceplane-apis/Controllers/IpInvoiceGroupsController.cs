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
    public class IpInvoiceGroupsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpInvoiceGroupsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpInvoiceGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpInvoiceGroups>>> GetIpInvoiceGroups()
        {
            return await _context.IpInvoiceGroups.ToListAsync();
        }

        // GET: api/IpInvoiceGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpInvoiceGroups>> GetIpInvoiceGroups(int id)
        {
            var ipInvoiceGroups = await _context.IpInvoiceGroups.FindAsync(id);

            if (ipInvoiceGroups == null)
            {
                return NotFound();
            }

            return ipInvoiceGroups;
        }

        // PUT: api/IpInvoiceGroups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpInvoiceGroups(int id, IpInvoiceGroups ipInvoiceGroups)
        {
            if (id != ipInvoiceGroups.InvoiceGroupId)
            {
                return BadRequest();
            }

            _context.Entry(ipInvoiceGroups).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpInvoiceGroupsExists(id))
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

        // POST: api/IpInvoiceGroups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpInvoiceGroups>> PostIpInvoiceGroups(IpInvoiceGroups ipInvoiceGroups)
        {
            _context.IpInvoiceGroups.Add(ipInvoiceGroups);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpInvoiceGroups", new { id = ipInvoiceGroups.InvoiceGroupId }, ipInvoiceGroups);
        }

        // DELETE: api/IpInvoiceGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpInvoiceGroups>> DeleteIpInvoiceGroups(int id)
        {
            var ipInvoiceGroups = await _context.IpInvoiceGroups.FindAsync(id);
            if (ipInvoiceGroups == null)
            {
                return NotFound();
            }

            _context.IpInvoiceGroups.Remove(ipInvoiceGroups);
            await _context.SaveChangesAsync();

            return ipInvoiceGroups;
        }

        private bool IpInvoiceGroupsExists(int id)
        {
            return _context.IpInvoiceGroups.Any(e => e.InvoiceGroupId == id);
        }
    }
}
