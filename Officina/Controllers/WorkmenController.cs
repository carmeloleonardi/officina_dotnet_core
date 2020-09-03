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
    [Route("api/Workmen")]
    [ApiController]
    public class WorkmenController : ControllerBase
    {
        private readonly OfficinaContext _context;

        public WorkmenController(OfficinaContext context)
        {
            _context = context;
        }

        // GET: api/Workmen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workman>>> GetWorkmen()
        {
            return await _context.Workmen.ToListAsync();
        }

        // GET: api/Workmen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workman>> GetWorkman(long id)
        {
            var workman = await _context.Workmen.FindAsync(id);

            if (workman == null)
            {
                return NotFound();
            }

            return workman;
        }

        // PUT: api/Workmen/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkman(long id, Workman workman)
        {
            if (id != workman.WorkmanId)
            {
                return BadRequest();
            }

            _context.Entry(workman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkmanExists(id))
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

        // POST: api/Workmen
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Workman>> PostWorkman(Workman workman)
        {
            _context.Workmen.Add(workman);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkman", new { id = workman.WorkmanId }, workman);
        }

        // DELETE: api/Workmen/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Workman>> DeleteWorkman(long id)
        {
            var workman = await _context.Workmen.FindAsync(id);
            if (workman == null)
            {
                return NotFound();
            }

            _context.Workmen.Remove(workman);
            await _context.SaveChangesAsync();

            return workman;
        }

        private bool WorkmanExists(long id)
        {
            return _context.Workmen.Any(e => e.WorkmanId == id);
        }
    }
}
