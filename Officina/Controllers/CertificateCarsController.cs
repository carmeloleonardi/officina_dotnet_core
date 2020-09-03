using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Officina.Context;
using Officina.Models;

namespace Officina.Controllers
{
    [Route("api/CertificateCars")]
    [ApiController]
    public class CertificateCarsController : ControllerBase
    {
        private readonly OfficinaContext _context;

        public CertificateCarsController(OfficinaContext context)
        {
            _context = context;
        }

        // GET: api/CertificateCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificateCar>>> GetCertificateCars()
        {
            return await _context.CertificateCars.ToListAsync();
        }

        // GET: api/CertificateCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificateCar>> GetCertificateCar(long id)
        {
            var certificateCar = await _context.CertificateCars.FindAsync(id);

            if (certificateCar == null)
            {
                return NotFound();
            }

            return certificateCar;
        }

        // PUT: api/CertificateCars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificateCar(long id, CertificateCar certificateCar)
        {
            if (id != certificateCar.CertificateCarID)
            {
                return BadRequest();
            }

            _context.Entry(certificateCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificateCarExists(id))
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

        // POST: api/CertificateCars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CertificateCar>> PostCertificateCar(CertificateCar certificateCar)
        {
            _context.CertificateCars.Add(certificateCar);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CertificateCarExists(certificateCar.CertificateCarID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCertificateCar", new { id = certificateCar.CertificateCarID }, certificateCar);
        }

        // DELETE: api/CertificateCars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CertificateCar>> DeleteCertificateCar(long id)
        {
            var certificateCar = await _context.CertificateCars.FindAsync(id);
            if (certificateCar == null)
            {
                return NotFound();
            }

            _context.CertificateCars.Remove(certificateCar);
            await _context.SaveChangesAsync();

            return certificateCar;
        }

        private bool CertificateCarExists(long id)
        {
            return _context.CertificateCars.Any(e => e.CertificateCarID == id);
        }
    }
}
