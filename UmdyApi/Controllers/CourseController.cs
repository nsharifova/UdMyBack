using Abp.Domain.Uow;
using AutoMapper;
using Business.Abstract;
using Entites;
using Entites.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UdmyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseManager _courseManager;
        private readonly IMapper _mapper;
        public CourseController(ICourseManager courseManager, IMapper mapper)
        {
            _courseManager = courseManager;
            _mapper = mapper;
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public CourseListDto Get(int? id)
        {
            if(id==null) return null;
            var course = _courseManager.GetById(id.Value);
            var courseMapper = _mapper.Map<Course, CourseListDto>(course);
            return courseMapper;
        }
        [HttpGet()]
        public List<CourseListDto> GetAll()
        {
            var courseList = _courseManager.GetAll();
            var courseMapper= _mapper.Map<List<Course>,List<CourseListDto>>(courseList);
            return courseMapper;
        }
        [HttpGet("category/{categoryId}")]
        public List<Course>? GetCourseByCategory(int? categoryId)
        {
            if (!categoryId.HasValue) return null;
            return _courseManager.GetCoursesByCategory(categoryId.Value);
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<JsonResult> Add(CourseDTOs course)
        {
            JsonResult res = new(new { });
            try
            {
                var _mapperCourse=_mapper.Map<Course>(course);
                _courseManager.Add(_mapperCourse);
                res.Value = new { status = 200, success = course };
            }
            catch (Exception e)
            {
                res.Value = new { status = 400, errors = e.Message};
            }
            return res;
            
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int? id, [FromBody] CourseDTOs courseDT)
        {
            
            JsonResult res = new(new { });
            if (id == null) {
                res.Value = new {status=403,message="Id is required" };
                return res;
            };
            var _mapperCourse = _mapper.Map<CourseDTOs,Course>(courseDT);

            _courseManager.Update(id.Value, _mapperCourse);
            res.Value = new { status = 200, message = "Successfully updated" };
            return res;
        }
        
        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
