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
    public class IpTaxRatesController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpTaxRatesController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpTaxRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpTaxRates>>> GetIpTaxRates()
        {
            return await _context.IpTaxRates.ToListAsync();
        }

        // GET: api/IpTaxRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpTaxRates>> GetIpTaxRates(int id)
        {
            var ipTaxRates = await _context.IpTaxRates.FindAsync(id);

            if (ipTaxRates == null)
            {
                return NotFound();
            }

            return ipTaxRates;
        }

        // PUT: api/IpTaxRates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpTaxRates(int id, IpTaxRates ipTaxRates)
        {
            if (id != ipTaxRates.TaxRateId)
            {
                return BadRequest();
            }

            _context.Entry(ipTaxRates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpTaxRatesExists(id))
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

        // POST: api/IpTaxRates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpTaxRates>> PostIpTaxRates(IpTaxRates ipTaxRates)
        {
            _context.IpTaxRates.Add(ipTaxRates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpTaxRates", new { id = ipTaxRates.TaxRateId }, ipTaxRates);
        }

        // DELETE: api/IpTaxRates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpTaxRates>> DeleteIpTaxRates(int id)
        {
            var ipTaxRates = await _context.IpTaxRates.FindAsync(id);
            if (ipTaxRates == null)
            {
                return NotFound();
            }

            _context.IpTaxRates.Remove(ipTaxRates);
            await _context.SaveChangesAsync();

            return ipTaxRates;
        }

        private bool IpTaxRatesExists(int id)
        {
            return _context.IpTaxRates.Any(e => e.TaxRateId == id);
        }
    }
}
