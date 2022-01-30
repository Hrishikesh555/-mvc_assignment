using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EntityDBFIRST.Models
{
    public class Product
    {
        [Key]
        [Display (Name = "Product Id")]
        public long ProductID { get; set; }
        [Required]
        [Display(Name="Product Name")]
        public string ProductName { get; set; }
  
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Date of Purchase")]
        public Nullable<System.DateTime> DateofPurchase { get; set; }
        public string AvailabilityStatus { get; set; }

        [Required]
        public Nullable<long> CategoryID { get; set; }
        [Required]
        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Photo { get; set; }

       public Nullable<decimal>  Quantity { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}