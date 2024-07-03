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
    public class YearsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YearsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Years
        public async Task<IActionResult> Index()
        {
              return _context.Year != null ? 
                          View(await _context.Year.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Year'  is null.");
        }

        // GET: Years/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Year == null)
            {
                return NotFound();
            }

            var year = await _context.Year
                .FirstOrDefaultAsync(m => m.Year_id == id);
            if (year == null)
            {
                return NotFound();
            }

            return View(year);
        }

        // GET: Years/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Years/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Year_id,yearName")] Year year)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(year);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(year);
        }

        // GET: Years/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Year == null)
            {
                return NotFound();
            }

            var year = await _context.Year.FindAsync(id);
            if (year == null)
            {
                return NotFound();
            }
            return View(year);
        }

        // POST: Years/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Year_id,yearName")] Year year)
        {
            if (id != year.Year_id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(year);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YearExists(year.Year_id))
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
            return View(year);
        }

        // GET: Years/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Year == null)
            {
                return NotFound();
            }

            var year = await _context.Year
                .FirstOrDefaultAsync(m => m.Year_id == id);
            if (year == null)
            {
                return NotFound();
            }

            return View(year);
        }

        // POST: Years/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Year == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Year'  is null.");
            }
            var year = await _context.Year.FindAsync(id);
            if (year != null)
            {
                _context.Year.Remove(year);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YearExists(int id)
        {
          return (_context.Year?.Any(e => e.Year_id == id)).GetValueOrDefault();
        }
    }
}
