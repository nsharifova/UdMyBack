using Core;
using Entites;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository <Category>
    {
        List<CategoryListDTO> GetDTOCategories();
        List<CategoryWithChildernDTO> GetCategoryWithChildrens();
        List<CategoryListDTO> GetCategoryChildrenByID(int parentId);
    }
}
