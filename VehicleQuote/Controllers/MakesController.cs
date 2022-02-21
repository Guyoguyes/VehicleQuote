using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleQuote.Data;
using VehicleQuote.Models;

namespace VehicleQuote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly VehicleQuoteContext _context;

        public MakesController(VehicleQuoteContext context)
        {
            _context = context;
        }

        // GET: api/Makes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyType>>> GetBodyTypes()
        {
            return await _context.BodyTypes.ToListAsync();
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyType>> GetBodyType(int id)
        {
            var bodyType = await _context.BodyTypes.FindAsync(id);

            if (bodyType == null)
            {
                return NotFound();
            }

            return bodyType;
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyType(int id, BodyType bodyType)
        {
            if (id != bodyType.ID)
            {
                return BadRequest();
            }

            _context.Entry(bodyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return Conflict();
            }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!BodyTypeExists(id))
            //     {
            //         return NotFound();
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }

            return NoContent();
        }

        // POST: api/Makes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BodyType>> PostBodyType(BodyType bodyType)
        {
            _context.BodyTypes.Add(bodyType);
            // await _context.SaveChangesAsync();
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return Conflict();
            }

            return CreatedAtAction("GetBodyType", new { id = bodyType.ID }, bodyType);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodyType(int id)
        {
            var bodyType = await _context.BodyTypes.FindAsync(id);
            if (bodyType == null)
            {
                return NotFound();
            }

            _context.BodyTypes.Remove(bodyType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BodyTypeExists(int id)
        {
            return _context.BodyTypes.Any(e => e.ID == id);
        }
    }
}
