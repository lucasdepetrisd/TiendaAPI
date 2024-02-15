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
    public class ComprobanteController : ControllerBase
    {
        private readonly TiendaContext _context;

        public ComprobanteController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/Comprobante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comprobante>>> GetComprobante()
        {
          if (_context.Comprobante == null)
          {
              return NotFound();
          }
            return await _context.Comprobante.ToListAsync();
        }

        // GET: api/Comprobante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comprobante>> GetComprobante(int id)
        {
          if (_context.Comprobante == null)
          {
              return NotFound();
          }
            var comprobante = await _context.Comprobante.FindAsync(id);

            if (comprobante == null)
            {
                return NotFound();
            }

            return comprobante;
        }

        // PUT: api/Comprobante/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComprobante(int id, Comprobante comprobante)
        {
            if (id != comprobante.IdComprobante)
            {
                return BadRequest();
            }

            _context.Entry(comprobante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprobanteExists(id))
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

        // POST: api/Comprobante
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comprobante>> PostComprobante(Comprobante comprobante)
        {
          if (_context.Comprobante == null)
          {
              return Problem("Entity set 'TiendaContext.Comprobante'  is null.");
          }
            _context.Comprobante.Add(comprobante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComprobante", new { id = comprobante.IdComprobante }, comprobante);
        }

        // DELETE: api/Comprobante/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComprobante(int id)
        {
            if (_context.Comprobante == null)
            {
                return NotFound();
            }
            var comprobante = await _context.Comprobante.FindAsync(id);
            if (comprobante == null)
            {
                return NotFound();
            }

            _context.Comprobante.Remove(comprobante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComprobanteExists(int id)
        {
            return (_context.Comprobante?.Any(e => e.IdComprobante == id)).GetValueOrDefault();
        }
    }
}
