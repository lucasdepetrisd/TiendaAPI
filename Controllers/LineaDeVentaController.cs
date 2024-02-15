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
    public class LineaDeVentaController : ControllerBase
    {
        private readonly TiendaContext _context;

        public LineaDeVentaController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/LineaDeVenta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LineaDeVenta>>> GetLineaDeVenta()
        {
          if (_context.LineaDeVenta == null)
          {
              return NotFound();
          }
            return await _context.LineaDeVenta.ToListAsync();
        }

        // GET: api/LineaDeVenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LineaDeVenta>> GetLineaDeVenta(int id)
        {
          if (_context.LineaDeVenta == null)
          {
              return NotFound();
          }
            var lineaDeVenta = await _context.LineaDeVenta.FindAsync(id);

            if (lineaDeVenta == null)
            {
                return NotFound();
            }

            return lineaDeVenta;
        }

        // PUT: api/LineaDeVenta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLineaDeVenta(int id, LineaDeVenta lineaDeVenta)
        {
            if (id != lineaDeVenta.IdLineaDeVenta)
            {
                return BadRequest();
            }

            _context.Entry(lineaDeVenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineaDeVentaExists(id))
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

        // POST: api/LineaDeVenta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LineaDeVenta>> PostLineaDeVenta(LineaDeVenta lineaDeVenta)
        {
          if (_context.LineaDeVenta == null)
          {
              return Problem("Entity set 'TiendaContext.LineaDeVenta'  is null.");
          }
            _context.LineaDeVenta.Add(lineaDeVenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLineaDeVenta", new { id = lineaDeVenta.IdLineaDeVenta }, lineaDeVenta);
        }

        // DELETE: api/LineaDeVenta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLineaDeVenta(int id)
        {
            if (_context.LineaDeVenta == null)
            {
                return NotFound();
            }
            var lineaDeVenta = await _context.LineaDeVenta.FindAsync(id);
            if (lineaDeVenta == null)
            {
                return NotFound();
            }

            _context.LineaDeVenta.Remove(lineaDeVenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LineaDeVentaExists(int id)
        {
            return (_context.LineaDeVenta?.Any(e => e.IdLineaDeVenta == id)).GetValueOrDefault();
        }
    }
}
