using Business.Abstract;
using Entites;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UdmyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonManager _lessonManager;

        public LessonController(ILessonManager lessonManager)
        {
            _lessonManager = lessonManager;
        }

        // GET: api/<LessonController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LessonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LessonController>
        [HttpPost]
        public Lesson Add(Lesson lesson )
        {
            _lessonManager.Add(lesson);
            return lesson;

        }
        [HttpGet("GetAll")]
        public List<Lesson> GetAll()
        {
            return _lessonManager.GetAll();
        }
        // PUT api/<LessonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LessonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
