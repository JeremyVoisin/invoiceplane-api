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
    public class IpInvoiceCustomController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpInvoiceCustomController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpInvoiceCustom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpInvoiceCustom>>> GetIpInvoiceCustom()
        {
            return await _context.IpInvoiceCustom.ToListAsync();
        }

        // GET: api/IpInvoiceCustom/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpInvoiceCustom>> GetIpInvoiceCustom(int id)
        {
            var ipInvoiceCustom = await _context.IpInvoiceCustom.FindAsync(id);

            if (ipInvoiceCustom == null)
            {
                return NotFound();
            }

            return ipInvoiceCustom;
        }

        // PUT: api/IpInvoiceCustom/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpInvoiceCustom(int id, IpInvoiceCustom ipInvoiceCustom)
        {
            if (id != ipInvoiceCustom.InvoiceCustomId)
            {
                return BadRequest();
            }

            _context.Entry(ipInvoiceCustom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpInvoiceCustomExists(id))
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

        // POST: api/IpInvoiceCustom
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpInvoiceCustom>> PostIpInvoiceCustom(IpInvoiceCustom ipInvoiceCustom)
        {
            _context.IpInvoiceCustom.Add(ipInvoiceCustom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpInvoiceCustom", new { id = ipInvoiceCustom.InvoiceCustomId }, ipInvoiceCustom);
        }

        // DELETE: api/IpInvoiceCustom/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpInvoiceCustom>> DeleteIpInvoiceCustom(int id)
        {
            var ipInvoiceCustom = await _context.IpInvoiceCustom.FindAsync(id);
            if (ipInvoiceCustom == null)
            {
                return NotFound();
            }

            _context.IpInvoiceCustom.Remove(ipInvoiceCustom);
            await _context.SaveChangesAsync();

            return ipInvoiceCustom;
        }

        private bool IpInvoiceCustomExists(int id)
        {
            return _context.IpInvoiceCustom.Any(e => e.InvoiceCustomId == id);
        }
    }
}
