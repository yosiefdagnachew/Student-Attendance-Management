using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public class Department_course
    {
        [Key]

        public int Dept_course_id { get; set; }

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

        [Required(ErrorMessage = " Year is required !")]
        [Display(Name = "Year")]
        public int Year_id { get; set; }
        [ForeignKey("Year_id")]

        public Year Year { get; set; }

        [Required(ErrorMessage = "Semester is required !")]
        [Display(Name = "Semester")]
        public int Semester_id { get; set; }
        [ForeignKey("Semester_id")]

        public Semester Semester { get; set; }

        [Required(ErrorMessage = "Status is required !")]
        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}
