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
    public class IpPaymentCustomController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpPaymentCustomController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpPaymentCustom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpPaymentCustom>>> GetIpPaymentCustom()
        {
            return await _context.IpPaymentCustom.ToListAsync();
        }

        // GET: api/IpPaymentCustom/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpPaymentCustom>> GetIpPaymentCustom(int id)
        {
            var ipPaymentCustom = await _context.IpPaymentCustom.FindAsync(id);

            if (ipPaymentCustom == null)
            {
                return NotFound();
            }

            return ipPaymentCustom;
        }

        // PUT: api/IpPaymentCustom/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpPaymentCustom(int id, IpPaymentCustom ipPaymentCustom)
        {
            if (id != ipPaymentCustom.PaymentCustomId)
            {
                return BadRequest();
            }

            _context.Entry(ipPaymentCustom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpPaymentCustomExists(id))
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

        // POST: api/IpPaymentCustom
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpPaymentCustom>> PostIpPaymentCustom(IpPaymentCustom ipPaymentCustom)
        {
            _context.IpPaymentCustom.Add(ipPaymentCustom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpPaymentCustom", new { id = ipPaymentCustom.PaymentCustomId }, ipPaymentCustom);
        }

        // DELETE: api/IpPaymentCustom/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpPaymentCustom>> DeleteIpPaymentCustom(int id)
        {
            var ipPaymentCustom = await _context.IpPaymentCustom.FindAsync(id);
            if (ipPaymentCustom == null)
            {
                return NotFound();
            }

            _context.IpPaymentCustom.Remove(ipPaymentCustom);
            await _context.SaveChangesAsync();

            return ipPaymentCustom;
        }

        private bool IpPaymentCustomExists(int id)
        {
            return _context.IpPaymentCustom.Any(e => e.PaymentCustomId == id);
        }
    }
}
