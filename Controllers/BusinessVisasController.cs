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
    public class BusinessVisasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessVisasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BusinessVisas
        public async Task<IActionResult> Index()
        {
              return _context.BusinessVisaForm != null ? 
                          View(await _context.BusinessVisaForm.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BusinessVisaForm'  is null.");
        }

        // GET: BusinessVisas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BusinessVisaForm == null)
            {
                return NotFound();
            }

            var businessVisa = await _context.BusinessVisaForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessVisa == null)
            {
                return NotFound();
            }

            return View(businessVisa);
        }

        // GET: BusinessVisas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessVisas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] BusinessVisa businessVisa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessVisa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessVisa);
        }

        // GET: BusinessVisas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BusinessVisaForm == null)
            {
                return NotFound();
            }

            var businessVisa = await _context.BusinessVisaForm.FindAsync(id);
            if (businessVisa == null)
            {
                return NotFound();
            }
            return View(businessVisa);
        }

        // POST: BusinessVisas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] BusinessVisa businessVisa)
        {
            if (id != businessVisa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessVisa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessVisaExists(businessVisa.Id))
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
            return View(businessVisa);
        }

        // GET: BusinessVisas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BusinessVisaForm == null)
            {
                return NotFound();
            }

            var businessVisa = await _context.BusinessVisaForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessVisa == null)
            {
                return NotFound();
            }

            return View(businessVisa);
        }

        // POST: BusinessVisas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BusinessVisaForm == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BusinessVisaForm'  is null.");
            }
            var businessVisa = await _context.BusinessVisaForm.FindAsync(id);
            if (businessVisa != null)
            {
                _context.BusinessVisaForm.Remove(businessVisa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessVisaExists(int id)
        {
          return (_context.BusinessVisaForm?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
