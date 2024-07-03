using System.ComponentModel.DataAnnotations;

namespace SAS.Models
{
    public class Teacher
    {
        [Key]
        public int Teacher_id { get; set; }
        [Required(ErrorMessage = "Teacher first name is required !")]
        [Display(Name = "Teacher first name")]
        public string Teacher_fname { get; set; }
        [Required(ErrorMessage = "Teacher last name is required !")]
        [Display(Name = "Teacher last name")]
        public string Teacher_lname { get; set; }
        [Display(Name = "Full Name Of a Teacher")]
        public string FullNameOfTeacher
        {
            get
            {
                return Teacher_fname + "  " + Teacher_lname;
            }
        }
        [Required(ErrorMessage = "Phone number is required !")]
        [Display(Name = "Phone Number")]
        public string Phone_no { get; set; }
        [Required(ErrorMessage = "Email is required !")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public virtual ICollection<Class_program> Class_program { get; set; }
        public virtual ICollection<Course_teacher> Course_teacher { get; set; }

    }
}
