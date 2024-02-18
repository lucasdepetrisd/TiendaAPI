using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Data;
using Domain.Models;

namespace Domain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalleController : ControllerBase
    {
        private readonly ITiendaContext _context;

        public TalleController(ITiendaContext context)
        {
            _context = context;
        }

        // GET: api/Talle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Talle>>> GetTalle()
        {
          if (_context.Talle == null)
          {
              return NotFound();
          }
            return await _context.Talle.ToListAsync();
        }

        // GET: api/Talle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Talle>> GetTalle(int id)
        {
          if (_context.Talle == null)
          {
              return NotFound();
          }
            var talle = await _context.Talle.FindAsync(id);

            if (talle == null)
            {
                return NotFound();
            }

            return talle;
        }

        // PUT: api/Talle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTalle(int id, Talle talle)
        {
            if (id != talle.IdTalle)
            {
                return BadRequest();
            }

            _context.Talle.Entry(talle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TalleExists(id))
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

        // POST: api/Talle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Talle>> PostTalle(Talle talle)
        {
          if (_context.Talle == null)
          {
              return Problem("Entity set 'ITiendaContext.Talle'  is null.");
          }
            _context.Talle.Add(talle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTalle", new { id = talle.IdTalle }, talle);
        }

        // DELETE: api/Talle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTalle(int id)
        {
            if (_context.Talle == null)
            {
                return NotFound();
            }
            var talle = await _context.Talle.FindAsync(id);
            if (talle == null)
            {
                return NotFound();
            }

            _context.Talle.Remove(talle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TalleExists(int id)
        {
            return (_context.Talle?.Any(e => e.IdTalle == id)).GetValueOrDefault();
        }
    }
}
