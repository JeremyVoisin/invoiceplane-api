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
    public class IpClientCustomController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpClientCustomController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpClientCustom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpClientCustom>>> GetIpClientCustom()
        {
            return await _context.IpClientCustom.ToListAsync();
        }

        // GET: api/IpClientCustom/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpClientCustom>> GetIpClientCustom(int id)
        {
            var ipClientCustom = await _context.IpClientCustom.FindAsync(id);

            if (ipClientCustom == null)
            {
                return NotFound();
            }

            return ipClientCustom;
        }

        // PUT: api/IpClientCustom/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpClientCustom(int id, IpClientCustom ipClientCustom)
        {
            if (id != ipClientCustom.ClientCustomId)
            {
                return BadRequest();
            }

            _context.Entry(ipClientCustom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpClientCustomExists(id))
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

        // POST: api/IpClientCustom
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpClientCustom>> PostIpClientCustom(IpClientCustom ipClientCustom)
        {
            _context.IpClientCustom.Add(ipClientCustom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpClientCustom", new { id = ipClientCustom.ClientCustomId }, ipClientCustom);
        }

        // DELETE: api/IpClientCustom/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpClientCustom>> DeleteIpClientCustom(int id)
        {
            var ipClientCustom = await _context.IpClientCustom.FindAsync(id);
            if (ipClientCustom == null)
            {
                return NotFound();
            }

            _context.IpClientCustom.Remove(ipClientCustom);
            await _context.SaveChangesAsync();

            return ipClientCustom;
        }

        private bool IpClientCustomExists(int id)
        {
            return _context.IpClientCustom.Any(e => e.ClientCustomId == id);
        }
    }
}
