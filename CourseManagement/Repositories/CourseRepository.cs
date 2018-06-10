using CourseManagement.Helpers;
using CourseManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CourseManagement.Repositories
{
    public class CourseRepository
    {
        public async Task <IEnumerable<Course>> GetCourses()
        {
            using (var db = ApplicationDbContext.Create())
            {
                return await db.Courses
                    .ToListAsync();
            }
        }

        public async Task Create(Course course)
        {
            using (var db = ApplicationDbContext.Create())
            {
                db.Courses.Add(course);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Course> GetEdit(int? id)
        {
            using (var db = ApplicationDbContext.Create())
            {
                Course cource = await db.Courses.FindAsync(id);
                return cource;
            }
        }
        
        public async Task Edit([Bind(Include = "Id, Name, Cost, CourseDateTime, Duration")] Course course)
        {
            using (var db = ApplicationDbContext.Create())
            {
                db.Entry(course).State = EntityState.Modified;
                await db.SaveChangesAsync();
            } 
        }

        public async Task Delete(int id)
        {
            using (var db = ApplicationDbContext.Create())
            {
                Course course = await db.Courses.FindAsync(id);
                db.Courses.Remove(course);
                await db.SaveChangesAsync();
            }
        }
    }
}