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
    public class IpUsersController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpUsersController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpUsers>>> GetIpUsers()
        {
            return await _context.IpUsers.ToListAsync();
        }

        // GET: api/IpUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpUsers>> GetIpUsers(int id)
        {
            var ipUsers = await _context.IpUsers.FindAsync(id);

            if (ipUsers == null)
            {
                return NotFound();
            }

            return ipUsers;
        }

        // PUT: api/IpUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpUsers(int id, IpUsers ipUsers)
        {
            if (id != ipUsers.UserId)
            {
                return BadRequest();
            }

            _context.Entry(ipUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpUsersExists(id))
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

        // POST: api/IpUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpUsers>> PostIpUsers(IpUsers ipUsers)
        {
            _context.IpUsers.Add(ipUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpUsers", new { id = ipUsers.UserId }, ipUsers);
        }

        // DELETE: api/IpUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpUsers>> DeleteIpUsers(int id)
        {
            var ipUsers = await _context.IpUsers.FindAsync(id);
            if (ipUsers == null)
            {
                return NotFound();
            }

            _context.IpUsers.Remove(ipUsers);
            await _context.SaveChangesAsync();

            return ipUsers;
        }

        private bool IpUsersExists(int id)
        {
            return _context.IpUsers.Any(e => e.UserId == id);
        }
    }
}
