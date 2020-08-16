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
    public class IpSettingsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpSettingsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpSettings>>> GetIpSettings()
        {
            return await _context.IpSettings.ToListAsync();
        }

        // GET: api/IpSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpSettings>> GetIpSettings(int id)
        {
            var ipSettings = await _context.IpSettings.FindAsync(id);

            if (ipSettings == null)
            {
                return NotFound();
            }

            return ipSettings;
        }

        // PUT: api/IpSettings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpSettings(int id, IpSettings ipSettings)
        {
            if (id != ipSettings.SettingId)
            {
                return BadRequest();
            }

            _context.Entry(ipSettings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpSettingsExists(id))
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

        // POST: api/IpSettings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpSettings>> PostIpSettings(IpSettings ipSettings)
        {
            _context.IpSettings.Add(ipSettings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpSettings", new { id = ipSettings.SettingId }, ipSettings);
        }

        // DELETE: api/IpSettings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpSettings>> DeleteIpSettings(int id)
        {
            var ipSettings = await _context.IpSettings.FindAsync(id);
            if (ipSettings == null)
            {
                return NotFound();
            }

            _context.IpSettings.Remove(ipSettings);
            await _context.SaveChangesAsync();

            return ipSettings;
        }

        private bool IpSettingsExists(int id)
        {
            return _context.IpSettings.Any(e => e.SettingId == id);
        }
    }
}
