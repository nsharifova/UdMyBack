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
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryDal _dal;

        public CategoryManager(ICategoryDal dal)
        {
            _dal = dal;
        }

        public void Add(CategoryDTO category)
        {
            Category cat = new()
            {
                Name = category.Name,
                IsDeleted = category.IsDeleted,
                IsFeatured = category.IsFeatured,
                ParentCategoryId = category.ParentCategoryId,
                ModifadeOn = DateTime.Now,
            };
            _dal.Add(cat);
        }

        public List<Category> GetAll()
        {
            return _dal.GetAll();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
