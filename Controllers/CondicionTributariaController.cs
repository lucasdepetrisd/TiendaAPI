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
    public class CondicionTributariaController : ControllerBase
    {
        private readonly TiendaContext _context;

        public CondicionTributariaController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/CondicionTributaria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CondicionTributaria>>> GetCondicionTributaria()
        {
          if (_context.CondicionTributaria == null)
          {
              return NotFound();
          }
            return await _context.CondicionTributaria.ToListAsync();
        }

        // GET: api/CondicionTributaria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CondicionTributaria>> GetCondicionTributaria(int id)
        {
          if (_context.CondicionTributaria == null)
          {
              return NotFound();
          }
            var condicionTributaria = await _context.CondicionTributaria.FindAsync(id);

            if (condicionTributaria == null)
            {
                return NotFound();
            }

            return condicionTributaria;
        }

        // PUT: api/CondicionTributaria/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondicionTributaria(int id, CondicionTributaria condicionTributaria)
        {
            if (id != condicionTributaria.IdCondicionTributaria)
            {
                return BadRequest();
            }

            _context.Entry(condicionTributaria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondicionTributariaExists(id))
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

        // POST: api/CondicionTributaria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CondicionTributaria>> PostCondicionTributaria(CondicionTributaria condicionTributaria)
        {
          if (_context.CondicionTributaria == null)
          {
              return Problem("Entity set 'TiendaContext.CondicionTributaria'  is null.");
          }
            _context.CondicionTributaria.Add(condicionTributaria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCondicionTributaria", new { id = condicionTributaria.IdCondicionTributaria }, condicionTributaria);
        }

        // DELETE: api/CondicionTributaria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondicionTributaria(int id)
        {
            if (_context.CondicionTributaria == null)
            {
                return NotFound();
            }
            var condicionTributaria = await _context.CondicionTributaria.FindAsync(id);
            if (condicionTributaria == null)
            {
                return NotFound();
            }

            _context.CondicionTributaria.Remove(condicionTributaria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CondicionTributariaExists(int id)
        {
            return (_context.CondicionTributaria?.Any(e => e.IdCondicionTributaria == id)).GetValueOrDefault();
        }
    }
}
