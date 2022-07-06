using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites;
using Entites.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCategoryDal : EFEntityRepositoryBase<UdMyDbContext, Category>, ICategoryDal
    {
        public List<CategoryListDTO> GetCategoryChildrenByID(int parentId)
        {
            using UdMyDbContext context = new();
           return context.Categories.Where(c => c.ParentCategoryId == parentId)
                .Select(c => new CategoryListDTO
                {
                    Id = c.Id,
                    ParentCategoryId = c.ParentCategoryId,
                    Name=c.Name,
                    IsFeatured=c.IsFeatured,
                }).ToList();

        }

        public async Task<List<Category>> GetCategoryWithParents()
        {
            using UdMyDbContext context = new();
            return await context.Categories.Where(c => !c.IsDeleted).Include(c => c.ParentCategory).ToListAsync();


        }
        public async Task<Category>? GetById(int categoryId)
        {
            using UdMyDbContext context = new();
            return await context.Categories.
                Include(c=> c.ParentCategory).
                FirstOrDefaultAsync(c=> c.Id == categoryId);



        }
        public List<CategoryWithChildernDTO> GetCategoryWithChildrens()
        {
            var categoryList = GetDTOCategories();

            return categoryList.Where(c => c.ParentCategoryId == null)
                 .Select(c => new CategoryWithChildernDTO()
                 {
                     CategoryId = c.Id,
                     CategoryName = c.Name,
                     Childrens = categoryList.Where(ch => ch.ParentCategoryId == c.Id 
                      && ch.ParentCategoryId != null)
                 }).ToList();

        }

        public List<CategoryListDTO> GetDTOCategories()
        {
            using UdMyDbContext context = new();
            return context.Categories.Select(c => new CategoryListDTO()
            {
                Id = c.Id,
                Name = c.Name,
                IsFeatured = c.IsFeatured,
                ParentCategoryId = c.ParentCategoryId,
                //LessonCount=context.Courses.Where(cr=>cr.CategoryId==c.Id).Count(),
            }).ToList();



        }

        //Hyerarchy


    }
}