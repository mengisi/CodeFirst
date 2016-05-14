using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Submit time")]
        public DateTime SubmitTime { get; set; }

        [Display(Name = "Approved time")]
        public DateTime? ApproveOrRefuseTime { get; set; }

        [Display(Name = "Approved")]
        public bool? IsApproved { get; set; }

        [Required]
        [Display(Name = "Product name *")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Quantity *")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Price *")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Total *")]
        public double Total { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}