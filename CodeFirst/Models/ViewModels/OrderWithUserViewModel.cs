using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Models.ViewModels
{
    public class OrderWithUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}