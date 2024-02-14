using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.Models;

namespace TiendaAPI.Controllers
{
    public class TalleController : Controller
    {
        private readonly TiendaContext _context;

        public TalleController(TiendaContext context)
        {
            _context = context;
        }

        // GET: Talle
        public async Task<IActionResult> Index()
        {
            var tiendaContext = _context.Talle.Include(t => t.TipoTalle);
            return View(await tiendaContext.ToListAsync());
        }

        // GET: Talle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Talle == null)
            {
                return NotFound();
            }

            var talle = await _context.Talle
                .Include(t => t.TipoTalle)
                .FirstOrDefaultAsync(m => m.IdTalle == id);
            if (talle == null)
            {
                return NotFound();
            }

            return View(talle);
        }

        // GET: Talle/Create
        public IActionResult Create()
        {
            ViewData["IdTipoTalle"] = new SelectList(_context.TipoTalle, "IdTipoTalle", "IdTipoTalle");
            return View();
        }

        // POST: Talle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTalle,Medida,IdTipoTalle")] Talle talle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(talle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoTalle"] = new SelectList(_context.TipoTalle, "IdTipoTalle", "IdTipoTalle", talle.IdTipoTalle);
            return View(talle);
        }

        // GET: Talle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Talle == null)
            {
                return NotFound();
            }

            var talle = await _context.Talle.FindAsync(id);
            if (talle == null)
            {
                return NotFound();
            }
            ViewData["IdTipoTalle"] = new SelectList(_context.TipoTalle, "IdTipoTalle", "IdTipoTalle", talle.IdTipoTalle);
            return View(talle);
        }

        // POST: Talle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTalle,Medida,IdTipoTalle")] Talle talle)
        {
            if (id != talle.IdTalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalleExists(talle.IdTalle))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoTalle"] = new SelectList(_context.TipoTalle, "IdTipoTalle", "IdTipoTalle", talle.IdTipoTalle);
            return View(talle);
        }

        // GET: Talle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Talle == null)
            {
                return NotFound();
            }

            var talle = await _context.Talle
                .Include(t => t.TipoTalle)
                .FirstOrDefaultAsync(m => m.IdTalle == id);
            if (talle == null)
            {
                return NotFound();
            }

            return View(talle);
        }

        // POST: Talle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Talle == null)
            {
                return Problem("Entity set 'TiendaContext.Talle'  is null.");
            }
            var talle = await _context.Talle.FindAsync(id);
            if (talle != null)
            {
                _context.Talle.Remove(talle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TalleExists(int id)
        {
          return (_context.Talle?.Any(e => e.IdTalle == id)).GetValueOrDefault();
        }
    }
}
