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
    public class InventarioController : ControllerBase
    {
        private readonly ITiendaContext _context;

        public InventarioController(ITiendaContext context)
        {
            _context = context;
        }

        // GET: api/Inventario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventario>>> GetInventario()
        {
          if (_context.Inventario == null)
          {
              return NotFound();
          }
            return await _context.Inventario.ToListAsync();
        }

        // GET: api/Inventario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventario>> GetInventario(int id)
        {
          if (_context.Inventario == null)
          {
              return NotFound();
          }
            var inventario = await _context.Inventario.FindAsync(id);

            if (inventario == null)
            {
                return NotFound();
            }

            return inventario;
        }

        // PUT: api/Inventario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventario(int id, Inventario inventario)
        {
            if (id != inventario.IdInventario)
            {
                return BadRequest();
            }

            _context.Inventario.Entry(inventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioExists(id))
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

        // POST: api/Inventario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventario>> PostInventario(Inventario inventario)
        {
          if (_context.Inventario == null)
          {
              return Problem("Entity set 'ITiendaContext.Inventario'  is null.");
          }
            _context.Inventario.Add(inventario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventario", new { id = inventario.IdInventario }, inventario);
        }

        // DELETE: api/Inventario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventario(int id)
        {
            if (_context.Inventario == null)
            {
                return NotFound();
            }
            var inventario = await _context.Inventario.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            _context.Inventario.Remove(inventario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventarioExists(int id)
        {
            return (_context.Inventario?.Any(e => e.IdInventario == id)).GetValueOrDefault();
        }
    }
}
