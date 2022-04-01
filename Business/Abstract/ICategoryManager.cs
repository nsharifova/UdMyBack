using Entites;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryManager
    {
       List<Category> GetAll();
        void Add(CategoryDTO categoryDTO);
        void Update(Category category);
        void Remove(int id);


    }
}
