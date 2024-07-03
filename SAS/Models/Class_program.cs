using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public class Class_program
    {
        [Key]
        public int ClassProgram_id { get; set; }
        [Required(ErrorMessage = "Class name is required !")]
        [Display(Name = "Class name")]
        public int Class_id { get; set; }
        [ForeignKey("Class_id")]
        public Class Class { get; set; }

        [Required(ErrorMessage = "Course Name is required !")]
        [Display(Name = "Course Name")]
        public int Course_id { get; set; }
        [ForeignKey("Course_id")]
        public Course Course { get; set; }


        [Required(ErrorMessage = "Faculity Name is required !")]
        [Display(Name = "Faculity Name")]
        public int Faculity_id { get; set; }
        [ForeignKey("Faculity_id")]
        public Faculity Faculity { get; set; }

        [Required(ErrorMessage = "Teacher Name is required !")]
        [Display(Name = "Teacher Name")]
        public int Teacher_id { get; set; }
        [ForeignKey("Teacher_id")]
        public Teacher Teacher { get; set; }

        [Required(ErrorMessage = "Period is required !")]
        [Display(Name = "Period")]

        [DataType(DataType.Duration)]
        public DateTime Period { get; set; }

        [Required(ErrorMessage = "Time is required !")]
        [Display(Name = "Time")]

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public virtual ICollection<Student_classProgram> Student_classProgram { get; set; }
    }
}
