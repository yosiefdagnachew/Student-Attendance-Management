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
    public class Course_teacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Course_teacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Course_teacher
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Course_teacher.Include(c => c.Academic_Year).Include(c => c.Course).Include(c => c.Department).Include(c => c.Faculity).Include(c => c.Semester).Include(c => c.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Course_teacher/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Course_teacher == null)
            {
                return NotFound();
            }

            var course_teacher = await _context.Course_teacher
                .Include(c => c.Academic_Year)
                .Include(c => c.Course)
                .Include(c => c.Department)
                .Include(c => c.Faculity)
                .Include(c => c.Semester)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Course_teacher_id == id);
            if (course_teacher == null)
            {
                return NotFound();
            }

            return View(course_teacher);
        }

        // GET: Course_teacher/Create
        public IActionResult Create()
        {
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName");
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name");
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name");
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name");
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName");
            ViewData["Teacher_id"] = new SelectList(_context.Teacher, "Teacher_id", "FullNameOfTeacher");
            return View();
        }

        // POST: Course_teacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Course_teacher_id,Teacher_id,Academic_y_id,Semester_id,Faculity_id,Department_id,Course_id,Status")] Course_teacher course_teacher)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(course_teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", course_teacher.Academic_y_id);
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", course_teacher.Course_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", course_teacher.Department_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", course_teacher.Faculity_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", course_teacher.Semester_id);
            ViewData["Teacher_id"] = new SelectList(_context.Teacher, "Teacher_id", "FullNameOfTeacher", course_teacher.Teacher_id);
            return View(course_teacher);
        }

        // GET: Course_teacher/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Course_teacher == null)
            {
                return NotFound();
            }

            var course_teacher = await _context.Course_teacher.FindAsync(id);
            if (course_teacher == null)
            {
                return NotFound();
            }
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", course_teacher.Academic_y_id);
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", course_teacher.Course_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", course_teacher.Department_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", course_teacher.Faculity_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", course_teacher.Semester_id);
            ViewData["Teacher_id"] = new SelectList(_context.Teacher, "Teacher_id", "FullNameOfTeacher", course_teacher.Teacher_id);
            return View(course_teacher);
        }

        // POST: Course_teacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Course_teacher_id,Teacher_id,Academic_y_id,Semester_id,Faculity_id,Department_id,Course_id,Status")] Course_teacher course_teacher)
        {
            if (id != course_teacher.Course_teacher_id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(course_teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Course_teacherExists(course_teacher.Course_teacher_id))
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
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", course_teacher.Academic_y_id);
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", course_teacher.Course_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", course_teacher.Department_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", course_teacher.Faculity_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", course_teacher.Semester_id);
            ViewData["Teacher_id"] = new SelectList(_context.Teacher, "Teacher_id", "FullNameOfTeacher", course_teacher.Teacher_id);
            return View(course_teacher);
        }

        // GET: Course_teacher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Course_teacher == null)
            {
                return NotFound();
            }

            var course_teacher = await _context.Course_teacher
                .Include(c => c.Academic_Year)
                .Include(c => c.Course)
                .Include(c => c.Department)
                .Include(c => c.Faculity)
                .Include(c => c.Semester)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Course_teacher_id == id);
            if (course_teacher == null)
            {
                return NotFound();
            }

            return View(course_teacher);
        }

        // POST: Course_teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Course_teacher == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Course_teacher'  is null.");
            }
            var course_teacher = await _context.Course_teacher.FindAsync(id);
            if (course_teacher != null)
            {
                _context.Course_teacher.Remove(course_teacher);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Course_teacherExists(int id)
        {
          return (_context.Course_teacher?.Any(e => e.Course_teacher_id == id)).GetValueOrDefault();
        }
    }
}
