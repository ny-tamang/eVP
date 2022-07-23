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
    public class PassportAppliesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PassportAppliesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PassportApplies
        public async Task<IActionResult> Index()
        {
              return _context.PassportApply != null ? 
                          View(await _context.PassportApply.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PassportApply'  is null.");
        }

        // GET: PassportApplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PassportApply == null)
            {
                return NotFound();
            }

            var passportApply = await _context.PassportApply
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passportApply == null)
            {
                return NotFound();
            }

            return View(passportApply);
        }

        // GET: PassportApplies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PassportApplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] PassportApply passportApply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passportApply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passportApply);
        }

        // GET: PassportApplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PassportApply == null)
            {
                return NotFound();
            }

            var passportApply = await _context.PassportApply.FindAsync(id);
            if (passportApply == null)
            {
                return NotFound();
            }
            return View(passportApply);
        }

        // POST: PassportApplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] PassportApply passportApply)
        {
            if (id != passportApply.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passportApply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassportApplyExists(passportApply.Id))
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
            return View(passportApply);
        }

        // GET: PassportApplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PassportApply == null)
            {
                return NotFound();
            }

            var passportApply = await _context.PassportApply
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passportApply == null)
            {
                return NotFound();
            }

            return View(passportApply);
        }

        // POST: PassportApplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PassportApply == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PassportApply'  is null.");
            }
            var passportApply = await _context.PassportApply.FindAsync(id);
            if (passportApply != null)
            {
                _context.PassportApply.Remove(passportApply);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassportApplyExists(int id)
        {
          return (_context.PassportApply?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
