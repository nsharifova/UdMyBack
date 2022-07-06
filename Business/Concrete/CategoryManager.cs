﻿using Business.Abstract;
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
                IsFeatured = category.IsFeatured,
                ParentCategoryId = category.ParentCategoryId,
                ModifadeOn = DateTime.Now,
            };
            _dal.Add(cat);
        }

        public List<CategoryWithChildernDTO> GetAll()
        {
            return _dal.GetCategoryWithChildrens();
        }


        public async Task<List<Category>> GetCategoryWithParents()
        {
            return await _dal.GetCategoryWithParents();
        }

        public List<CategoryListDTO> GetChildrenByParentId(int parentId)
        {
            return _dal.GetCategoryChildrenByID(parentId);
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _dal.GetById(categoryId);
        }
        public void Remove(int id)
        {
            var findCategory = _dal.Get(c => c.Id == id);
            findCategory.IsDeleted = true;
            _dal.Update(findCategory);
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
