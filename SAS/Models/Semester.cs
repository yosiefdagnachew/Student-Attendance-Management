

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public class Semester
    {
        [Key]
        public int Semester_id { get; set; }


        [Required(ErrorMessage = "Semester is required !")]
        [Display(Name = "Semester")]
        public string SemesterName { get; set; }

        public virtual ICollection<Student_course> Student_cours { get; set; }
        public virtual ICollection<Student_classProgram> Student_classProgram { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<Course_teacher> Course_teacher { get; set; }
        public virtual ICollection<Department_course> Department_course { get; set; }



    }
}
