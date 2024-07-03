using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public class Course_teacher
    {
        [Key]
        public int Course_teacher_id { get; set; }

        [Required(ErrorMessage = "Teacher Name is required !")]
        [Display(Name = "Teacher Name")]
        public int Teacher_id { get; set; }
        [ForeignKey("Teacher_id")]
        public Teacher Teacher { get; set; }

        [Required(ErrorMessage = "Academic year is required !")]
        [Display(Name = "Academic Year")]
        public int Academic_y_id { get; set; }
        [ForeignKey("Academic_y_id")]
        public Academic_Year Academic_Year { get; set; }

        [Required(ErrorMessage = "Semester is required !")]
        [Display(Name = "Semester")]
        public int Semester_id { get; set; }
        [ForeignKey("Semester_id")]
        public Semester Semester { get; set; }

        [Required(ErrorMessage = "Faculity Name is required !")]
        [Display(Name = "Faculity Name")]
        public int Faculity_id { get; set; }
        [ForeignKey("Faculity_id")]
        public Faculity Faculity { get; set; }

        [Required(ErrorMessage = "Department Name is required !")]
        [Display(Name = "Department Name")]
        public int Department_id { get; set; }
        [ForeignKey("Department_id")]
        public Department Department { get; set; }

        [Required(ErrorMessage = "Course Name is required !")]
        [Display(Name = "Course Name")]
        public int Course_id { get; set; }
        [ForeignKey("Course_id")]
        public Course Course { get; set; }

        [Required(ErrorMessage = "Status is required !")]
        [Display(Name = "Status")]
        public String Status { get; set; }



    }
}
