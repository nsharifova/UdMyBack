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

        public async Task<Course> GetCourse(int id)
        {
            using UdMyDbContext context = new();
            var singleCourse =await  context.Courses
                .Include(c => c.Category)
                .Include(c => c.CourseSpecifactions)
                .ThenInclude(c => c.Specifaction)
                .Include(cs => cs.Instructor)
                .Include(c => c.Lessons)
                .FirstOrDefaultAsync(c => c.Id == id);

            return singleCourse;
        }

        public List<Course> GetCourseByCategory(int categoryId)
        {
            using UdMyDbContext context = new();
            return context.Courses
                .Where(c => c.CategoryId == categoryId || c.Category.ParentCategoryId==categoryId)
                .Include(c => c.Category.ParentCategory)
                //.ThenInclude(c=>c.ParentCategory)
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

        public async Task<List<Course>> FilterCourse(string? searchTerm)
        {
            using UdMyDbContext context = new();
            var myCourses = await context.Courses
              .Where(c=>c.Name.Contains(searchTerm)) 
              //|| c.Category.Name.Contains(searchTerm) 
              //|| c.Instructor.FullName.Contains(searchTerm))
              .Include(c => c.Instructor)
              .Include(c => c.Category)
              .ToListAsync();

            return myCourses;
        }
        public async void UpdateCourse(int id, Course course)
        {
            using UdMyDbContext context = new();
            course.Id = id;
            var singleCourse = await GetCourse(id);
            
            context.RemoveRange(singleCourse.CourseSpecifactions);
            //context.Specifactions.RemoveRange(singleCourse.CourseSpecifactions.Where(c=>c.CourseId==id).ToArray());
            context.Courses.Update(course);
            context.SaveChanges();
        }
    }
}
