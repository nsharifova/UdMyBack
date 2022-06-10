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
                .ThenInclude(c=>c.LessonVideos)
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

        public async Task<List<Course>> FilterCourse(string? searchTerm, decimal? rating, decimal? minPrice, decimal? maxPrice, int[] instructorIds,int? sortBy)
        {
            using UdMyDbContext context = new();
            var myCourses =  context.Courses
                .Include(c => c.Instructor)
                .Include(c => c.Category)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                myCourses = myCourses.Where(c => c.Name.Contains(searchTerm)
             || c.Category.Name.Contains(searchTerm)
             || c.Instructor.FullName.Contains(searchTerm));
            }
          
            if(minPrice.HasValue && maxPrice.HasValue)
            {
                myCourses = myCourses.Where(c => c.Price >= minPrice && c.Price <= maxPrice);
            }
            if (rating.HasValue)
            {
                myCourses = rating.Value switch
                {
                    1 => myCourses.Where(c => c.Reyting >= 1 && c.Reyting <= 2),
                    2 => myCourses.Where(c => c.Reyting >= 2 && c.Reyting <= 3),
                    3 => myCourses.Where(c => c.Reyting >= 3 && c.Reyting <= 4),
                    4 => myCourses.Where(c => c.Reyting >= 4 && c.Reyting <= 5),
                    _ => myCourses.Where(c => c.Reyting >= 1 && c.Reyting <= 5),
                };
            }

            if (instructorIds.Length > 0)
            {
                myCourses = myCourses.Where(c => instructorIds.Contains(c.InstructorId));
            }

            if (sortBy.HasValue)
            {
                myCourses = sortBy.Value switch
                {
                    0 => myCourses.OrderByDescending(c => c.Price),
                    1 => myCourses.OrderBy(c => c.Price),
                    _ => myCourses.OrderBy(c => c.PublishDate),
                };
            }

            return await myCourses.ToListAsync();
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
