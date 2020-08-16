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
    public class IpQuoteTaxRatesController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpQuoteTaxRatesController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpQuoteTaxRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpQuoteTaxRates>>> GetIpQuoteTaxRates()
        {
            return await _context.IpQuoteTaxRates.ToListAsync();
        }

        // GET: api/IpQuoteTaxRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpQuoteTaxRates>> GetIpQuoteTaxRates(int id)
        {
            var ipQuoteTaxRates = await _context.IpQuoteTaxRates.FindAsync(id);

            if (ipQuoteTaxRates == null)
            {
                return NotFound();
            }

            return ipQuoteTaxRates;
        }

        // PUT: api/IpQuoteTaxRates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpQuoteTaxRates(int id, IpQuoteTaxRates ipQuoteTaxRates)
        {
            if (id != ipQuoteTaxRates.QuoteTaxRateId)
            {
                return BadRequest();
            }

            _context.Entry(ipQuoteTaxRates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpQuoteTaxRatesExists(id))
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

        // POST: api/IpQuoteTaxRates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpQuoteTaxRates>> PostIpQuoteTaxRates(IpQuoteTaxRates ipQuoteTaxRates)
        {
            _context.IpQuoteTaxRates.Add(ipQuoteTaxRates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpQuoteTaxRates", new { id = ipQuoteTaxRates.QuoteTaxRateId }, ipQuoteTaxRates);
        }

        // DELETE: api/IpQuoteTaxRates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpQuoteTaxRates>> DeleteIpQuoteTaxRates(int id)
        {
            var ipQuoteTaxRates = await _context.IpQuoteTaxRates.FindAsync(id);
            if (ipQuoteTaxRates == null)
            {
                return NotFound();
            }

            _context.IpQuoteTaxRates.Remove(ipQuoteTaxRates);
            await _context.SaveChangesAsync();

            return ipQuoteTaxRates;
        }

        private bool IpQuoteTaxRatesExists(int id)
        {
            return _context.IpQuoteTaxRates.Any(e => e.QuoteTaxRateId == id);
        }
    }
}
