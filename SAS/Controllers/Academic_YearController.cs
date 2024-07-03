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
    public class Academic_YearController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Academic_YearController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Academic_Year
        public async Task<IActionResult> Index()
        {
              return _context.Academic_Year != null ? 
                          View(await _context.Academic_Year.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Academic_Year'  is null.");
        }

        // GET: Academic_Year/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Academic_Year == null)
            {
                return NotFound();
            }

            var academic_Year = await _context.Academic_Year
                .FirstOrDefaultAsync(m => m.Academic_y_id == id);
            if (academic_Year == null)
            {
                return NotFound();
            }

            return View(academic_Year);
        }

        // GET: Academic_Year/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Academic_Year/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Academic_y_id,Academic_yearName")] Academic_Year academic_Year)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(academic_Year);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academic_Year);
        }

        // GET: Academic_Year/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Academic_Year == null)
            {
                return NotFound();
            }

            var academic_Year = await _context.Academic_Year.FindAsync(id);
            if (academic_Year == null)
            {
                return NotFound();
            }
            return View(academic_Year);
        }

        // POST: Academic_Year/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Academic_y_id,Academic_yearName")] Academic_Year academic_Year)
        {
            if (id != academic_Year.Academic_y_id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(academic_Year);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Academic_YearExists(academic_Year.Academic_y_id))
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
            return View(academic_Year);
        }

        // GET: Academic_Year/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Academic_Year == null)
            {
                return NotFound();
            }

            var academic_Year = await _context.Academic_Year
                .FirstOrDefaultAsync(m => m.Academic_y_id == id);
            if (academic_Year == null)
            {
                return NotFound();
            }

            return View(academic_Year);
        }

        // POST: Academic_Year/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Academic_Year == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Academic_Year'  is null.");
            }
            var academic_Year = await _context.Academic_Year.FindAsync(id);
            if (academic_Year != null)
            {
                _context.Academic_Year.Remove(academic_Year);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Academic_YearExists(int id)
        {
          return (_context.Academic_Year?.Any(e => e.Academic_y_id == id)).GetValueOrDefault();
        }
    }
}
