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
    public class IpClientNotesController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpClientNotesController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpClientNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpClientNotes>>> GetIpClientNotes()
        {
            return await _context.IpClientNotes.ToListAsync();
        }

        // GET: api/IpClientNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpClientNotes>> GetIpClientNotes(int id)
        {
            var ipClientNotes = await _context.IpClientNotes.FindAsync(id);

            if (ipClientNotes == null)
            {
                return NotFound();
            }

            return ipClientNotes;
        }

        // PUT: api/IpClientNotes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpClientNotes(int id, IpClientNotes ipClientNotes)
        {
            if (id != ipClientNotes.ClientNoteId)
            {
                return BadRequest();
            }

            _context.Entry(ipClientNotes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpClientNotesExists(id))
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

        // POST: api/IpClientNotes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpClientNotes>> PostIpClientNotes(IpClientNotes ipClientNotes)
        {
            _context.IpClientNotes.Add(ipClientNotes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpClientNotes", new { id = ipClientNotes.ClientNoteId }, ipClientNotes);
        }

        // DELETE: api/IpClientNotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpClientNotes>> DeleteIpClientNotes(int id)
        {
            var ipClientNotes = await _context.IpClientNotes.FindAsync(id);
            if (ipClientNotes == null)
            {
                return NotFound();
            }

            _context.IpClientNotes.Remove(ipClientNotes);
            await _context.SaveChangesAsync();

            return ipClientNotes;
        }

        private bool IpClientNotesExists(int id)
        {
            return _context.IpClientNotes.Any(e => e.ClientNoteId == id);
        }
    }
}
