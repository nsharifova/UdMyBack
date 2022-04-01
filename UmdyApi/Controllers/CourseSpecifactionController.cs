using Business.Abstract;
using Entites;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UdmyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSpecifactionController : ControllerBase
    {
        private readonly ICourseSpecifactionManager _courseSpecifactionManager;

        public CourseSpecifactionController(ICourseSpecifactionManager courseSpecifactionManager)
        {
            _courseSpecifactionManager = courseSpecifactionManager;
        }

        // GET: api/<CourseSpecifactionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CourseSpecifactionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CourseSpecifactionController>
        [HttpPost]
        public CourseSpecifaction Add(CourseSpecifaction courseSpecifaction)
        {
            _courseSpecifactionManager.Add(courseSpecifaction);
            return courseSpecifaction;

        }
        [HttpGet("GetAll")]
        public List<CourseSpecifaction> GetAll()
        {
            return _courseSpecifactionManager.GetAll();
        }
        // PUT api/<CourseSpecifactionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourseSpecifactionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
