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
    public class EmpleadoController : ControllerBase
    {
        private readonly ITiendaContext _context;

        public EmpleadoController(ITiendaContext context)
        {
            _context = context;
        }

        // GET: api/Empleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleado()
        {
          if (_context.Empleado == null)
          {
              return NotFound();
          }
            return await _context.Empleado.ToListAsync();
        }

        // GET: api/Empleado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
          if (_context.Empleado == null)
          {
              return NotFound();
          }
            var empleado = await _context.Empleado.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        // PUT: api/Empleado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return BadRequest();
            }

            _context.Empleado.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        // POST: api/Empleado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
          if (_context.Empleado == null)
          {
              return Problem("Entity set 'ITiendaContext.Empleado'  is null.");
          }
            _context.Empleado.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = empleado.IdEmpleado }, empleado);
        }

        // DELETE: api/Empleado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            if (_context.Empleado == null)
            {
                return NotFound();
            }
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(int id)
        {
            return (_context.Empleado?.Any(e => e.IdEmpleado == id)).GetValueOrDefault();
        }
    }
}
