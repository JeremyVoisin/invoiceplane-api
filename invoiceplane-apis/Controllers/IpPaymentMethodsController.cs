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
    public class IpPaymentMethodsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpPaymentMethodsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpPaymentMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpPaymentMethods>>> GetIpPaymentMethods()
        {
            return await _context.IpPaymentMethods.ToListAsync();
        }

        // GET: api/IpPaymentMethods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpPaymentMethods>> GetIpPaymentMethods(int id)
        {
            var ipPaymentMethods = await _context.IpPaymentMethods.FindAsync(id);

            if (ipPaymentMethods == null)
            {
                return NotFound();
            }

            return ipPaymentMethods;
        }

        // PUT: api/IpPaymentMethods/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpPaymentMethods(int id, IpPaymentMethods ipPaymentMethods)
        {
            if (id != ipPaymentMethods.PaymentMethodId)
            {
                return BadRequest();
            }

            _context.Entry(ipPaymentMethods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpPaymentMethodsExists(id))
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

        // POST: api/IpPaymentMethods
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpPaymentMethods>> PostIpPaymentMethods(IpPaymentMethods ipPaymentMethods)
        {
            _context.IpPaymentMethods.Add(ipPaymentMethods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpPaymentMethods", new { id = ipPaymentMethods.PaymentMethodId }, ipPaymentMethods);
        }

        // DELETE: api/IpPaymentMethods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpPaymentMethods>> DeleteIpPaymentMethods(int id)
        {
            var ipPaymentMethods = await _context.IpPaymentMethods.FindAsync(id);
            if (ipPaymentMethods == null)
            {
                return NotFound();
            }

            _context.IpPaymentMethods.Remove(ipPaymentMethods);
            await _context.SaveChangesAsync();

            return ipPaymentMethods;
        }

        private bool IpPaymentMethodsExists(int id)
        {
            return _context.IpPaymentMethods.Any(e => e.PaymentMethodId == id);
        }
    }
}
