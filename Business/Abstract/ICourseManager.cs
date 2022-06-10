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
        List<Course> GetAll();
        Task<List<Course>>? GetCourseWithFilter(string? q, decimal? rating, decimal? minPrice, decimal? maxPrice, int[] instructorIds, int? sortBy);
        Task<Course> GetById(int id);
        List<Course> GetCoursesByCategory(int categoryId);
        void Add(Course course);
        void Remove(int id);
        void Update(int id, Course course);
    }
}
