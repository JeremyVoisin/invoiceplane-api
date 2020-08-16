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
    public class IpInvoiceItemsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpInvoiceItemsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpInvoiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpInvoiceItems>>> GetIpInvoiceItems()
        {
            return await _context.IpInvoiceItems.ToListAsync();
        }

        // GET: api/IpInvoiceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpInvoiceItems>> GetIpInvoiceItems(int id)
        {
            var ipInvoiceItems = await _context.IpInvoiceItems.FindAsync(id);

            if (ipInvoiceItems == null)
            {
                return NotFound();
            }

            return ipInvoiceItems;
        }

        // PUT: api/IpInvoiceItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpInvoiceItems(int id, IpInvoiceItems ipInvoiceItems)
        {
            if (id != ipInvoiceItems.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(ipInvoiceItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpInvoiceItemsExists(id))
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

        // POST: api/IpInvoiceItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpInvoiceItems>> PostIpInvoiceItems(IpInvoiceItems ipInvoiceItems)
        {
            _context.IpInvoiceItems.Add(ipInvoiceItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpInvoiceItems", new { id = ipInvoiceItems.ItemId }, ipInvoiceItems);
        }

        // DELETE: api/IpInvoiceItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpInvoiceItems>> DeleteIpInvoiceItems(int id)
        {
            var ipInvoiceItems = await _context.IpInvoiceItems.FindAsync(id);
            if (ipInvoiceItems == null)
            {
                return NotFound();
            }

            _context.IpInvoiceItems.Remove(ipInvoiceItems);
            await _context.SaveChangesAsync();

            return ipInvoiceItems;
        }

        private bool IpInvoiceItemsExists(int id)
        {
            return _context.IpInvoiceItems.Any(e => e.ItemId == id);
        }
    }
}
