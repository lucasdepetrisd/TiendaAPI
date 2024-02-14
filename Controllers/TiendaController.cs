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
    public class TiendaController : ControllerBase
    {
        private readonly TiendaContext _context;

        public TiendaController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/Tienda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tienda>>> GetTienda()
        {
          if (_context.Tienda == null)
          {
              return NotFound();
          }
            return await _context.Tienda.ToListAsync();
        }

        // GET: api/Tienda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tienda>> GetTienda(int id)
        {
          if (_context.Tienda == null)
          {
              return NotFound();
          }
            var tienda = await _context.Tienda.FindAsync(id);

            if (tienda == null)
            {
                return NotFound();
            }

            return tienda;
        }

        // PUT: api/Tienda/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTienda(int id, Tienda tienda)
        {
            if (id != tienda.IdTienda)
            {
                return BadRequest();
            }

            _context.Entry(tienda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiendaExists(id))
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

        // POST: api/Tienda
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tienda>> PostTienda(Tienda tienda)
        {
          if (_context.Tienda == null)
          {
              return Problem("Entity set 'TiendaContext.Tienda'  is null.");
          }
            _context.Tienda.Add(tienda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTienda", new { id = tienda.IdTienda }, tienda);
        }

        // DELETE: api/Tienda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTienda(int id)
        {
            if (_context.Tienda == null)
            {
                return NotFound();
            }
            var tienda = await _context.Tienda.FindAsync(id);
            if (tienda == null)
            {
                return NotFound();
            }

            _context.Tienda.Remove(tienda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiendaExists(int id)
        {
            return (_context.Tienda?.Any(e => e.IdTienda == id)).GetValueOrDefault();
        }
    }
}
