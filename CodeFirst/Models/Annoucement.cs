using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Annoucement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime Updatetime { get; set; }
        public int Visits { get; set; }
    }
}