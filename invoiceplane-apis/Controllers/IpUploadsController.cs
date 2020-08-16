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
    public class IpUploadsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpUploadsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpUploads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpUploads>>> GetIpUploads()
        {
            return await _context.IpUploads.ToListAsync();
        }

        // GET: api/IpUploads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpUploads>> GetIpUploads(int id)
        {
            var ipUploads = await _context.IpUploads.FindAsync(id);

            if (ipUploads == null)
            {
                return NotFound();
            }

            return ipUploads;
        }

        // PUT: api/IpUploads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpUploads(int id, IpUploads ipUploads)
        {
            if (id != ipUploads.UploadId)
            {
                return BadRequest();
            }

            _context.Entry(ipUploads).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpUploadsExists(id))
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

        // POST: api/IpUploads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpUploads>> PostIpUploads(IpUploads ipUploads)
        {
            _context.IpUploads.Add(ipUploads);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpUploads", new { id = ipUploads.UploadId }, ipUploads);
        }

        // DELETE: api/IpUploads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpUploads>> DeleteIpUploads(int id)
        {
            var ipUploads = await _context.IpUploads.FindAsync(id);
            if (ipUploads == null)
            {
                return NotFound();
            }

            _context.IpUploads.Remove(ipUploads);
            await _context.SaveChangesAsync();

            return ipUploads;
        }

        private bool IpUploadsExists(int id)
        {
            return _context.IpUploads.Any(e => e.UploadId == id);
        }
    }
}
