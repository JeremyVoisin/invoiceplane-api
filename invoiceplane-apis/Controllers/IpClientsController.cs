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
    public class IpClientsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpClientsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpClients>>> GetIpClients()
        {
            return await _context.IpClients.ToListAsync();
        }

        // GET: api/IpClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpClients>> GetIpClients(int id)
        {
            var ipClients = await _context.IpClients.FindAsync(id);

            if (ipClients == null)
            {
                return NotFound();
            }

            return ipClients;
        }

        // PUT: api/IpClients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpClients(int id, IpClients ipClients)
        {
            if (id != ipClients.ClientId)
            {
                return BadRequest();
            }

            _context.Entry(ipClients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpClientsExists(id))
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

        // POST: api/IpClients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpClients>> PostIpClients(IpClients ipClients)
        {
            _context.IpClients.Add(ipClients);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpClients", new { id = ipClients.ClientId }, ipClients);
        }

        // DELETE: api/IpClients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpClients>> DeleteIpClients(int id)
        {
            var ipClients = await _context.IpClients.FindAsync(id);
            if (ipClients == null)
            {
                return NotFound();
            }

            _context.IpClients.Remove(ipClients);
            await _context.SaveChangesAsync();

            return ipClients;
        }

        private bool IpClientsExists(int id)
        {
            return _context.IpClients.Any(e => e.ClientId == id);
        }
    }
}
