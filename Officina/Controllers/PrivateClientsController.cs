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
    [Route("api/PrivateClients")]
    [ApiController]
    public class PrivateClientsController : ControllerBase
    {
        private readonly OfficinaContext _context;

        public PrivateClientsController(OfficinaContext context)
        {
            _context = context;
        }

        // GET: api/PrivateClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrivateClient>>> GetPrivateClients()
        {
            return await _context.PrivateClients.ToListAsync();
        }

        // GET: api/PrivateClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrivateClient>> GetPrivateClient(long id)
        {
            var privateClient = await _context.PrivateClients.FindAsync(id);

            if (privateClient == null)
            {
                return NotFound();
            }

            return privateClient;
        }

        // PUT: api/PrivateClients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrivateClient(long id, PrivateClient privateClient)
        {
            if (id != privateClient.ClientId)
            {
                return BadRequest();
            }

            _context.Entry(privateClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivateClientExists(id))
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

        // POST: api/PrivateClients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PrivateClient>> PostPrivateClient(PrivateClient privateClient)
        {
            _context.PrivateClients.Add(privateClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrivateClient", new { id = privateClient.ClientId }, privateClient);
        }

        // DELETE: api/PrivateClients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrivateClient>> DeletePrivateClient(long id)
        {
            var privateClient = await _context.PrivateClients.FindAsync(id);
            if (privateClient == null)
            {
                return NotFound();
            }

            _context.PrivateClients.Remove(privateClient);
            await _context.SaveChangesAsync();

            return privateClient;
        }

        private bool PrivateClientExists(long id)
        {
            return _context.PrivateClients.Any(e => e.ClientId == id);
        }
    }
}
