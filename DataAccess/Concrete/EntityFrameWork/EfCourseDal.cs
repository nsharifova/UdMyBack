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
            //Course course = new()
            //{
            //    Name = dtoCourse.Name,
            //    Description = dtoCourse.Description,
            //    Summary = dtoCourse.Summary,
            //    CategoryId = dtoCourse.CategoryId,
            //    PhotoUrl = dtoCourse.PhotoUrl,
            //    Price = dtoCourse.Price,
            //    Discount = dtoCourse.Discount,
            //    PublishDate = DateTime.Now,
            //    InstructorId = dtoCourse.InstructorId,
            //    TrailerUrl = dtoCourse.TrailerUrl,
            //    Reyting = dtoCourse.Reyting,
            //    IsFeatured = dtoCourse.IsFeatured,
            //    Lessons = new List<Lesson>(),
            //};
            //course.CourseSpecifactions = new List<CourseSpecifaction>();
            //if (course.Lessons != null && course.Lessons.Count > 0)
            //{
            //    course.Lessons.AddRange(
            //    course.Lessons.Select(les => new Lesson { Name = les.Name }));
            //}
            //if (course.CourseSpecifactions != null && course.CourseSpecifactions.Count > 0)
            //{
            //    //Specification
            //    var specifactionList = course.CourseSpecifactions.Select(c => new Specifaction { Icon = c.Icon, Value = c.Value }).ToList();
            //    context.Specifactions.AddRange(specifactionList);
            //    context.SaveChanges();
            //    //Course Specifiton
            //    course.CourseSpecifactions.AddRange(specifactionList.Select(c => new CourseSpecifaction { CourseId = course.Id, SpecifactionId = c.Id }));
            //}
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public CourseListDto GetCourse(int id)
        {
            using UdMyDbContext context = new();
            var cr = context.Courses
                .Include(c => c.Category)
                .Include(c => c.CourseSpecifactions)
                .ThenInclude(c => c.Specifaction)
                .Include(cs => cs.Instructor)
                .Include(c => c.Lessons)
                .FirstOrDefault(c => c.Id == id);

            var courseDto = new CourseListDto(cr.Id, cr.Name, cr.Summary, cr.Description,
                cr.PhotoUrl, cr.Price, cr.Discount,
            cr.IsFeatured, cr.Reyting, cr.Category.Name,
            cr.Instructor.FullName,
            cr.Instructor.ProfilImg, cr.PublishDate)
            {
                SpecificationList = cr.CourseSpecifactions.Select(crs => new SpecificationDTOs
                {
                    Icon = crs.Specifaction.Icon,
                    Value = crs.Specifaction.Value
                }).ToList(),
                Lessons = cr.Lessons.Select(c => new LessonDTOs()
                {
                    LessonId = c.Id,
                    Name = c.Name
                }).ToList()
            };

            return courseDto;
        }

        public List<CourseListDto> GetCourseByCategory(int categoryId)
        {
            using UdMyDbContext context = new();
            return context.Courses.Where(c => c.CategoryId == categoryId)
                .Include(c => c.Category).Include(c => c.Instructor)
                .Select(c => new CourseListDto(c.Id, c.Name, c.Summary, c.Description,
                c.PhotoUrl, c.Price,
                c.Discount, c.IsFeatured, c.Reyting, c.Category.Name, c.Instructor.FullName, c.Instructor.ProfilImg,
                c.PublishDate)).ToList();

        }

        public List<CourseListDto> ListCourses()
        {
            using UdMyDbContext context = new();
            var courseList = new List<CourseListDto>();
            var myCourses = context.Courses
                .Select(cr => new CourseListDto(cr.Id, cr.Name, cr.Summary, cr.Description, cr.PhotoUrl, cr.Price, cr.Discount,
                cr.IsFeatured, cr.Reyting, cr.Category.Name, cr.Instructor.FullName, cr.Instructor.ProfilImg, cr.PublishDate)
                {
                    SpecificationList = cr.CourseSpecifactions.Select(crs => new SpecificationDTOs
                    {
                        Icon = crs.Specifaction.Icon,
                        Value = crs.Specifaction.Value
                    }).ToList(),
                    Lessons = cr.Lessons.Select(c => new LessonDTOs()
                    {
                        LessonId = c.Id,
                        Name = c.Name
                    }).ToList(),


                }).ToList();
            return myCourses;

        }

        public void UpdateCourse(int id, CourseDTOs course)
        {
            using UdMyDbContext context = new();
            Course? selectedCourse = context.Courses
                .Include(c=>c.CourseSpecifactions)
                .FirstOrDefault(c => c.Id == id);
            if (selectedCourse != null)
            {
                selectedCourse.Id = id;
                selectedCourse.Name = course.Name;
                selectedCourse.Description = course.Description;
                selectedCourse.Updatedate = DateTime.Now;
                selectedCourse.ModifadeOn = DateTime.Now;
                selectedCourse.IsFeatured = course.IsFeatured;
                selectedCourse.Summary = course.Summary;
                selectedCourse.Discount = course.Discount;
                selectedCourse.CategoryId = course.CategoryId;
                selectedCourse.InstructorId = course.InstructorId;
                selectedCourse.Lessons = new List<Lesson>();
                selectedCourse.PhotoUrl = course.PhotoUrl;
                selectedCourse.Reyting = course.Reyting;
                selectedCourse.Price = course.Price;
                selectedCourse.TrailerUrl = course.TrailerUrl;
                if (course.SpecificationDTOs != null && course.SpecificationDTOs.Count > 0)
                {
                    
                    selectedCourse.CourseSpecifactions.Clear();
                        //Create Specification 
                        var specifactionList = course.SpecificationDTOs
                        .Select(c => new Specifaction { Icon = c.Icon, Value = c.Value })
                        .ToList();
                    context.Specifactions.AddRange(specifactionList);
                    context.SaveChanges();
                    
                    //Bind Course with specification
                    selectedCourse.CourseSpecifactions
                        .AddRange(specifactionList.Select(c =>
                        new CourseSpecifaction
                        { CourseId = selectedCourse.Id, SpecifactionId = c.Id }));
                    context.Courses.Update(selectedCourse);
                    context.SaveChanges();
                }
            }
        }
    }
}
