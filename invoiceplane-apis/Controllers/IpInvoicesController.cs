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
    public class IpInvoicesController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpInvoicesController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpInvoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpInvoices>>> GetIpInvoices()
        {
            return await _context.IpInvoices.ToListAsync();
        }

        // GET: api/IpInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpInvoices>> GetIpInvoices(int id)
        {
            var ipInvoices = await _context.IpInvoices.FindAsync(id);

            if (ipInvoices == null)
            {
                return NotFound();
            }

            return ipInvoices;
        }

        // PUT: api/IpInvoices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpInvoices(int id, IpInvoices ipInvoices)
        {
            if (id != ipInvoices.InvoiceId)
            {
                return BadRequest();
            }

            _context.Entry(ipInvoices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpInvoicesExists(id))
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

        // POST: api/IpInvoices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpInvoices>> PostIpInvoices(IpInvoices ipInvoices)
        {
            _context.IpInvoices.Add(ipInvoices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpInvoices", new { id = ipInvoices.InvoiceId }, ipInvoices);
        }

        // DELETE: api/IpInvoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpInvoices>> DeleteIpInvoices(int id)
        {
            var ipInvoices = await _context.IpInvoices.FindAsync(id);
            if (ipInvoices == null)
            {
                return NotFound();
            }

            _context.IpInvoices.Remove(ipInvoices);
            await _context.SaveChangesAsync();

            return ipInvoices;
        }

        private bool IpInvoicesExists(int id)
        {
            return _context.IpInvoices.Any(e => e.InvoiceId == id);
        }
    }
}
