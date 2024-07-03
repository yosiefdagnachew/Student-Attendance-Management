using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public class Faculity
    {
        [Key]
        public int Faculity_id { get; set; }

        [Required(ErrorMessage = "Department Name is required !")]
        [Display(Name = "Department Name")]
        public int Department_id { get; set; }
        [ForeignKey("Department_id")]
        public Department Department { get; set; }

        [Required(ErrorMessage = "Faculty name  is required !")]
        [Display(Name = "Faculty Name")]
        public string Faculty_name { get; set; }
        [Required(ErrorMessage = "Faculty phone  is required !")]
        [Display(Name = "Faculty Phone")]
        public string Faculty_phone { get; set; }
        [Required(ErrorMessage = "Faculty_email is required !")]
        [Display(Name = "Faculty Email")]
        public string Faculty_email { get; set; }
        public virtual ICollection<Student_course> Student_course { get; set; }
        public virtual ICollection<Student_classProgram> Student_classProgram { get; set; }
        public virtual ICollection<Class_program> Class_program { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<Course_teacher> Course_teacher { get; set; }

    }
}
