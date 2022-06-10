using Business.Abstract;
using DataAccess.Abstract;
using Entites;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseSpecifactioManager : ICourseManager
    {
        private readonly ICourseDal _coursedal;

        public CourseSpecifactioManager(ICourseDal coursedal)
        {
            _coursedal = coursedal;
        }

        public void Add(Course dtoCourse)
        {
            _coursedal.AddCourseWithLesson(dtoCourse);
        }

        public List<Course> GetAll()
        {
            return _coursedal.ListCourses();
        }

        public async Task<Course> GetById(int id)
        {
            return await _coursedal.GetCourse(id);
        }

        public List<Course> GetCoursesByCategory(int categoryId)
        {
           return _coursedal.GetCourseByCategory(categoryId);
        }

        public Task<List<Course>>? GetCourseWithFilter(string? q, decimal? rating, decimal? minPrice, decimal? maxPrice, int[] instructorIds, int? sortBy)
        {
            return _coursedal.FilterCourse(q, rating, minPrice, maxPrice,  instructorIds,sortBy);
        }

        public void Remove(int id)
        {
            var getCourse= _coursedal.Get(c => c.Id == id && !c.IsDeleted);
            if (getCourse != null)
            {
                getCourse.IsDeleted = true;
                _coursedal.Update(getCourse);
            }
        }

        public void Update(int id, Course course)
        {
            _coursedal.UpdateCourse(id, course);   
        }

 
    }
}
