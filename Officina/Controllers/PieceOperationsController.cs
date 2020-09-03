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
    [Route("api/[controller]")]
    [ApiController]
    public class PieceOperationsController : ControllerBase
    {
        private readonly OfficinaContext _context;

        public PieceOperationsController(OfficinaContext context)
        {
            _context = context;
        }

        // GET: api/PieceOperations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PieceOperation>>> GetPieceOperations()
        {
            return await _context.PieceOperations.ToListAsync();
        }

        // GET: api/PieceOperations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PieceOperation>> GetPieceOperation(long id)
        {
            var pieceOperation = await _context.PieceOperations.FindAsync(id);

            if (pieceOperation == null)
            {
                return NotFound();
            }

            return pieceOperation;
        }

        // PUT: api/PieceOperations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPieceOperation(long id, PieceOperation pieceOperation)
        {
            if (id != pieceOperation.OperationId)
            {
                return BadRequest();
            }

            _context.Entry(pieceOperation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PieceOperationExists(id))
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

        // POST: api/PieceOperations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PieceOperation>> PostPieceOperation(PieceOperation pieceOperation)
        {
            _context.PieceOperations.Add(pieceOperation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PieceOperationExists(pieceOperation.OperationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPieceOperation", new { id = pieceOperation.OperationId }, pieceOperation);
        }

        // DELETE: api/PieceOperations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PieceOperation>> DeletePieceOperation(long id)
        {
            var pieceOperation = await _context.PieceOperations.FindAsync(id);
            if (pieceOperation == null)
            {
                return NotFound();
            }

            _context.PieceOperations.Remove(pieceOperation);
            await _context.SaveChangesAsync();

            return pieceOperation;
        }

        private bool PieceOperationExists(long id)
        {
            return _context.PieceOperations.Any(e => e.OperationId == id);
        }
    }
}
