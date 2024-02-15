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
    public class SucursalController : ControllerBase
    {
        private readonly TiendaContext _context;

        public SucursalController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/Sucursal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sucursal>>> GetSucursal()
        {
          if (_context.Sucursal == null)
          {
              return NotFound();
          }
            return await _context.Sucursal.ToListAsync();
        }

        // GET: api/Sucursal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursal>> GetSucursal(int id)
        {
          if (_context.Sucursal == null)
          {
              return NotFound();
          }
            var sucursal = await _context.Sucursal.FindAsync(id);

            if (sucursal == null)
            {
                return NotFound();
            }

            return sucursal;
        }

        // PUT: api/Sucursal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSucursal(int id, Sucursal sucursal)
        {
            if (id != sucursal.IdSucursal)
            {
                return BadRequest();
            }

            _context.Entry(sucursal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalExists(id))
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

        // POST: api/Sucursal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sucursal>> PostSucursal(Sucursal sucursal)
        {
          if (_context.Sucursal == null)
          {
              return Problem("Entity set 'TiendaContext.Sucursal'  is null.");
          }
            _context.Sucursal.Add(sucursal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSucursal", new { id = sucursal.IdSucursal }, sucursal);
        }

        // DELETE: api/Sucursal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursal(int id)
        {
            if (_context.Sucursal == null)
            {
                return NotFound();
            }
            var sucursal = await _context.Sucursal.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            _context.Sucursal.Remove(sucursal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SucursalExists(int id)
        {
            return (_context.Sucursal?.Any(e => e.IdSucursal == id)).GetValueOrDefault();
        }
    }
}
