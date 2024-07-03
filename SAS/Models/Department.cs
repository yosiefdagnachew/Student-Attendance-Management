using System.ComponentModel.DataAnnotations;

namespace SAS.Models
{
    public class Department
    {
        [Key]
        public int Department_id { get; set; }
        [Required(ErrorMessage = "Department name is required !")]
        [Display(Name = "Department Name")]
        public string Department_name { get; set; }
        [Required(ErrorMessage = "Department code is required !")]
        [Display(Name = "Department Code")]
        public string Department_code { get; set; }
        public virtual ICollection<Student_course> Student_courses { get; set; }
        public virtual ICollection<Student_classProgram> Student_classProgram { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
        public virtual ICollection<Faculity> Faculity { get; set; }
        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<Course_teacher> Course_teacher { get; set; }
        public virtual ICollection<Department_course> Department_course { get; set; }
    }
}
