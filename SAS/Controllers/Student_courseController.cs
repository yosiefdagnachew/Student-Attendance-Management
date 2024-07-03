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
    public class Student_courseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Student_courseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student_course
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Student_course.Include(s => s.Academic_Year).Include(s => s.Course).Include(s => s.Department).Include(s => s.Faculity).Include(s => s.Semester).Include(s => s.Student).Include(s => s.Year);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Student_course/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Student_course == null)
            {
                return NotFound();
            }

            var student_course = await _context.Student_course
                .Include(s => s.Academic_Year)
                .Include(s => s.Course)
                .Include(s => s.Department)
                .Include(s => s.Faculity)
                .Include(s => s.Semester)
                .Include(s => s.Student)
                .Include(s => s.Year)
                .FirstOrDefaultAsync(m => m.Stud_course_id == id);
            if (student_course == null)
            {
                return NotFound();
            }

            return View(student_course);
        }

        // GET: Student_course/Create
        public IActionResult Create()
        {
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName");
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name");
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name");
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name");
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName");
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName");
            ViewData["Year_id"] = new SelectList(_context.Year, "Year_id", "yearName");
            return View();
        }

        // POST: Student_course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Stud_course_id,Stud_id,Course_id,Academic_y_id,Department_id,Faculity_id,Semester_id,Year_id,Attendance_time")] Student_course student_course)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(student_course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", student_course.Academic_y_id);
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", student_course.Course_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", student_course.Department_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", student_course.Faculity_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", student_course.Semester_id);
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName", student_course.Stud_id);
            ViewData["Year_id"] = new SelectList(_context.Year, "Year_id", "yearName", student_course.Year_id);
            return View(student_course);
        }

        // GET: Student_course/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Student_course == null)
            {
                return NotFound();
            }

            var student_course = await _context.Student_course.FindAsync(id);
            if (student_course == null)
            {
                return NotFound();
            }
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", student_course.Academic_y_id);
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", student_course.Course_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", student_course.Department_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", student_course.Faculity_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", student_course.Semester_id);
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName", student_course.Stud_id);
            ViewData["Year_id"] = new SelectList(_context.Year, "Year_id", "yearName", student_course.Year_id);
            return View(student_course);
        }

        // POST: Student_course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Stud_course_id,Stud_id,Course_id,Academic_y_id,Department_id,Faculity_id,Semester_id,Year_id,Attendance_time")] Student_course student_course)
        {
            if (id != student_course.Stud_course_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student_course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Student_courseExists(student_course.Stud_course_id))
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
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", student_course.Academic_y_id);
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", student_course.Course_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", student_course.Department_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", student_course.Faculity_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", student_course.Semester_id);
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName", student_course.Stud_id);
            ViewData["Year_id"] = new SelectList(_context.Year, "Year_id", "yearName", student_course.Year_id);
            return View(student_course);
        }

        // GET: Student_course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Student_course == null)
            {
                return NotFound();
            }

            var student_course = await _context.Student_course
                .Include(s => s.Academic_Year)
                .Include(s => s.Course)
                .Include(s => s.Department)
                .Include(s => s.Faculity)
                .Include(s => s.Semester)
                .Include(s => s.Student)
                .Include(s => s.Year)
                .FirstOrDefaultAsync(m => m.Stud_course_id == id);
            if (student_course == null)
            {
                return NotFound();
            }

            return View(student_course);
        }

        // POST: Student_course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Student_course == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Student_course'  is null.");
            }
            var student_course = await _context.Student_course.FindAsync(id);
            if (student_course != null)
            {
                _context.Student_course.Remove(student_course);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Student_courseExists(int id)
        {
          return (_context.Student_course?.Any(e => e.Stud_course_id == id)).GetValueOrDefault();
        }
    }
}
