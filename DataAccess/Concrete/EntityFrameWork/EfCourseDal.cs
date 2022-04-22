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
        public void AddCourseWithLesson(CourseDTOs dtoCourse)
        {
            using var context = new UdMyDbContext();
            Course course = new()
            {
                Name = dtoCourse.Name,
                Description = dtoCourse.Description,
                Summary = dtoCourse.Summary,
                CategoryId = dtoCourse.CategoryId,
                PhotoUrl = dtoCourse.PhotoUrl,
                Price = dtoCourse.Price,
                Discount = dtoCourse.Discount,
                PublishDate = DateTime.Now,
                InstructorId = dtoCourse.InstructorId,
                TrailerUrl = dtoCourse.TrailerUrl,
                Reyting = dtoCourse.Reyting,
                IsFeatured = dtoCourse.IsFeatured,
                Lessons = new List<Lesson>(),
            };
            course.CourseSpecifactions = new List<CourseSpecifaction>();
            if (dtoCourse.Lessons != null && dtoCourse.Lessons.Count > 0)
            {
                course.Lessons.AddRange(
                dtoCourse.Lessons.Select(les => new Lesson { Name = les.Name }));
            }
            if (dtoCourse.SpecificationDTOs != null && dtoCourse.SpecificationDTOs.Count > 0)
            {
                //Specification
                var specifactionList = dtoCourse.SpecificationDTOs.Select(c => new Specifaction { Icon = c.Icon, Value = c.Value }).ToList();
                context.Specifactions.AddRange(specifactionList);
                context.SaveChanges();
                //Course Specifiton
                course.CourseSpecifactions.AddRange(specifactionList.Select(c => new CourseSpecifaction { CourseId = course.Id, SpecifactionId = c.Id }));
            }
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public List<CourseListDto> ListCourses()
        {
            using UdMyDbContext context = new();
            var courseList = new List<CourseListDto>();
            var myCourses = context.Courses
                .Select(cr => new CourseListDto(cr.Id,cr.Name, cr.Summary,cr.Description,cr.PhotoUrl,cr.Price,cr.Discount,
                cr.IsFeatured,cr.Reyting,cr.CategoryId,cr.Instructor.FullName,cr.Instructor.ProfilImg,cr.PublishDate)
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
    }
}
