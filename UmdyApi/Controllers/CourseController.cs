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

        public CourseController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _courseManager.GetAll();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpGet("GetAll")]
        public List<Course> GetAll()
        {
            return _courseManager.GetAll();
        }
        
        // POST api/<CourseController>
        [HttpPost]
        public JsonResult Add(CourseDTOs course)
        {
            JsonResult res = new(new { });
            try
            {
                _courseManager.Add(course);
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
