using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAS.Data;
using SAS.Models;

namespace SAS.Controllers
{
    public class FaculitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FaculitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Faculities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Faculities.Include(f => f.Department);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Faculities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Faculities == null)
            {
                return NotFound();
            }

            var faculity = await _context.Faculities
                .Include(f => f.Department)
                .FirstOrDefaultAsync(m => m.Faculity_id == id);
            if (faculity == null)
            {
                return NotFound();
            }

            return View(faculity);
        }

        // GET: Faculities/Create
        public IActionResult Create()
        {
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name");
            return View();
        }

        // POST: Faculities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Faculity_id,Department_id,Faculty_name,Faculty_phone,Faculty_email")] Faculity faculity)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(faculity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", faculity.Department_id);
            return View(faculity);
        }

        // GET: Faculities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Faculities == null)
            {
                return NotFound();
            }

            var faculity = await _context.Faculities.FindAsync(id);
            if (faculity == null)
            {
                return NotFound();
            }
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", faculity.Department_id);
            return View(faculity);
        }

        // POST: Faculities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Faculity_id,Department_id,Faculty_name,Faculty_phone,Faculty_email")] Faculity faculity)
        {
            if (id != faculity.Faculity_id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(faculity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaculityExists(faculity.Faculity_id))
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
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", faculity.Department_id);
            return View(faculity);
        }

        // GET: Faculities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Faculities == null)
            {
                return NotFound();
            }

            var faculity = await _context.Faculities
                .Include(f => f.Department)
                .FirstOrDefaultAsync(m => m.Faculity_id == id);
            if (faculity == null)
            {
                return NotFound();
            }

            return View(faculity);
        }

        // POST: Faculities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Faculities == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Faculities'  is null.");
            }
            var faculity = await _context.Faculities.FindAsync(id);
            if (faculity != null)
            {
                _context.Faculities.Remove(faculity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaculityExists(int id)
        {
          return (_context.Faculities?.Any(e => e.Faculity_id == id)).GetValueOrDefault();
        }
    }
}
