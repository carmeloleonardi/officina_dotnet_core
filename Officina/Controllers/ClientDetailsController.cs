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
    [Route("api/ClientDetails")]
    [ApiController]
    public class ClientDetailsController : ControllerBase
    {
        private readonly OfficinaContext _context;

        public ClientDetailsController(OfficinaContext context)
        {
            _context = context;
        }

        // GET: api/ClientDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDetail>>> GetClientDetails()
        {
            return await _context.ClientDetails.ToListAsync();
        }

        // GET: api/ClientDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDetail>> GetClientDetail(long id)
        {
            var clientDetail = await _context.ClientDetails.FindAsync(id);

            if (clientDetail == null)
            {
                return NotFound();
            }

            return clientDetail;
        }

        // PUT: api/ClientDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientDetail(long id, ClientDetail clientDetail)
        {
            if (id != clientDetail.ClientDetailId)
            {
                return BadRequest();
            }

            _context.Entry(clientDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientDetailExists(id))
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

        // POST: api/ClientDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClientDetail>> PostClientDetail(ClientDetail clientDetail)
        {
            _context.ClientDetails.Add(clientDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientDetail", new { id = clientDetail.ClientDetailId }, clientDetail);
        }

        // DELETE: api/ClientDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientDetail>> DeleteClientDetail(long id)
        {
            var clientDetail = await _context.ClientDetails.FindAsync(id);
            if (clientDetail == null)
            {
                return NotFound();
            }

            _context.ClientDetails.Remove(clientDetail);
            await _context.SaveChangesAsync();

            return clientDetail;
        }

        private bool ClientDetailExists(long id)
        {
            return _context.ClientDetails.Any(e => e.ClientDetailId == id);
        }
    }
}
