using System.ComponentModel.DataAnnotations;

namespace SAS.Models
{
    public class Year
    {
        [Key]
        public int Year_id { get; set; }
        [Required(ErrorMessage = "Year is required")]
        [Display(Name = "Year")]
        public string yearName { get; set; }

        public virtual ICollection<Student_course> Student_course { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Department_course> Department_course { get; set; }


    }
}
