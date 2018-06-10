using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseManagement.Models
{
    public class Course
    {
        public int Id { get; set; }
         [Required]
         [StringLength(25)]
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public DateTime CourseDateTime { get; set; }
        public byte Duration { get; set; }
    }
}