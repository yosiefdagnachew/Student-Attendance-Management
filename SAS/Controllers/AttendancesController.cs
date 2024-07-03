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
    public class AttendancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Attendances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Attendance.Include(a => a.Academic_Year).Include(a => a.Department).Include(a => a.Enrollment).Include(a => a.Faculity).Include(a => a.Semester).Include(a => a.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Attendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attendance == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance
                .Include(a => a.Academic_Year)
                .Include(a => a.Department)
                .Include(a => a.Enrollment)
                .Include(a => a.Faculity)
                .Include(a => a.Semester)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.Attendance_id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendances/Create
        public IActionResult Create()
        {
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName");
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name");
            ViewData["Enrollment_id"] = new SelectList(_context.Enrollment, "Enrollement_id", "Status");
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name");
            ViewData["Semister_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName");
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Attendance_id,Stud_id,Academic_y_id,Department_id,Enrollment_id,Faculity_id,Semister_id,Attendance_date,Attendance_time,Status,Remark")] Attendance attendance)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", attendance.Academic_y_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", attendance.Department_id);
            ViewData["Enrollment_id"] = new SelectList(_context.Enrollment, "Enrollement_id", "Status", attendance.Enrollment_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", attendance.Faculity_id);
            ViewData["Semister_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", attendance.Semister_id);
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName", attendance.Stud_id);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attendance == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", attendance.Academic_y_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", attendance.Department_id);
            ViewData["Enrollment_id"] = new SelectList(_context.Enrollment, "Enrollement_id", "Status", attendance.Enrollment_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", attendance.Faculity_id);
            ViewData["Semister_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", attendance.Semister_id);
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName", attendance.Stud_id);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Attendance_id,Stud_id,Academic_y_id,Department_id,Enrollment_id,Faculity_id,Semister_id,Attendance_date,Attendance_time,Status,Remark")] Attendance attendance)
        {
            if (id != attendance.Attendance_id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.Attendance_id))
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
            ViewData["Academic_y_id"] = new SelectList(_context.Academic_Year, "Academic_y_id", "Academic_yearName", attendance.Academic_y_id);
            ViewData["Department_id"] = new SelectList(_context.Department, "Department_id", "Department_name", attendance.Department_id);
            ViewData["Enrollment_id"] = new SelectList(_context.Enrollment, "Enrollement_id", "Status", attendance.Enrollment_id);
            ViewData["Faculity_id"] = new SelectList(_context.Faculities, "Faculity_id", "Faculty_name", attendance.Faculity_id);
            ViewData["Semister_id"] = new SelectList(_context.Semester, "Semester_id", "SemesterName", attendance.Semister_id);
            ViewData["Stud_id"] = new SelectList(_context.Student, "Stud_id", "FullName", attendance.Stud_id);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attendance == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance
                .Include(a => a.Academic_Year)
                .Include(a => a.Department)
                .Include(a => a.Enrollment)
                .Include(a => a.Faculity)
                .Include(a => a.Semester)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.Attendance_id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attendance == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Attendance'  is null.");
            }
            var attendance = await _context.Attendance.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendance.Remove(attendance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id)
        {
          return (_context.Attendance?.Any(e => e.Attendance_id == id)).GetValueOrDefault();
        }
    }
}
