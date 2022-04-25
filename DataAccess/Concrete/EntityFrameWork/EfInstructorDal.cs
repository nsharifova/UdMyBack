using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfInstructorDal : EFEntityRepositoryBase<UdMyDbContext, Instructor>, IInstructorDal
    {
        public List<InstructorCourseDTO> InstructorCoursesById(int? instructorId)
        {
            using UdMyDbContext context = new();

            return context.Instructors.Where(ins => ins.Id == instructorId)
                  .Select(ins => new InstructorCourseDTO()
                  {

                      InstructorName = ins.FullName,
                      InstructorPhoto = ins.ProfilImg,
                      CourseList = ins.Courses.Select(cs => 
                      new CourseListDto(cs.Id, cs.Name, cs.Summary,
                        cs.Description, cs.PhotoUrl, cs.Price, cs.Discount, cs.IsFeatured,
                        cs.Reyting, cs.Category.Name, cs.Instructor.FullName,
                        cs.Instructor.ProfilImg, cs.PublishDate)).ToList()

                  }).ToList();

        }
    }
}
