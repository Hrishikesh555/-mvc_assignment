using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeProj.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="This field is mandatory")]
        public string username { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string password { get; set; }
    }
}