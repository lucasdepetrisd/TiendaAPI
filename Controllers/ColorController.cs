using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.Models;

namespace TiendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly TiendaContext _context;

        public ColorController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/Color
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>> GetColor()
        {
          if (_context.Color == null)
          {
              return NotFound();
          }
            return await _context.Color.ToListAsync();
        }

        // GET: api/Color/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetColor(int id)
        {
          if (_context.Color == null)
          {
              return NotFound();
          }
            var color = await _context.Color.FindAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            return color;
        }

        // PUT: api/Color/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(int id, Color color)
        {
            if (id != color.IdColor)
            {
                return BadRequest();
            }

            _context.Entry(color).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(id))
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

        // POST: api/Color
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Color>> PostColor(Color color)
        {
          if (_context.Color == null)
          {
              return Problem("Entity set 'TiendaContext.Color'  is null.");
          }
            _context.Color.Add(color);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColor", new { id = color.IdColor }, color);
        }

        // DELETE: api/Color/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            if (_context.Color == null)
            {
                return NotFound();
            }
            var color = await _context.Color.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }

            _context.Color.Remove(color);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColorExists(int id)
        {
            return (_context.Color?.Any(e => e.IdColor == id)).GetValueOrDefault();
        }
    }
}
