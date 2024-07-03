using System.ComponentModel.DataAnnotations;

namespace SAS.Models
{

    public class Course
    {
        [Key]
        public int Course_id { get; set; }
        [Required(ErrorMessage = "Course Name is required !")]
        [Display(Name = "Course Name")]
        public string Course_name { get; set; }
        [Required(ErrorMessage = "Course code is required !")]
        [Display(Name = "Course Code")]
        public string Course_code { get; set; }
        [Required(ErrorMessage = "Course credit is required !")]
        [Display(Name = "Course Credit")]
        public string Course_credit { get; set; }

        [Required(ErrorMessage = "Course descrption is required !")]
        [Display(Name = "Course Descrption")]
        public string Course_descrption { get; set; }

        public virtual ICollection<Student_course> Student_Course { get; set; }
        public virtual ICollection<Class_program> Class_program { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
        public virtual ICollection<Course_teacher> Course_teacher { get; set; }
        public virtual ICollection<Department_course> Department_course { get; set; }
    }
}
