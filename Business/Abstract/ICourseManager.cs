using Entites;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseManager
    {
        List<CourseListDto> GetAll();
        CourseListDto GetById(int id);
        List<CourseListDto> GetCoursesByCategory(int categoryId);
        void Add(Course course);
        void Remove(int id);
        void Update(int id,CourseDTOs course);
    }
}
