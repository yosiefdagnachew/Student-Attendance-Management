using System.ComponentModel.DataAnnotations;

namespace SAS.Models
{
    public class Academic_Year
    {
        [Key]
        public int Academic_y_id { get; set; }
        [Required(ErrorMessage = "Academic year is required !")]
        [Display(Name = "Academic Year")]
        public string Academic_yearName { get; set; }

        // public virtual ICollection<Semester> Semster { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<Course_teacher> Course_teacher { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Student_classProgram> Student_classProgram { get; set; }
        public virtual ICollection<Student_course> Student_Course { get; set; }
    }
}


