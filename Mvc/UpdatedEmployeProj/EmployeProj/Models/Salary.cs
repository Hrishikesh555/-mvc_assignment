using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeProj.Models
{
    public class Salary
    {
        [Key]
        public int SalID { get; set; }


        public Nullable<int> EmployeId { get; set; }

        public int Salarys { get; set; }

        public int Tax { get; set; }

        public int HRA { get; set; }

        public int DA { get; set; }

        public virtual Empploye Empploye { get; set; }

    }
}