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
    public class StudentVisasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentVisasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentVisas
        public async Task<IActionResult> Index()
        {
              return _context.StudentVisaForm != null ? 
                          View(await _context.StudentVisaForm.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StudentVisaForm'  is null.");
        }

        // GET: StudentVisas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentVisaForm == null)
            {
                return NotFound();
            }

            var studentVisa = await _context.StudentVisaForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentVisa == null)
            {
                return NotFound();
            }

            return View(studentVisa);
        }

        // GET: StudentVisas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentVisas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] StudentVisa studentVisa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentVisa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentVisa);
        }

        // GET: StudentVisas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentVisaForm == null)
            {
                return NotFound();
            }

            var studentVisa = await _context.StudentVisaForm.FindAsync(id);
            if (studentVisa == null)
            {
                return NotFound();
            }
            return View(studentVisa);
        }

        // POST: StudentVisas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] StudentVisa studentVisa)
        {
            if (id != studentVisa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentVisa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentVisaExists(studentVisa.Id))
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
            return View(studentVisa);
        }

        // GET: StudentVisas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentVisaForm == null)
            {
                return NotFound();
            }

            var studentVisa = await _context.StudentVisaForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentVisa == null)
            {
                return NotFound();
            }

            return View(studentVisa);
        }

        // POST: StudentVisas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentVisaForm == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentVisaForm'  is null.");
            }
            var studentVisa = await _context.StudentVisaForm.FindAsync(id);
            if (studentVisa != null)
            {
                _context.StudentVisaForm.Remove(studentVisa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentVisaExists(int id)
        {
          return (_context.StudentVisaForm?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
