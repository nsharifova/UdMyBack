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

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet("getall")]
        public List<Category> GetCategories()
        {
            return _categoryManager.GetAll();
        }
        [HttpPost("Add")]
        public CategoryDTO Add(CategoryDTO category)
        {
            _categoryManager.Add(category);
            return category;
        } 


    }
}
