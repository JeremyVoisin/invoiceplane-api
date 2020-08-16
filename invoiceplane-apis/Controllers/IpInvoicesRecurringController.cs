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
    public class IpInvoicesRecurringController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpInvoicesRecurringController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpInvoicesRecurring
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpInvoicesRecurring>>> GetIpInvoicesRecurring()
        {
            return await _context.IpInvoicesRecurring.ToListAsync();
        }

        // GET: api/IpInvoicesRecurring/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpInvoicesRecurring>> GetIpInvoicesRecurring(int id)
        {
            var ipInvoicesRecurring = await _context.IpInvoicesRecurring.FindAsync(id);

            if (ipInvoicesRecurring == null)
            {
                return NotFound();
            }

            return ipInvoicesRecurring;
        }

        // PUT: api/IpInvoicesRecurring/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpInvoicesRecurring(int id, IpInvoicesRecurring ipInvoicesRecurring)
        {
            if (id != ipInvoicesRecurring.InvoiceRecurringId)
            {
                return BadRequest();
            }

            _context.Entry(ipInvoicesRecurring).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpInvoicesRecurringExists(id))
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

        // POST: api/IpInvoicesRecurring
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpInvoicesRecurring>> PostIpInvoicesRecurring(IpInvoicesRecurring ipInvoicesRecurring)
        {
            _context.IpInvoicesRecurring.Add(ipInvoicesRecurring);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpInvoicesRecurring", new { id = ipInvoicesRecurring.InvoiceRecurringId }, ipInvoicesRecurring);
        }

        // DELETE: api/IpInvoicesRecurring/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpInvoicesRecurring>> DeleteIpInvoicesRecurring(int id)
        {
            var ipInvoicesRecurring = await _context.IpInvoicesRecurring.FindAsync(id);
            if (ipInvoicesRecurring == null)
            {
                return NotFound();
            }

            _context.IpInvoicesRecurring.Remove(ipInvoicesRecurring);
            await _context.SaveChangesAsync();

            return ipInvoicesRecurring;
        }

        private bool IpInvoicesRecurringExists(int id)
        {
            return _context.IpInvoicesRecurring.Any(e => e.InvoiceRecurringId == id);
        }
    }
}
