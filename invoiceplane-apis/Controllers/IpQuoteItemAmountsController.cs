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
    public class IpQuoteItemAmountsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpQuoteItemAmountsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpQuoteItemAmounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpQuoteItemAmounts>>> GetIpQuoteItemAmounts()
        {
            return await _context.IpQuoteItemAmounts.ToListAsync();
        }

        // GET: api/IpQuoteItemAmounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpQuoteItemAmounts>> GetIpQuoteItemAmounts(int id)
        {
            var ipQuoteItemAmounts = await _context.IpQuoteItemAmounts.FindAsync(id);

            if (ipQuoteItemAmounts == null)
            {
                return NotFound();
            }

            return ipQuoteItemAmounts;
        }

        // PUT: api/IpQuoteItemAmounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpQuoteItemAmounts(int id, IpQuoteItemAmounts ipQuoteItemAmounts)
        {
            if (id != ipQuoteItemAmounts.ItemAmountId)
            {
                return BadRequest();
            }

            _context.Entry(ipQuoteItemAmounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpQuoteItemAmountsExists(id))
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

        // POST: api/IpQuoteItemAmounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpQuoteItemAmounts>> PostIpQuoteItemAmounts(IpQuoteItemAmounts ipQuoteItemAmounts)
        {
            _context.IpQuoteItemAmounts.Add(ipQuoteItemAmounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpQuoteItemAmounts", new { id = ipQuoteItemAmounts.ItemAmountId }, ipQuoteItemAmounts);
        }

        // DELETE: api/IpQuoteItemAmounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpQuoteItemAmounts>> DeleteIpQuoteItemAmounts(int id)
        {
            var ipQuoteItemAmounts = await _context.IpQuoteItemAmounts.FindAsync(id);
            if (ipQuoteItemAmounts == null)
            {
                return NotFound();
            }

            _context.IpQuoteItemAmounts.Remove(ipQuoteItemAmounts);
            await _context.SaveChangesAsync();

            return ipQuoteItemAmounts;
        }

        private bool IpQuoteItemAmountsExists(int id)
        {
            return _context.IpQuoteItemAmounts.Any(e => e.ItemAmountId == id);
        }
    }
}
