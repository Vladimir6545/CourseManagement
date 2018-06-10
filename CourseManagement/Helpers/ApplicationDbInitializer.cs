using CourseManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CourseManagement.Helpers
{
    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            Course english = new Course { Id = 1, Name = "English", Cost = 2500, CourseDateTime = new DateTime(2017, 6, 14, 6, 0, 0) };
            Course spanish = new Course { Id = 1, Name = "Spanish", Cost = 3500, CourseDateTime = new DateTime(2017, 6, 16, 6, 0, 0) };
            Course china = new Course { Id = 1, Name = "Chaina", Cost = 5000, CourseDateTime = new DateTime(2017, 6, 14, 18, 0, 0) };

            context.Courses.Add(english);
            context.Courses.Add(spanish);
            context.Courses.Add(china);
        }
    }
}