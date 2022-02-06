using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeProj.Models
{
    public class Empploye
    {
        [Key]
        
        public int EmployeId { get; set; }

        [Display (Name ="Name")]
        [Required (ErrorMessage ="Name feild is Required")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Alphabet only")]
        [MaxLength(20,ErrorMessage="Name should not be greater than 20 alphabet")]
        [MinLength(2, ErrorMessage = "name should Be greater than 2 alphabet")]
        public string EmployeName { get; set; }

        [Display(Name ="Designation")]
        [Required(ErrorMessage ="Designation Feild is Required")]
        public string Designation { get; set; }

        public  string Profile { get; set; }

        [Required ]

        public Nullable <System.DateTime> DateOfJoing { get; set; }


        [Required]
        public string  City { get; set; }

        [Display(Name ="Mobile")]
        [Required]
        [MaxLength(10, ErrorMessage ="Number should be of 10 digit")]

        public string Contact { get; set; }

        [Display(Name ="Department")]
        [Required (ErrorMessage ="Department name is required")]
        public Nullable <int> DepartmentId { get; set; }

        [Required]
        public string  Status { get; set; }

        public virtual Department Department { get; set; }
    }
}