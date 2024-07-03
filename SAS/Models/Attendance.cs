using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public enum AttaStats
    {
        Present = 0,
        Absent = 1,
    }
    public class Attendance
    {
        [Key]
        public int Attendance_id { get; set; }
        [Required(ErrorMessage = "Student Name is required !")]
        [Display(Name = "Student Name")]
        public int Stud_id { get; set; }
        [ForeignKey("Stud_id")]
        public Student Student { get; set; }

        [Required(ErrorMessage = "Academic year is required !")]
        [Display(Name = "Academic Year")]
        public int Academic_y_id { get; set; }
        [ForeignKey("Academic_y_id")]
        public Academic_Year Academic_Year { get; set; }

        [Required(ErrorMessage = "Department Name is required !")]
        [Display(Name = "Department Name")]
        public int Department_id { get; set; }
        [ForeignKey("Department_id")]
        public Department Department { get; set; }

        [Required(ErrorMessage = "Enrollment is required !")]
        [Display(Name = "Enrollment")]
        public int Enrollment_id { get; set; }
        [ForeignKey("Enrollment_id")]
        public Enrollment Enrollment { get; set; }


        [Required(ErrorMessage = "Faculity Name is required !")]
        [Display(Name = "Faculity Name")]
        public int Faculity_id { get; set; }
        [ForeignKey("Faculity_id")]
        public Faculity Faculity { get; set; }

        [Required(ErrorMessage = "Semister id is required !")]
        [Display(Name = "Semister Id")]

        public int Semister_id { get; set; }
        [ForeignKey("Semister_id")]
        public Semester Semester { get; set; }

        [Required(ErrorMessage = "Attendance date is required !")]
        [Display(Name = "Attendance Date")]

        [DataType(DataType.Date)]
        public DateTime Attendance_date { get; set; }
        [Required(ErrorMessage = "Attendance time is required !")]

        [DataType(DataType.Time)]
        [Display(Name = "Attendance Time")]
        public DateTime Attendance_time { get; set; }

        //[Required(ErrorMessage = "Attendance status is required !")]
        //[Display(Name = "Attendance Status")]
        //public string Attendance_status { get; set; }

        [Required(ErrorMessage = "Attendance status is required ! please select one of them ?")]
        [Display(Name = " Attendance Status")]
        public AttaStats Status { get; set; }

        [Required(ErrorMessage = "Attendance remark is required !")]
        [Display(Name = "Attendance Remark")]
        public String Remark { get; set; }


    }

}
