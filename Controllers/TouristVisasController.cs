using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using evp.Data;
using evp.Models;

namespace evp.Controllers
{
    public class TouristVisasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TouristVisasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TouristVisas
        public async Task<IActionResult> Index()
        {
              return _context.TouristVisaForm != null ? 
                          View(await _context.TouristVisaForm.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TouristVisaForm'  is null.");
        }

        // GET: TouristVisas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TouristVisaForm == null)
            {
                return NotFound();
            }

            var touristVisa = await _context.TouristVisaForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (touristVisa == null)
            {
                return NotFound();
            }

            return View(touristVisa);
        }

        // GET: TouristVisas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TouristVisas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] TouristVisa touristVisa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(touristVisa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(touristVisa);
        }

        // GET: TouristVisas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TouristVisaForm == null)
            {
                return NotFound();
            }

            var touristVisa = await _context.TouristVisaForm.FindAsync(id);
            if (touristVisa == null)
            {
                return NotFound();
            }
            return View(touristVisa);
        }

        // POST: TouristVisas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] TouristVisa touristVisa)
        {
            if (id != touristVisa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(touristVisa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TouristVisaExists(touristVisa.Id))
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
            return View(touristVisa);
        }

        // GET: TouristVisas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TouristVisaForm == null)
            {
                return NotFound();
            }

            var touristVisa = await _context.TouristVisaForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (touristVisa == null)
            {
                return NotFound();
            }

            return View(touristVisa);
        }

        // POST: TouristVisas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TouristVisaForm == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TouristVisaForm'  is null.");
            }
            var touristVisa = await _context.TouristVisaForm.FindAsync(id);
            if (touristVisa != null)
            {
                _context.TouristVisaForm.Remove(touristVisa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TouristVisaExists(int id)
        {
          return (_context.TouristVisaForm?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
