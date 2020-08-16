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
    public class IpProductsController : ControllerBase
    {
        private readonly invoiceplane_dbContext _context;

        public IpProductsController(invoiceplane_dbContext context)
        {
            _context = context;
        }

        // GET: api/IpProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpProducts>>> GetIpProducts()
        {
            return await _context.IpProducts.ToListAsync();
        }

        // GET: api/IpProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IpProducts>> GetIpProducts(int id)
        {
            var ipProducts = await _context.IpProducts.FindAsync(id);

            if (ipProducts == null)
            {
                return NotFound();
            }

            return ipProducts;
        }

        // PUT: api/IpProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIpProducts(int id, IpProducts ipProducts)
        {
            if (id != ipProducts.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(ipProducts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpProductsExists(id))
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

        // POST: api/IpProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IpProducts>> PostIpProducts(IpProducts ipProducts)
        {
            _context.IpProducts.Add(ipProducts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIpProducts", new { id = ipProducts.ProductId }, ipProducts);
        }

        // DELETE: api/IpProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IpProducts>> DeleteIpProducts(int id)
        {
            var ipProducts = await _context.IpProducts.FindAsync(id);
            if (ipProducts == null)
            {
                return NotFound();
            }

            _context.IpProducts.Remove(ipProducts);
            await _context.SaveChangesAsync();

            return ipProducts;
        }

        private bool IpProductsExists(int id)
        {
            return _context.IpProducts.Any(e => e.ProductId == id);
        }
    }
}
