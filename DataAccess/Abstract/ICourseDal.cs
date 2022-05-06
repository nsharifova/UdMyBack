using Core;
using Entites;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICourseDal :IEntityRepository<Course>
    {
        public void AddCourseWithLesson(Course courseDTOs);
        public List<CourseListDto> ListCourses();
        public CourseListDto GetCourse(int id);
        public void UpdateCourse(int id,CourseDTOs courseDTOs);
        public List<CourseListDto> GetCourseByCategory(int categoryId);
    }
}
