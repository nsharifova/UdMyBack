using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTOs
{
    public class InstructorCourseDTO
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; } = null!;
        public string? InstructorPhoto { get; set; }
        public List<CourseListDto>? CourseList { get; set;}
    }
}
