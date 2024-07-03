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
    public class EnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enrollment.Include(e => e.Academic_Year).Include(e => e.Course).Include(e => e.Department).Include(e => e.Faculity).Include(e => e.Semester).Include(e => e.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enrollment == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Academic_Year)
                .Include(e => e.Course)
                .Include(e => e.Department)
                .Include(e => e.Faculity)
                .Include(e => e.Semester)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Enrollement_id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName");
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name");
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name");
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name");
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName");
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Enrollement_id,Stud_id,Academic_y_id,Course_id,Faculity_id,Semester_id,Department_id,Enrollment_date,Status")] Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", enrollment.Academic_y_id);
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", enrollment.Course_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", enrollment.Department_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", enrollment.Faculity_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", enrollment.Semester_id);
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName", enrollment.Stud_id);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enrollment == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", enrollment.Academic_y_id);
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", enrollment.Course_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", enrollment.Department_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", enrollment.Faculity_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", enrollment.Semester_id);
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName", enrollment.Stud_id);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Enrollement_id,Stud_id,Academic_y_id,Course_id,Faculity_id,Semester_id,Department_id,Enrollment_date,Status")] Enrollment enrollment)
        {
            if (id != enrollment.Enrollement_id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.Enrollement_id))
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
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", enrollment.Academic_y_id);
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", enrollment.Course_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", enrollment.Department_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", enrollment.Faculity_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", enrollment.Semester_id);
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName", enrollment.Stud_id);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enrollment == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Academic_Year)
                .Include(e => e.Course)
                .Include(e => e.Department)
                .Include(e => e.Faculity)
                .Include(e => e.Semester)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Enrollement_id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enrollment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Enrollment'  is null.");
            }
            var enrollment = await _context.Enrollment.FindAsync(id);
            if (enrollment != null)
            {
                _context.Enrollment.Remove(enrollment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
          return (_context.Enrollment?.Any(e => e.Enrollement_id == id)).GetValueOrDefault();
        }
    }
}
