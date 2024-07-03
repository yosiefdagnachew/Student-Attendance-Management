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
    public class Student_classProgramController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Student_classProgramController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student_classProgram
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Student_class.Include(s => s.Academic_Year).Include(s => s.Class_program).Include(s => s.Department).Include(s => s.Faculity).Include(s => s.Semester).Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Student_classProgram/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Student_class == null)
            {
                return NotFound();
            }

            var student_classProgram = await _context.Student_class
                .Include(s => s.Academic_Year)
                .Include(s => s.Class_program)
                .Include(s => s.Department)
                .Include(s => s.Faculity)
                .Include(s => s.Semester)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Student_Class_id == id);
            if (student_classProgram == null)
            {
                return NotFound();
            }

            return View(student_classProgram);
        }

        // GET: Student_classProgram/Create
        public IActionResult Create()
        {
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName");
            ViewData["ClassProgram_id"] = new SelectList(_context.Class_program, "ClassProgram_id", "ClassProgram_id");
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name");
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name");
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName");
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName");
            return View();
        }

        // POST: Student_classProgram/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Student_Class_id,Stud_id,Academic_y_id,ClassProgram_id,Department_id,Faculity_id,Semester_id,Status")] Student_classProgram student_classProgram)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(student_classProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", student_classProgram.Academic_y_id);
            ViewData["ClassProgram_id"] = new SelectList(_context.Class_program, "ClassProgram_id", "ClassProgram_id", student_classProgram.ClassProgram_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", student_classProgram.Department_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", student_classProgram.Faculity_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", student_classProgram.Semester_id);
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName", student_classProgram.Stud_id);
            return View(student_classProgram);
        }

        // GET: Student_classProgram/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Student_class == null)
            {
                return NotFound();
            }

            var student_classProgram = await _context.Student_class.FindAsync(id);
            if (student_classProgram == null)
            {
                return NotFound();
            }
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", student_classProgram.Academic_y_id);
            ViewData["ClassProgram_id"] = new SelectList(_context.Class_program, "ClassProgram_id", "ClassProgram_id", student_classProgram.ClassProgram_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", student_classProgram.Department_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", student_classProgram.Faculity_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", student_classProgram.Semester_id);
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName", student_classProgram.Stud_id);
            return View(student_classProgram);
        }

        // POST: Student_classProgram/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Student_Class_id,Stud_id,Academic_y_id,ClassProgram_id,Department_id,Faculity_id,Semester_id,Status")] Student_classProgram student_classProgram)
        {
            if (id != student_classProgram.Student_Class_id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(student_classProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Student_classProgramExists(student_classProgram.Student_Class_id))
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
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", student_classProgram.Academic_y_id);
            ViewData["ClassProgram_id"] = new SelectList(_context.Class_program, "ClassProgram_id", "ClassProgram_id", student_classProgram.ClassProgram_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", student_classProgram.Department_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", student_classProgram.Faculity_id);
            ViewData["Semester_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", student_classProgram.Semester_id);
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName", student_classProgram.Stud_id);
            return View(student_classProgram);
        }

        // GET: Student_classProgram/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Student_class == null)
            {
                return NotFound();
            }

            var student_classProgram = await _context.Student_class
                .Include(s => s.Academic_Year)
                .Include(s => s.Class_program)
                .Include(s => s.Department)
                .Include(s => s.Faculity)
                .Include(s => s.Semester)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Student_Class_id == id);
            if (student_classProgram == null)
            {
                return NotFound();
            }

            return View(student_classProgram);
        }

        // POST: Student_classProgram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Student_class == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Student_class'  is null.");
            }
            var student_classProgram = await _context.Student_class.FindAsync(id);
            if (student_classProgram != null)
            {
                _context.Student_class.Remove(student_classProgram);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Student_classProgramExists(int id)
        {
          return (_context.Student_class?.Any(e => e.Student_Class_id == id)).GetValueOrDefault();
        }
    }
}
