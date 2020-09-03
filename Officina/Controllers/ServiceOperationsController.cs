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
    [Route("api/ServiceOperations")]
    [ApiController]
    public class ServiceOperationsController : ControllerBase
    {
        private readonly OfficinaContext _context;

        public ServiceOperationsController(OfficinaContext context)
        {
            _context = context;
        }

        // GET: api/ServiceOperations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceOperation>>> GetServiceOperations()
        {
            return await _context.ServiceOperations.ToListAsync();
        }

        // GET: api/ServiceOperations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceOperation>> GetServiceOperation(long id)
        {
            var serviceOperation = await _context.ServiceOperations.FindAsync(id);

            if (serviceOperation == null)
            {
                return NotFound();
            }

            return serviceOperation;
        }

        // PUT: api/ServiceOperations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceOperation(long id, ServiceOperation serviceOperation)
        {
            if (id != serviceOperation.OperationId)
            {
                return BadRequest();
            }

            _context.Entry(serviceOperation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceOperationExists(id))
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

        // POST: api/ServiceOperations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ServiceOperation>> PostServiceOperation(ServiceOperation serviceOperation)
        {
            _context.ServiceOperations.Add(serviceOperation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServiceOperationExists(serviceOperation.OperationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetServiceOperation", new { id = serviceOperation.OperationId }, serviceOperation);
        }

        // DELETE: api/ServiceOperations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceOperation>> DeleteServiceOperation(long id)
        {
            var serviceOperation = await _context.ServiceOperations.FindAsync(id);
            if (serviceOperation == null)
            {
                return NotFound();
            }

            _context.ServiceOperations.Remove(serviceOperation);
            await _context.SaveChangesAsync();

            return serviceOperation;
        }

        private bool ServiceOperationExists(long id)
        {
            return _context.ServiceOperations.Any(e => e.OperationId == id);
        }
    }
}
