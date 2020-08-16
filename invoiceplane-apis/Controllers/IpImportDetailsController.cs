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
    public class IpImportDetailsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpImportDetailsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpImportDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpImportDetails>>> GetIpImportDetails()
        {
            return await _context.IpImportDetails.ToListAsync();
        }

        // GET: api/IpImportDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpImportDetails>> GetIpImportDetails(int id)
        {
            var ipImportDetails = await _context.IpImportDetails.FindAsync(id);

            if (ipImportDetails == null)
            {
                return NotFound();
            }

            return ipImportDetails;
        }

        // PUT: api/IpImportDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpImportDetails(int id, IpImportDetails ipImportDetails)
        {
            if (id != ipImportDetails.ImportDetailId)
            {
                return BadRequest();
            }

            _context.Entry(ipImportDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpImportDetailsExists(id))
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

        // POST: api/IpImportDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpImportDetails>> PostIpImportDetails(IpImportDetails ipImportDetails)
        {
            _context.IpImportDetails.Add(ipImportDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpImportDetails", new { id = ipImportDetails.ImportDetailId }, ipImportDetails);
        }

        // DELETE: api/IpImportDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpImportDetails>> DeleteIpImportDetails(int id)
        {
            var ipImportDetails = await _context.IpImportDetails.FindAsync(id);
            if (ipImportDetails == null)
            {
                return NotFound();
            }

            _context.IpImportDetails.Remove(ipImportDetails);
            await _context.SaveChangesAsync();

            return ipImportDetails;
        }

        private bool IpImportDetailsExists(int id)
        {
            return _context.IpImportDetails.Any(e => e.ImportDetailId == id);
        }
    }
}
