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
    [Route("api/Employements")]
    [ApiController]
    public class EmployementsController : ControllerBase
    {
        private readonly OfficinaContext _context;

        public EmployementsController(OfficinaContext context)
        {
            _context = context;
        }

        // GET: api/Employements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employement>>> GetEmployements()
        {
            return await _context.Employements.ToListAsync();
        }

        // GET: api/Employements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employement>> GetEmployement(long id)
        {
            var employement = await _context.Employements.FindAsync(id);

            if (employement == null)
            {
                return NotFound();
            }

            return employement;
        }

        // PUT: api/Employements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployement(long id, Employement employement)
        {
            if (id != employement.OperationId)
            {
                return BadRequest();
            }

            _context.Entry(employement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployementExists(id))
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

        // POST: api/Employements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employement>> PostEmployement(Employement employement)
        {
            _context.Employements.Add(employement);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployementExists(employement.OperationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployement", new { id = employement.OperationId }, employement);
        }

        // DELETE: api/Employements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employement>> DeleteEmployement(long id)
        {
            var employement = await _context.Employements.FindAsync(id);
            if (employement == null)
            {
                return NotFound();
            }

            _context.Employements.Remove(employement);
            await _context.SaveChangesAsync();

            return employement;
        }

        private bool EmployementExists(long id)
        {
            return _context.Employements.Any(e => e.OperationId == id);
        }
    }
}
