using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites;
using Entites.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCourseDal : EFEntityRepositoryBase<UdMyDbContext, Course>, ICourseDal
    {
        public void AddCourseWithLesson(Course course)
        {
            using var context = new UdMyDbContext();
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public Course GetCourse(int id)
        {
            using UdMyDbContext context = new();
            var singleCourse = context.Courses
                .Include(c => c.Category)
                .Include(c => c.CourseSpecifactions)
                .ThenInclude(c => c.Specifaction)
                .Include(cs => cs.Instructor)
                .Include(c => c.Lessons)
                .FirstOrDefault(c => c.Id == id);

            return singleCourse;
        }

        public List<Course> GetCourseByCategory(int categoryId)
        {
            using UdMyDbContext context = new();
            return context.Courses
                .Where(c => c.CategoryId == categoryId)
                .Include(c => c.Category)
                .Include(c => c.Instructor)
                .ToList();
        }

        public List<Course> ListCourses()
        {
            using UdMyDbContext context = new();
              var myCourses= context.Courses
                .Include(c => c.Instructor)
                .Include(c => c.Category)
                .Include(c => c.Lessons)
                .Include(c => c.CourseSpecifactions)
                .ThenInclude(c=>c.Specifaction)
                .ToList();
            return myCourses;

        }

        public void UpdateCourse(int id, Course course)
        {
            using UdMyDbContext context = new();
            course.Id = id;
            var singleCourse = GetCourse(id);
            
            context.RemoveRange(singleCourse.CourseSpecifactions);
            //context.Specifactions.RemoveRange(singleCourse.CourseSpecifactions.Where(c=>c.CourseId==id).ToArray());


            context.Courses.Update(course);
            context.SaveChanges();
        }
    }
}
