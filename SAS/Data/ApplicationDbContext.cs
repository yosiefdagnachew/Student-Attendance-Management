using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAS.Models;

namespace SAS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Academic_Year> Academic_Year { get; set; } = default!;
        public DbSet<SAS.Models.Attendance> Attendance { get; set; } = default!;
        public DbSet<SAS.Models.Class> Class { get; set; } = default!;
        public DbSet<SAS.Models.Course> Course { get; set; } = default!;
        public DbSet<SAS.Models.Course_teacher> Course_teacher { get; set; } = default!;
        public DbSet<SAS.Models.Department> Department { get; set; } = default!;
        public DbSet<SAS.Models.Department_course> Department_course { get; set; } = default!;
        public DbSet<SAS.Models.Enrollment> Enrollment { get; set; } = default!;
        public DbSet<SAS.Models.Semester> Semester { get; set; } = default!;
        public DbSet<SAS.Models.Student> Student { get; set; } = default!;
        public DbSet<SAS.Models.Student_classProgram> Student_class { get; set; } = default!;
        public DbSet<SAS.Models.Student_course> Student_course { get; set; } = default!;
        public DbSet<SAS.Models.Year> Year { get; set; } = default!;
        public DbSet<SAS.Models.Teacher> Teacher { get; set; } = default!;

        public DbSet<SAS.Models.Faculity> Faculities { get; set; } = default!;

        public DbSet<SAS.Models.Class_program> Class_program { get; set; } = default!;
    }
}