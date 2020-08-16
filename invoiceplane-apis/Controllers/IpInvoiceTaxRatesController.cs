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
    public class IpInvoiceTaxRatesController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpInvoiceTaxRatesController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpInvoiceTaxRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpInvoiceTaxRates>>> GetIpInvoiceTaxRates()
        {
            return await _context.IpInvoiceTaxRates.ToListAsync();
        }

        // GET: api/IpInvoiceTaxRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpInvoiceTaxRates>> GetIpInvoiceTaxRates(int id)
        {
            var ipInvoiceTaxRates = await _context.IpInvoiceTaxRates.FindAsync(id);

            if (ipInvoiceTaxRates == null)
            {
                return NotFound();
            }

            return ipInvoiceTaxRates;
        }

        // PUT: api/IpInvoiceTaxRates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpInvoiceTaxRates(int id, IpInvoiceTaxRates ipInvoiceTaxRates)
        {
            if (id != ipInvoiceTaxRates.InvoiceTaxRateId)
            {
                return BadRequest();
            }

            _context.Entry(ipInvoiceTaxRates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpInvoiceTaxRatesExists(id))
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

        // POST: api/IpInvoiceTaxRates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpInvoiceTaxRates>> PostIpInvoiceTaxRates(IpInvoiceTaxRates ipInvoiceTaxRates)
        {
            _context.IpInvoiceTaxRates.Add(ipInvoiceTaxRates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpInvoiceTaxRates", new { id = ipInvoiceTaxRates.InvoiceTaxRateId }, ipInvoiceTaxRates);
        }

        // DELETE: api/IpInvoiceTaxRates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpInvoiceTaxRates>> DeleteIpInvoiceTaxRates(int id)
        {
            var ipInvoiceTaxRates = await _context.IpInvoiceTaxRates.FindAsync(id);
            if (ipInvoiceTaxRates == null)
            {
                return NotFound();
            }

            _context.IpInvoiceTaxRates.Remove(ipInvoiceTaxRates);
            await _context.SaveChangesAsync();

            return ipInvoiceTaxRates;
        }

        private bool IpInvoiceTaxRatesExists(int id)
        {
            return _context.IpInvoiceTaxRates.Any(e => e.InvoiceTaxRateId == id);
        }
    }
}
