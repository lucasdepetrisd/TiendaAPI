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
    public class PuntoDeVentaController : ControllerBase
    {
        private readonly TiendaContext _context;

        public PuntoDeVentaController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/PuntoDeVenta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuntoDeVenta>>> GetPuntoDeVenta()
        {
          if (_context.PuntoDeVenta == null)
          {
              return NotFound();
          }
            return await _context.PuntoDeVenta.ToListAsync();
        }

        // GET: api/PuntoDeVenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PuntoDeVenta>> GetPuntoDeVenta(int id)
        {
          if (_context.PuntoDeVenta == null)
          {
              return NotFound();
          }
            var puntoDeVenta = await _context.PuntoDeVenta.FindAsync(id);

            if (puntoDeVenta == null)
            {
                return NotFound();
            }

            return puntoDeVenta;
        }

        // PUT: api/PuntoDeVenta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuntoDeVenta(int id, PuntoDeVenta puntoDeVenta)
        {
            if (id != puntoDeVenta.IdPuntoDeVenta)
            {
                return BadRequest();
            }

            _context.Entry(puntoDeVenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuntoDeVentaExists(id))
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

        // POST: api/PuntoDeVenta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PuntoDeVenta>> PostPuntoDeVenta(PuntoDeVenta puntoDeVenta)
        {
          if (_context.PuntoDeVenta == null)
          {
              return Problem("Entity set 'TiendaContext.PuntoDeVenta'  is null.");
          }
            _context.PuntoDeVenta.Add(puntoDeVenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPuntoDeVenta", new { id = puntoDeVenta.IdPuntoDeVenta }, puntoDeVenta);
        }

        // DELETE: api/PuntoDeVenta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuntoDeVenta(int id)
        {
            if (_context.PuntoDeVenta == null)
            {
                return NotFound();
            }
            var puntoDeVenta = await _context.PuntoDeVenta.FindAsync(id);
            if (puntoDeVenta == null)
            {
                return NotFound();
            }

            _context.PuntoDeVenta.Remove(puntoDeVenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PuntoDeVentaExists(int id)
        {
            return (_context.PuntoDeVenta?.Any(e => e.IdPuntoDeVenta == id)).GetValueOrDefault();
        }
    }
}
