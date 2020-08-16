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
    public class IpUserClientsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpUserClientsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpUserClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpUserClients>>> GetIpUserClients()
        {
            return await _context.IpUserClients.ToListAsync();
        }

        // GET: api/IpUserClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpUserClients>> GetIpUserClients(int id)
        {
            var ipUserClients = await _context.IpUserClients.FindAsync(id);

            if (ipUserClients == null)
            {
                return NotFound();
            }

            return ipUserClients;
        }

        // PUT: api/IpUserClients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpUserClients(int id, IpUserClients ipUserClients)
        {
            if (id != ipUserClients.UserClientId)
            {
                return BadRequest();
            }

            _context.Entry(ipUserClients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpUserClientsExists(id))
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

        // POST: api/IpUserClients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpUserClients>> PostIpUserClients(IpUserClients ipUserClients)
        {
            _context.IpUserClients.Add(ipUserClients);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpUserClients", new { id = ipUserClients.UserClientId }, ipUserClients);
        }

        // DELETE: api/IpUserClients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpUserClients>> DeleteIpUserClients(int id)
        {
            var ipUserClients = await _context.IpUserClients.FindAsync(id);
            if (ipUserClients == null)
            {
                return NotFound();
            }

            _context.IpUserClients.Remove(ipUserClients);
            await _context.SaveChangesAsync();

            return ipUserClients;
        }

        private bool IpUserClientsExists(int id)
        {
            return _context.IpUserClients.Any(e => e.UserClientId == id);
        }
    }
}
