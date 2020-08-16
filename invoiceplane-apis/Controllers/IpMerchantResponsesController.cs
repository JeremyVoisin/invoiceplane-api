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
    public class IpMerchantResponsesController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpMerchantResponsesController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpMerchantResponses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpMerchantResponses>>> GetIpMerchantResponses()
        {
            return await _context.IpMerchantResponses.ToListAsync();
        }

        // GET: api/IpMerchantResponses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpMerchantResponses>> GetIpMerchantResponses(int id)
        {
            var ipMerchantResponses = await _context.IpMerchantResponses.FindAsync(id);

            if (ipMerchantResponses == null)
            {
                return NotFound();
            }

            return ipMerchantResponses;
        }

        // PUT: api/IpMerchantResponses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpMerchantResponses(int id, IpMerchantResponses ipMerchantResponses)
        {
            if (id != ipMerchantResponses.MerchantResponseId)
            {
                return BadRequest();
            }

            _context.Entry(ipMerchantResponses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpMerchantResponsesExists(id))
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

        // POST: api/IpMerchantResponses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpMerchantResponses>> PostIpMerchantResponses(IpMerchantResponses ipMerchantResponses)
        {
            _context.IpMerchantResponses.Add(ipMerchantResponses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpMerchantResponses", new { id = ipMerchantResponses.MerchantResponseId }, ipMerchantResponses);
        }

        // DELETE: api/IpMerchantResponses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpMerchantResponses>> DeleteIpMerchantResponses(int id)
        {
            var ipMerchantResponses = await _context.IpMerchantResponses.FindAsync(id);
            if (ipMerchantResponses == null)
            {
                return NotFound();
            }

            _context.IpMerchantResponses.Remove(ipMerchantResponses);
            await _context.SaveChangesAsync();

            return ipMerchantResponses;
        }

        private bool IpMerchantResponsesExists(int id)
        {
            return _context.IpMerchantResponses.Any(e => e.MerchantResponseId == id);
        }
    }
}
