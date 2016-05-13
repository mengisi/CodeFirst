using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.Models.ViewModels
{
    public class CreateEmployeeViewModel
    {
        [Required]
        [Display(Name = "FirstName *")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName *")]
        public string LastName { get; set; }

        public string Adress { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email *")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}