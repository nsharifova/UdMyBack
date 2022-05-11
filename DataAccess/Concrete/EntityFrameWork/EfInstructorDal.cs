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
    public class EfInstructorDal : EFEntityRepositoryBase<UdMyDbContext, Instructor>, IInstructorDal
    {
        public Instructor? InstructorCoursesById(int instructorId)
        {
            using UdMyDbContext context = new();

            return context.Instructors
                  .Include("Courses.Category")
                  .Include("Courses.Lessons.LessonVideos")
                  //.Include("Courses.CourseSpecifactions")
                  .FirstOrDefault(c=>c.Id==instructorId);

        }
    }
}
