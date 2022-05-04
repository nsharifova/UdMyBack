using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTOs
{
    public class CategoryListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? LessonCount { get; set; }
        public bool IsFeatured { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
