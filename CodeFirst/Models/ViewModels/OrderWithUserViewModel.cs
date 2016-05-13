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




        public int Id { get; set; }

        public DateTime SubmitTime { get; set; }

        public DateTime? ApproveTime { get; set; }

        public bool IsApproved { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double Total { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}