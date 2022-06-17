using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTOs
{
    public class CourseListFilter
    {
        public decimal MaxPrice { get; set; }
        public List<CourseListDto> Courses { get; set; }
    }
}
