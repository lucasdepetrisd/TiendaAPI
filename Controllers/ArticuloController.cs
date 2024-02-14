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
    public class ArticuloController : ControllerBase
    {
        private readonly TiendaContext _context;

        public ArticuloController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/Articulo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulo()
        {
          if (_context.Articulo == null)
          {
              return NotFound();
          }
            return await _context.Articulo.ToListAsync();
        }

        // GET: api/Articulo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> GetArticulo(int id)
        {
          if (_context.Articulo == null)
          {
              return NotFound();
          }
            var articulo = await _context.Articulo.FindAsync(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        // PUT: api/Articulo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(int id, Articulo articulo)
        {
            if (id != articulo.IdArticulo)
            {
                return BadRequest();
            }

            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
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

        // POST: api/Articulo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Articulo>> PostArticulo(Articulo articulo)
        {
          if (_context.Articulo == null)
          {
              return Problem("Entity set 'TiendaContext.Articulo'  is null.");
          }
            _context.Articulo.Add(articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulo", new { id = articulo.IdArticulo }, articulo);
        }

        // DELETE: api/Articulo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            if (_context.Articulo == null)
            {
                return NotFound();
            }
            var articulo = await _context.Articulo.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            _context.Articulo.Remove(articulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticuloExists(int id)
        {
            return (_context.Articulo?.Any(e => e.IdArticulo == id)).GetValueOrDefault();
        }
    }
}
