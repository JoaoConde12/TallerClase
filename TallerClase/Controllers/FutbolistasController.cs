using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerClase.Data;
using TallerClase.Models;

namespace TallerClase.Controllers
{
    public class FutbolistasController : Controller
    {
        private readonly TallerClaseContext _context;

        public FutbolistasController(TallerClaseContext context)
        {
            _context = context;
        }

        // GET: Futbolistas
        public async Task<IActionResult> Index()
        {
            var tallerClaseContext = _context.Futbolista.Include(f => f.Equipo);
            return View(await tallerClaseContext.ToListAsync());
        }

        // GET: Futbolistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futbolista = await _context.Futbolista
                .Include(f => f.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (futbolista == null)
            {
                return NotFound();
            }

            return View(futbolista);
        }

        // GET: Futbolistas/Create
        public IActionResult Create()
        {
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre");
            return View();
        }

        // POST: Futbolistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Posicion,Edad,IdEquipo")] Futbolista futbolista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(futbolista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre", futbolista.IdEquipo);
            return View(futbolista);
        }

        // GET: Futbolistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futbolista = await _context.Futbolista.FindAsync(id);
            if (futbolista == null)
            {
                return NotFound();
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre", futbolista.IdEquipo);
            return View(futbolista);
        }

        // POST: Futbolistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Posicion,Edad,IdEquipo")] Futbolista futbolista)
        {
            if (id != futbolista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(futbolista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FutbolistaExists(futbolista.Id))
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
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre", futbolista.IdEquipo);
            return View(futbolista);
        }

        // GET: Futbolistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futbolista = await _context.Futbolista
                .Include(f => f.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (futbolista == null)
            {
                return NotFound();
            }

            return View(futbolista);
        }

        // POST: Futbolistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var futbolista = await _context.Futbolista.FindAsync(id);
            if (futbolista != null)
            {
                _context.Futbolista.Remove(futbolista);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FutbolistaExists(int id)
        {
            return _context.Futbolista.Any(e => e.Id == id);
        }
    }
}
