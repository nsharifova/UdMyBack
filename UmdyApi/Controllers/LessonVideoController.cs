using Business.Abstract;
using Entites;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UdmyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonVideoController : ControllerBase
    {
        private readonly ILessonVideoManager _manager;
        // GET: api/<LessonVideoController>
        public LessonVideoController(ILessonVideoManager manager)
        {
            _manager = manager;
        }
        [HttpGet]

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LessonVideoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LessonVideoController>
        [HttpPost]
        public LessonVideo Add(LessonVideo lessonVideo)
        {
            _manager.Add(lessonVideo);
            return lessonVideo;

        }
        [HttpGet("GetAll")]
        public List<LessonVideo> GetAll()
        {
            return _manager.GetAll();
        }
        // PUT api/<LessonVideoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LessonVideoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
