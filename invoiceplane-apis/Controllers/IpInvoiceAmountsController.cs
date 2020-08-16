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
    public class IpInvoiceAmountsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpInvoiceAmountsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpInvoiceAmounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpInvoiceAmounts>>> GetIpInvoiceAmounts()
        {
            return await _context.IpInvoiceAmounts.ToListAsync();
        }

        // GET: api/IpInvoiceAmounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpInvoiceAmounts>> GetIpInvoiceAmounts(int id)
        {
            var ipInvoiceAmounts = await _context.IpInvoiceAmounts.FindAsync(id);

            if (ipInvoiceAmounts == null)
            {
                return NotFound();
            }

            return ipInvoiceAmounts;
        }

        // PUT: api/IpInvoiceAmounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpInvoiceAmounts(int id, IpInvoiceAmounts ipInvoiceAmounts)
        {
            if (id != ipInvoiceAmounts.InvoiceAmountId)
            {
                return BadRequest();
            }

            _context.Entry(ipInvoiceAmounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpInvoiceAmountsExists(id))
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

        // POST: api/IpInvoiceAmounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpInvoiceAmounts>> PostIpInvoiceAmounts(IpInvoiceAmounts ipInvoiceAmounts)
        {
            _context.IpInvoiceAmounts.Add(ipInvoiceAmounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpInvoiceAmounts", new { id = ipInvoiceAmounts.InvoiceAmountId }, ipInvoiceAmounts);
        }

        // DELETE: api/IpInvoiceAmounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpInvoiceAmounts>> DeleteIpInvoiceAmounts(int id)
        {
            var ipInvoiceAmounts = await _context.IpInvoiceAmounts.FindAsync(id);
            if (ipInvoiceAmounts == null)
            {
                return NotFound();
            }

            _context.IpInvoiceAmounts.Remove(ipInvoiceAmounts);
            await _context.SaveChangesAsync();

            return ipInvoiceAmounts;
        }

        private bool IpInvoiceAmountsExists(int id)
        {
            return _context.IpInvoiceAmounts.Any(e => e.InvoiceAmountId == id);
        }
    }
}
