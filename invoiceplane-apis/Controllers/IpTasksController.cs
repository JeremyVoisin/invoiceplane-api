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
    public class IpTasksController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpTasksController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpTasks>>> GetIpTasks()
        {
            return await _context.IpTasks.ToListAsync();
        }

        // GET: api/IpTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpTasks>> GetIpTasks(int id)
        {
            var ipTasks = await _context.IpTasks.FindAsync(id);

            if (ipTasks == null)
            {
                return NotFound();
            }

            return ipTasks;
        }

        // PUT: api/IpTasks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpTasks(int id, IpTasks ipTasks)
        {
            if (id != ipTasks.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(ipTasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpTasksExists(id))
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

        // POST: api/IpTasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpTasks>> PostIpTasks(IpTasks ipTasks)
        {
            _context.IpTasks.Add(ipTasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpTasks", new { id = ipTasks.TaskId }, ipTasks);
        }

        // DELETE: api/IpTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpTasks>> DeleteIpTasks(int id)
        {
            var ipTasks = await _context.IpTasks.FindAsync(id);
            if (ipTasks == null)
            {
                return NotFound();
            }

            _context.IpTasks.Remove(ipTasks);
            await _context.SaveChangesAsync();

            return ipTasks;
        }

        private bool IpTasksExists(int id)
        {
            return _context.IpTasks.Any(e => e.TaskId == id);
        }
    }
}
