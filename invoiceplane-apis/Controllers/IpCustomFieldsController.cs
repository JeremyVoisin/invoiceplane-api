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
    public class IpCustomFieldsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpCustomFieldsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpCustomFields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpCustomFields>>> GetIpCustomFields()
        {
            return await _context.IpCustomFields.ToListAsync();
        }

        // GET: api/IpCustomFields/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpCustomFields>> GetIpCustomFields(int id)
        {
            var ipCustomFields = await _context.IpCustomFields.FindAsync(id);

            if (ipCustomFields == null)
            {
                return NotFound();
            }

            return ipCustomFields;
        }

        // PUT: api/IpCustomFields/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpCustomFields(int id, IpCustomFields ipCustomFields)
        {
            if (id != ipCustomFields.CustomFieldId)
            {
                return BadRequest();
            }

            _context.Entry(ipCustomFields).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpCustomFieldsExists(id))
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

        // POST: api/IpCustomFields
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpCustomFields>> PostIpCustomFields(IpCustomFields ipCustomFields)
        {
            _context.IpCustomFields.Add(ipCustomFields);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpCustomFields", new { id = ipCustomFields.CustomFieldId }, ipCustomFields);
        }

        // DELETE: api/IpCustomFields/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpCustomFields>> DeleteIpCustomFields(int id)
        {
            var ipCustomFields = await _context.IpCustomFields.FindAsync(id);
            if (ipCustomFields == null)
            {
                return NotFound();
            }

            _context.IpCustomFields.Remove(ipCustomFields);
            await _context.SaveChangesAsync();

            return ipCustomFields;
        }

        private bool IpCustomFieldsExists(int id)
        {
            return _context.IpCustomFields.Any(e => e.CustomFieldId == id);
        }
    }
}
