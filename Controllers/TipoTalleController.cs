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
    public class TipoTalleController : ControllerBase
    {
        private readonly TiendaContext _context;

        public TipoTalleController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/TipoTalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTalle>>> GetTipoTalle()
        {
          if (_context.TipoTalle == null)
          {
              return NotFound();
          }
            return await _context.TipoTalle.ToListAsync();
        }

        // GET: api/TipoTalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTalle>> GetTipoTalle(int id)
        {
          if (_context.TipoTalle == null)
          {
              return NotFound();
          }
            var tipoTalle = await _context.TipoTalle.FindAsync(id);

            if (tipoTalle == null)
            {
                return NotFound();
            }

            return tipoTalle;
        }

        // PUT: api/TipoTalle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoTalle(int id, TipoTalle tipoTalle)
        {
            if (id != tipoTalle.IdTipoTalle)
            {
                return BadRequest();
            }

            _context.Entry(tipoTalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTalleExists(id))
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

        // POST: api/TipoTalle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoTalle>> PostTipoTalle(TipoTalle tipoTalle)
        {
          if (_context.TipoTalle == null)
          {
              return Problem("Entity set 'TiendaContext.TipoTalle'  is null.");
          }
            _context.TipoTalle.Add(tipoTalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoTalle", new { id = tipoTalle.IdTipoTalle }, tipoTalle);
        }

        // DELETE: api/TipoTalle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoTalle(int id)
        {
            if (_context.TipoTalle == null)
            {
                return NotFound();
            }
            var tipoTalle = await _context.TipoTalle.FindAsync(id);
            if (tipoTalle == null)
            {
                return NotFound();
            }

            _context.TipoTalle.Remove(tipoTalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoTalleExists(int id)
        {
            return (_context.TipoTalle?.Any(e => e.IdTipoTalle == id)).GetValueOrDefault();
        }
    }
}
