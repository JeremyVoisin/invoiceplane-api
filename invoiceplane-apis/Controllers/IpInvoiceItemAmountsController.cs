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
    public class IpInvoiceItemAmountsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpInvoiceItemAmountsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpInvoiceItemAmounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpInvoiceItemAmounts>>> GetIpInvoiceItemAmounts()
        {
            return await _context.IpInvoiceItemAmounts.ToListAsync();
        }

        // GET: api/IpInvoiceItemAmounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpInvoiceItemAmounts>> GetIpInvoiceItemAmounts(int id)
        {
            var ipInvoiceItemAmounts = await _context.IpInvoiceItemAmounts.FindAsync(id);

            if (ipInvoiceItemAmounts == null)
            {
                return NotFound();
            }

            return ipInvoiceItemAmounts;
        }

        // PUT: api/IpInvoiceItemAmounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpInvoiceItemAmounts(int id, IpInvoiceItemAmounts ipInvoiceItemAmounts)
        {
            if (id != ipInvoiceItemAmounts.ItemAmountId)
            {
                return BadRequest();
            }

            _context.Entry(ipInvoiceItemAmounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpInvoiceItemAmountsExists(id))
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

        // POST: api/IpInvoiceItemAmounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpInvoiceItemAmounts>> PostIpInvoiceItemAmounts(IpInvoiceItemAmounts ipInvoiceItemAmounts)
        {
            _context.IpInvoiceItemAmounts.Add(ipInvoiceItemAmounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpInvoiceItemAmounts", new { id = ipInvoiceItemAmounts.ItemAmountId }, ipInvoiceItemAmounts);
        }

        // DELETE: api/IpInvoiceItemAmounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpInvoiceItemAmounts>> DeleteIpInvoiceItemAmounts(int id)
        {
            var ipInvoiceItemAmounts = await _context.IpInvoiceItemAmounts.FindAsync(id);
            if (ipInvoiceItemAmounts == null)
            {
                return NotFound();
            }

            _context.IpInvoiceItemAmounts.Remove(ipInvoiceItemAmounts);
            await _context.SaveChangesAsync();

            return ipInvoiceItemAmounts;
        }

        private bool IpInvoiceItemAmountsExists(int id)
        {
            return _context.IpInvoiceItemAmounts.Any(e => e.ItemAmountId == id);
        }
    }
}
