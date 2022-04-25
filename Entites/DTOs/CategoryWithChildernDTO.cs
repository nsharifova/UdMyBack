using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTOs
{
    public class CategoryWithChildernDTO
    {
        public CategoryWithChildernDTO()
        {
            Childrens = new List<CategoryListDTO>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<CategoryListDTO>? Childrens { get; set; }
    }
}
