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
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Student.Include(s => s.Academic_year).Include(s => s.Year);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Academic_year)
                .Include(s => s.Year)
                .FirstOrDefaultAsync(m => m.Stud_id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName");
            ViewData["Year_id"] = new SelectList(_context.Year, "Year_id", "yearName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Stud_id,Academic_y_id,Year_id,Stud_fname,Stud_lname,Gender,Dob,Phone_no,Email")] Student student)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", student.Academic_y_id);
            ViewData["Year_id"] = new SelectList(_context.Year, "Year_id", "yearName", student.Year_id);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", student.Academic_y_id);
            ViewData["Year_id"] = new SelectList(_context.Year, "Year_id", "yearName", student.Year_id);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Stud_id,Academic_y_id,Year_id,Stud_fname,Stud_lname,Gender,Dob,Phone_no,Email")] Student student)
        {
            if (id != student.Stud_id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Stud_id))
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
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", student.Academic_y_id);
            ViewData["Year_id"] = new SelectList(_context.Year, "Year_id", "yearName", student.Year_id);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Academic_year)
                .Include(s => s.Year)
                .FirstOrDefaultAsync(m => m.Stud_id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Student == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Student'  is null.");
            }
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.Student?.Any(e => e.Stud_id == id)).GetValueOrDefault();
        }
    }
}
