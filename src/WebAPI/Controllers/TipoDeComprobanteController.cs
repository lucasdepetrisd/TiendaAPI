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
    public class TipoDeComprobanteController : ControllerBase
    {
        private readonly ITiendaContext _context;

        public TipoDeComprobanteController(ITiendaContext context)
        {
            _context = context;
        }

        // GET: api/TipoDeComprobante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDeComprobante>>> GetTipoDeComprobante()
        {
          if (_context.TipoDeComprobante == null)
          {
              return NotFound();
          }
            return await _context.TipoDeComprobante.ToListAsync();
        }

        // GET: api/TipoDeComprobante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDeComprobante>> GetTipoDeComprobante(int id)
        {
          if (_context.TipoDeComprobante == null)
          {
              return NotFound();
          }
            var tipoDeComprobante = await _context.TipoDeComprobante.FindAsync(id);

            if (tipoDeComprobante == null)
            {
                return NotFound();
            }

            return tipoDeComprobante;
        }

        // PUT: api/TipoDeComprobante/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDeComprobante(int id, TipoDeComprobante tipoDeComprobante)
        {
            if (id != tipoDeComprobante.IdTipoDeComprobante)
            {
                return BadRequest();
            }

            _context.TipoDeComprobante.Entry(tipoDeComprobante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDeComprobanteExists(id))
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

        // POST: api/TipoDeComprobante
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoDeComprobante>> PostTipoDeComprobante(TipoDeComprobante tipoDeComprobante)
        {
          if (_context.TipoDeComprobante == null)
          {
              return Problem("Entity set 'ITiendaContext.TipoDeComprobante'  is null.");
          }
            _context.TipoDeComprobante.Add(tipoDeComprobante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDeComprobante", new { id = tipoDeComprobante.IdTipoDeComprobante }, tipoDeComprobante);
        }

        // DELETE: api/TipoDeComprobante/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDeComprobante(int id)
        {
            if (_context.TipoDeComprobante == null)
            {
                return NotFound();
            }
            var tipoDeComprobante = await _context.TipoDeComprobante.FindAsync(id);
            if (tipoDeComprobante == null)
            {
                return NotFound();
            }

            _context.TipoDeComprobante.Remove(tipoDeComprobante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoDeComprobanteExists(int id)
        {
            return (_context.TipoDeComprobante?.Any(e => e.IdTipoDeComprobante == id)).GetValueOrDefault();
        }
    }
}
