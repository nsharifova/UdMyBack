using Business.Abstract;
using Entites;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UdmyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorManager _instructorManager;

        public InstructorController(IInstructorManager instructorManager)
        {
            _instructorManager = instructorManager;
        }

        // GET: api/<InstructorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InstructorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InstructorController>
        [HttpPost]
        public Instructor Add(Instructor instructor)
        {
                _instructorManager.Add(instructor);
            return instructor;

        }
        [HttpGet("GetAll")]
        public List<Instructor> GetAll()
        {
            return _instructorManager.GetAll();
        }

        // PUT api/<InstructorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InstructorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
