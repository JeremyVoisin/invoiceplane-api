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
    public class IpUserCustomController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpUserCustomController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpUserCustom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpUserCustom>>> GetIpUserCustom()
        {
            return await _context.IpUserCustom.ToListAsync();
        }

        // GET: api/IpUserCustom/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpUserCustom>> GetIpUserCustom(int id)
        {
            var ipUserCustom = await _context.IpUserCustom.FindAsync(id);

            if (ipUserCustom == null)
            {
                return NotFound();
            }

            return ipUserCustom;
        }

        // PUT: api/IpUserCustom/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpUserCustom(int id, IpUserCustom ipUserCustom)
        {
            if (id != ipUserCustom.UserCustomId)
            {
                return BadRequest();
            }

            _context.Entry(ipUserCustom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpUserCustomExists(id))
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

        // POST: api/IpUserCustom
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpUserCustom>> PostIpUserCustom(IpUserCustom ipUserCustom)
        {
            _context.IpUserCustom.Add(ipUserCustom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpUserCustom", new { id = ipUserCustom.UserCustomId }, ipUserCustom);
        }

        // DELETE: api/IpUserCustom/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpUserCustom>> DeleteIpUserCustom(int id)
        {
            var ipUserCustom = await _context.IpUserCustom.FindAsync(id);
            if (ipUserCustom == null)
            {
                return NotFound();
            }

            _context.IpUserCustom.Remove(ipUserCustom);
            await _context.SaveChangesAsync();

            return ipUserCustom;
        }

        private bool IpUserCustomExists(int id)
        {
            return _context.IpUserCustom.Any(e => e.UserCustomId == id);
        }
    }
}
