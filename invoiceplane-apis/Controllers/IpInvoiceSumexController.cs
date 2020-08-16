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
    public class IpInvoiceSumexController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpInvoiceSumexController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpInvoiceSumex
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpInvoiceSumex>>> GetIpInvoiceSumex()
        {
            return await _context.IpInvoiceSumex.ToListAsync();
        }

        // GET: api/IpInvoiceSumex/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpInvoiceSumex>> GetIpInvoiceSumex(int id)
        {
            var ipInvoiceSumex = await _context.IpInvoiceSumex.FindAsync(id);

            if (ipInvoiceSumex == null)
            {
                return NotFound();
            }

            return ipInvoiceSumex;
        }

        // PUT: api/IpInvoiceSumex/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpInvoiceSumex(int id, IpInvoiceSumex ipInvoiceSumex)
        {
            if (id != ipInvoiceSumex.SumexId)
            {
                return BadRequest();
            }

            _context.Entry(ipInvoiceSumex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpInvoiceSumexExists(id))
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

        // POST: api/IpInvoiceSumex
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpInvoiceSumex>> PostIpInvoiceSumex(IpInvoiceSumex ipInvoiceSumex)
        {
            _context.IpInvoiceSumex.Add(ipInvoiceSumex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpInvoiceSumex", new { id = ipInvoiceSumex.SumexId }, ipInvoiceSumex);
        }

        // DELETE: api/IpInvoiceSumex/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpInvoiceSumex>> DeleteIpInvoiceSumex(int id)
        {
            var ipInvoiceSumex = await _context.IpInvoiceSumex.FindAsync(id);
            if (ipInvoiceSumex == null)
            {
                return NotFound();
            }

            _context.IpInvoiceSumex.Remove(ipInvoiceSumex);
            await _context.SaveChangesAsync();

            return ipInvoiceSumex;
        }

        private bool IpInvoiceSumexExists(int id)
        {
            return _context.IpInvoiceSumex.Any(e => e.SumexId == id);
        }
    }
}
