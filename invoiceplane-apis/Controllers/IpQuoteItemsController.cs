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
    public class IpQuoteItemsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpQuoteItemsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpQuoteItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpQuoteItems>>> GetIpQuoteItems()
        {
            return await _context.IpQuoteItems.ToListAsync();
        }

        // GET: api/IpQuoteItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpQuoteItems>> GetIpQuoteItems(int id)
        {
            var ipQuoteItems = await _context.IpQuoteItems.FindAsync(id);

            if (ipQuoteItems == null)
            {
                return NotFound();
            }

            return ipQuoteItems;
        }

        // PUT: api/IpQuoteItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpQuoteItems(int id, IpQuoteItems ipQuoteItems)
        {
            if (id != ipQuoteItems.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(ipQuoteItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpQuoteItemsExists(id))
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

        // POST: api/IpQuoteItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpQuoteItems>> PostIpQuoteItems(IpQuoteItems ipQuoteItems)
        {
            _context.IpQuoteItems.Add(ipQuoteItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpQuoteItems", new { id = ipQuoteItems.ItemId }, ipQuoteItems);
        }

        // DELETE: api/IpQuoteItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpQuoteItems>> DeleteIpQuoteItems(int id)
        {
            var ipQuoteItems = await _context.IpQuoteItems.FindAsync(id);
            if (ipQuoteItems == null)
            {
                return NotFound();
            }

            _context.IpQuoteItems.Remove(ipQuoteItems);
            await _context.SaveChangesAsync();

            return ipQuoteItems;
        }

        private bool IpQuoteItemsExists(int id)
        {
            return _context.IpQuoteItems.Any(e => e.ItemId == id);
        }
    }
}
