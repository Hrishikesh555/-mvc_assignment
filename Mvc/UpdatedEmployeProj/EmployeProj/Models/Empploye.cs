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
        
        public string EmployeName { get; set; }

        [Display(Name ="Designation")]
        [Required(ErrorMessage ="Designation Feild is Required")]
        public string Designation { get; set; }

        public  string Profile { get; set; }

        [Required ]

        public Nullable <System.DateTime> DateOfJoing { get; set; }


        public   int Sals { get; set; } 
        
       

        [Required]
        public string  City { get; set; }

        [Display(Name ="Mobile")]
        [Required]
        [RegularExpression(@"^([0-9]{10})*$", ErrorMessage = "Invalid Mobile Number")]

        public string Contact { get; set; }

        [Display(Name ="Department")]
        [Required (ErrorMessage ="Department name is required")]
        public Nullable <int> DepartmentId { get; set; }

        [Required]
        public string  Status { get; set; }

        public virtual Department Department { get; set; }

       

     
    }
}