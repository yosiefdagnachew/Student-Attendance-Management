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
    public class Department_courseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Department_courseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Department_course
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Department_course.Include(d => d.Course).Include(d => d.Department).Include(d => d.Semester).Include(d => d.Year);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Department_course/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Department_course == null)
            {
                return NotFound();
            }

            var department_course = await _context.Department_course
                .Include(d => d.Course)
                .Include(d => d.Department)
                .Include(d => d.Semester)
                .Include(d => d.Year)
                .FirstOrDefaultAsync(m => m.Dept_course_id == id);
            if (department_course == null)
            {
                return NotFound();
            }

            return View(department_course);
        }

        // GET: Department_course/Create
        public IActionResult Create()
        {
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name");
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name");
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName");
            ViewData["Year_id"] = new SelectList(_context.Year, "Year_id", "yearName");
            return View();
        }

        // POST: Department_course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dept_course_id,Department_id,Course_id,Year_id,Semester_id,Status")] Department_course department_course)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(department_course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", department_course.Course_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", department_course.Department_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", department_course.Semester_id);
            ViewData["Year_id"] = new SelectList(_context.Year, "Year_id", "yearName", department_course.Year_id);
            return View(department_course);
        }

        // GET: Department_course/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Department_course == null)
            {
                return NotFound();
            }

            var department_course = await _context.Department_course.FindAsync(id);
            if (department_course == null)
            {
                return NotFound();
            }
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", department_course.Course_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", department_course.Department_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", department_course.Semester_id);
            ViewData["Year_id"] = new SelectList(_context.Year, "Year_id", "yearName", department_course.Year_id);
            return View(department_course);
        }

        // POST: Department_course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Dept_course_id,Department_id,Course_id,Year_id,Semester_id,Status")] Department_course department_course)
        {
            if (id != department_course.Dept_course_id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(department_course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Department_courseExists(department_course.Dept_course_id))
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
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", department_course.Course_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", department_course.Department_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", department_course.Semester_id);
            ViewData["Year_id"] = new SelectList(_context.Year, "Year_id", "yearName", department_course.Year_id);
            return View(department_course);
        }

        // GET: Department_course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Department_course == null)
            {
                return NotFound();
            }

            var department_course = await _context.Department_course
                .Include(d => d.Course)
                .Include(d => d.Department)
                .Include(d => d.Semester)
                .Include(d => d.Year)
                .FirstOrDefaultAsync(m => m.Dept_course_id == id);
            if (department_course == null)
            {
                return NotFound();
            }

            return View(department_course);
        }

        // POST: Department_course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Department_course == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Department_course'  is null.");
            }
            var department_course = await _context.Department_course.FindAsync(id);
            if (department_course != null)
            {
                _context.Department_course.Remove(department_course);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Department_courseExists(int id)
        {
          return (_context.Department_course?.Any(e => e.Dept_course_id == id)).GetValueOrDefault();
        }
    }
}
