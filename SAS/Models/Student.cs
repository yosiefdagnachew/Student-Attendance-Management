using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Student
    {
        [Key]
        public int Stud_id { get; set; }

        [Required(ErrorMessage = "Academic year is required !")]
        [Display(Name = "Academic year")]
        public int Academic_y_id { get; set; }
        [ForeignKey("Academic_y_id")]
        public Academic_Year Academic_year { get; set; }

        [Required(ErrorMessage = " Year is required !")]
        [Display(Name = "Year")]
        public int Year_id { get; set; }
        [ForeignKey("Year_id")]
        public Year Year { get; set; }

        [Required(ErrorMessage = "Student Name is required !")]
        [Display(Name = "Student Name")]
        public string Stud_fname { get; set; }

        [Required(ErrorMessage = "Father Name is required !")]
        [Display(Name = "Father Name")]
        public string Stud_lname { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return Stud_fname + "  " + Stud_lname;
            }
        }
        [Required(ErrorMessage = "Gender is required !")]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Date of birth is required !")]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Phone_no is required !")]
        [Display(Name = "Phone Number ")]
        public string Phone_no { get; set; }
        [Required(ErrorMessage = "Email is required !")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }



        public virtual ICollection<Student_course> Student_course { get; set; }
        public virtual ICollection<Student_classProgram> Student_classProgram { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
        public virtual ICollection<Attendance> Attendance { get; set; }




    }
}
