using AutoMapper;
using Business.Abstract;
using Entites;
using Entites.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UdmyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryManager categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public List<CategoryWithChildernDTO> GetCategories()
        {
            return _categoryManager.GetAll();
        }

        [HttpGet("with-parent")]
        public async Task<List<CategoryWithParentDTO>> GetWithParent()
        {
            var categoryList = await _categoryManager.GetCategoryWithParents();
            var categoryMapper = _mapper.Map<List<CategoryWithParentDTO>>(categoryList);
            return categoryMapper;

        }

        [HttpGet("{id}")]
        public async Task<JsonResult> GetById(int? id)
        {
            JsonResult res = new(new { });
            if(!id.HasValue)
            {
                res.Value = new { status = 404, message = "category not found !!!" };
                return res;


            }
            var categoryList = await _categoryManager.GetCategoryById(id.Value);
            var categoryMapper = _mapper.Map<CategoryWithParentDTO>(categoryList);
            res.Value = new { status=200, data=categoryMapper };
            return res;

        }


        [HttpGet("getchildrens/{parentId}")]
        public List<CategoryListDTO>? GetChildrens(int? parentId)
        {
            if (parentId == null) return null;
            return _categoryManager.GetChildrenByParentId(parentId.Value);
        }
        [HttpPost("Add")]
        public CategoryDTO Add(CategoryDTO category)
        {
            _categoryManager.Add(category);
            return category;
        } 


    }
}
