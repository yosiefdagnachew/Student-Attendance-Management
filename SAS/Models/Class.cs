using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public class Class
    {
        [Key]
        public int Class_id { get; set; }
        [Required(ErrorMessage = "Class name is required !")]
        [Display(Name = "Class Name")]
        public string Class_name { get; set; }
        [Required(ErrorMessage = "Building Number is required !")]
        [Display(Name = "Building Number")]
        public string Building_number { get; set; }

    }
}
