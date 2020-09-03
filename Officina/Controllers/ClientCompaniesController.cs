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
    [Route("api/ClientCompanies")]
    [ApiController]
    public class ClientCompaniesController : ControllerBase
    {
        private readonly OfficinaContext _context;

        public ClientCompaniesController(OfficinaContext context)
        {
            _context = context;
        }

        // GET: api/ClientCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientCompany>>> GetClientCompanies()
        {
            return await _context.ClientCompanies.ToListAsync();
        }

        // GET: api/ClientCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientCompany>> GetClientCompany(long id)
        {
            var clientCompany = await _context.ClientCompanies.FindAsync(id);

            if (clientCompany == null)
            {
                return NotFound();
            }

            return clientCompany;
        }

        // PUT: api/ClientCompanies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientCompany(long id, ClientCompany clientCompany)
        {
            if (id != clientCompany.ClientId)
            {
                return BadRequest();
            }

            _context.Entry(clientCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientCompanyExists(id))
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

        // POST: api/ClientCompanies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClientCompany>> PostClientCompany(ClientCompany clientCompany)
        {
            _context.ClientCompanies.Add(clientCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientCompany", new { id = clientCompany.ClientId }, clientCompany);
        }

        // DELETE: api/ClientCompanies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientCompany>> DeleteClientCompany(long id)
        {
            var clientCompany = await _context.ClientCompanies.FindAsync(id);
            if (clientCompany == null)
            {
                return NotFound();
            }

            _context.ClientCompanies.Remove(clientCompany);
            await _context.SaveChangesAsync();

            return clientCompany;
        }

        private bool ClientCompanyExists(long id)
        {
            return _context.ClientCompanies.Any(e => e.ClientId == id);
        }
    }
}
