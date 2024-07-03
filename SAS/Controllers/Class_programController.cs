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
    public class Class_programController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Class_programController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Class_program
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Class_program.Include(c => c.Class).Include(c => c.Course).Include(c => c.Faculity).Include(c => c.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Class_program/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Class_program == null)
            {
                return NotFound();
            }

            var class_program = await _context.Class_program
                .Include(c => c.Class)
                .Include(c => c.Course)
                .Include(c => c.Faculity)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassProgram_id == id);
            if (class_program == null)
            {
                return NotFound();
            }

            return View(class_program);
        }

        // GET: Class_program/Create
        public IActionResult Create()
        {
            ViewData["Class_id"] = new SelectList(_context.Class, "Class_id", "Class_name");
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name");
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name");
            ViewData["Teacher_id"] = new SelectList(_context.Teacher, "Teacher_id", "FullNameOfTeacher");
            return View();
        }

        // POST: Class_program/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassProgram_id,Class_id,Course_id,Faculity_id,Teacher_id,Period,Time")] Class_program class_program)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(class_program);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Class_id"] = new SelectList(_context.Class, "Class_id", "Class_name", class_program.Class_id);
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", class_program.Course_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_namae", class_program.Faculity_id);
            ViewData["Teacher_id"] = new SelectList(_context.Teacher, "Teacher_id", "FullNameOfTeacher", class_program.Teacher_id);
            return View(class_program);
        }

        // GET: Class_program/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Class_program == null)
            {
                return NotFound();
            }

            var class_program = await _context.Class_program.FindAsync(id);
            if (class_program == null)
            {
                return NotFound();
            }
            ViewData["Class_id"] = new SelectList(_context.Class, "Class_id", "Class_name", class_program.Class_id);
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", class_program.Course_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", class_program.Faculity_id);
            ViewData["Teacher_id"] = new SelectList(_context.Teacher, "Teacher_id", "FullNameOfTeacher", class_program.Teacher_id);
            return View(class_program);
        }

        // POST: Class_program/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassProgram_id,Class_id,Course_id,Faculity_id,Teacher_id,Period,Time")] Class_program class_program)
        {
            if (id != class_program.ClassProgram_id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(class_program);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Class_programExists(class_program.ClassProgram_id))
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
            ViewData["Class_id"] = new SelectList(_context.Class, "Class_id", "Class_name", class_program.Class_id);
            ViewData["Course_id"] = new SelectList(_context.Course, "Course_id", "Course_name", class_program.Course_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", class_program.Faculity_id);
            ViewData["Teacher_id"] = new SelectList(_context.Teacher, "Teacher_id", "FullNameOfTeacher", class_program.Teacher_id);
            return View(class_program);
        }

        // GET: Class_program/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Class_program == null)
            {
                return NotFound();
            }

            var class_program = await _context.Class_program
                .Include(c => c.Class)
                .Include(c => c.Course)
                .Include(c => c.Faculity)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.ClassProgram_id == id);
            if (class_program == null)
            {
                return NotFound();
            }

            return View(class_program);
        }

        // POST: Class_program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Class_program == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Class_program'  is null.");
            }
            var class_program = await _context.Class_program.FindAsync(id);
            if (class_program != null)
            {
                _context.Class_program.Remove(class_program);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Class_programExists(int id)
        {
          return (_context.Class_program?.Any(e => e.ClassProgram_id == id)).GetValueOrDefault();
        }
    }
}
