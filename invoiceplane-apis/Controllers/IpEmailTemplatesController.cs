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
    public class IpEmailTemplatesController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpEmailTemplatesController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpEmailTemplates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpEmailTemplates>>> GetIpEmailTemplates()
        {
            return await _context.IpEmailTemplates.ToListAsync();
        }

        // GET: api/IpEmailTemplates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpEmailTemplates>> GetIpEmailTemplates(int id)
        {
            var ipEmailTemplates = await _context.IpEmailTemplates.FindAsync(id);

            if (ipEmailTemplates == null)
            {
                return NotFound();
            }

            return ipEmailTemplates;
        }

        // PUT: api/IpEmailTemplates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpEmailTemplates(int id, IpEmailTemplates ipEmailTemplates)
        {
            if (id != ipEmailTemplates.EmailTemplateId)
            {
                return BadRequest();
            }

            _context.Entry(ipEmailTemplates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpEmailTemplatesExists(id))
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

        // POST: api/IpEmailTemplates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpEmailTemplates>> PostIpEmailTemplates(IpEmailTemplates ipEmailTemplates)
        {
            _context.IpEmailTemplates.Add(ipEmailTemplates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpEmailTemplates", new { id = ipEmailTemplates.EmailTemplateId }, ipEmailTemplates);
        }

        // DELETE: api/IpEmailTemplates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpEmailTemplates>> DeleteIpEmailTemplates(int id)
        {
            var ipEmailTemplates = await _context.IpEmailTemplates.FindAsync(id);
            if (ipEmailTemplates == null)
            {
                return NotFound();
            }

            _context.IpEmailTemplates.Remove(ipEmailTemplates);
            await _context.SaveChangesAsync();

            return ipEmailTemplates;
        }

        private bool IpEmailTemplatesExists(int id)
        {
            return _context.IpEmailTemplates.Any(e => e.EmailTemplateId == id);
        }
    }
}
