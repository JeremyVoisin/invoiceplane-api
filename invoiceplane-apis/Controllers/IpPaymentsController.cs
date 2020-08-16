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
    public class IpPaymentsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpPaymentsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpPayments>>> GetIpPayments()
        {
            return await _context.IpPayments.ToListAsync();
        }

        // GET: api/IpPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpPayments>> GetIpPayments(int id)
        {
            var ipPayments = await _context.IpPayments.FindAsync(id);

            if (ipPayments == null)
            {
                return NotFound();
            }

            return ipPayments;
        }

        // PUT: api/IpPayments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpPayments(int id, IpPayments ipPayments)
        {
            if (id != ipPayments.PaymentId)
            {
                return BadRequest();
            }

            _context.Entry(ipPayments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpPaymentsExists(id))
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

        // POST: api/IpPayments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpPayments>> PostIpPayments(IpPayments ipPayments)
        {
            _context.IpPayments.Add(ipPayments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpPayments", new { id = ipPayments.PaymentId }, ipPayments);
        }

        // DELETE: api/IpPayments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpPayments>> DeleteIpPayments(int id)
        {
            var ipPayments = await _context.IpPayments.FindAsync(id);
            if (ipPayments == null)
            {
                return NotFound();
            }

            _context.IpPayments.Remove(ipPayments);
            await _context.SaveChangesAsync();

            return ipPayments;
        }

        private bool IpPaymentsExists(int id)
        {
            return _context.IpPayments.Any(e => e.PaymentId == id);
        }
    }
}
