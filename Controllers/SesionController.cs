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
    public class SesionController : ControllerBase
    {
        private readonly TiendaContext _context;

        public SesionController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/Sesion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sesion>>> GetSesion()
        {
          if (_context.Sesion == null)
          {
              return NotFound();
          }
            return await _context.Sesion.ToListAsync();
        }

        // GET: api/Sesion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sesion>> GetSesion(int id)
        {
          if (_context.Sesion == null)
          {
              return NotFound();
          }
            var sesion = await _context.Sesion.FindAsync(id);

            if (sesion == null)
            {
                return NotFound();
            }

            return sesion;
        }

        // PUT: api/Sesion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSesion(int id, Sesion sesion)
        {
            if (id != sesion.IdSesion)
            {
                return BadRequest();
            }

            _context.Entry(sesion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SesionExists(id))
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

        // POST: api/Sesion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sesion>> PostSesion(Sesion sesion)
        {
          if (_context.Sesion == null)
          {
              return Problem("Entity set 'TiendaContext.Sesion'  is null.");
          }
            _context.Sesion.Add(sesion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSesion", new { id = sesion.IdSesion }, sesion);
        }

        // DELETE: api/Sesion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSesion(int id)
        {
            if (_context.Sesion == null)
            {
                return NotFound();
            }
            var sesion = await _context.Sesion.FindAsync(id);
            if (sesion == null)
            {
                return NotFound();
            }

            _context.Sesion.Remove(sesion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SesionExists(int id)
        {
            return (_context.Sesion?.Any(e => e.IdSesion == id)).GetValueOrDefault();
        }
    }
}
