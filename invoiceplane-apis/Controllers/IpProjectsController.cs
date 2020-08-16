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
    public class IpProjectsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpProjectsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpProjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpProjects>>> GetIpProjects()
        {
            return await _context.IpProjects.ToListAsync();
        }

        // GET: api/IpProjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpProjects>> GetIpProjects(int id)
        {
            var ipProjects = await _context.IpProjects.FindAsync(id);

            if (ipProjects == null)
            {
                return NotFound();
            }

            return ipProjects;
        }

        // PUT: api/IpProjects/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpProjects(int id, IpProjects ipProjects)
        {
            if (id != ipProjects.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(ipProjects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpProjectsExists(id))
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

        // POST: api/IpProjects
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpProjects>> PostIpProjects(IpProjects ipProjects)
        {
            _context.IpProjects.Add(ipProjects);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpProjects", new { id = ipProjects.ProjectId }, ipProjects);
        }

        // DELETE: api/IpProjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpProjects>> DeleteIpProjects(int id)
        {
            var ipProjects = await _context.IpProjects.FindAsync(id);
            if (ipProjects == null)
            {
                return NotFound();
            }

            _context.IpProjects.Remove(ipProjects);
            await _context.SaveChangesAsync();

            return ipProjects;
        }

        private bool IpProjectsExists(int id)
        {
            return _context.IpProjects.Any(e => e.ProjectId == id);
        }
    }
}
