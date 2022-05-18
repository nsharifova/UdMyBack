using AutoMapper;
using Entites;
using Entites.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UdmyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AccountController(UserManager<User> userManager, IMapper mapper, IConfiguration config)
        {
            _userManager = userManager;
            _mapper = mapper;
            _config = config;
        }

        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.UserName = userDTO.Email;
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            if (!result.Succeeded)
            {
                return StatusCode(403);
            }
            return StatusCode(201);

        }

        // POST api/<AccountController>
        [HttpPost("login")]
        public async Task<JsonResult> LoginUser([FromBody] LoginUserDTO userDTO)
        {
            JsonResult res = new(new { });
            var findUser = await _userManager.FindByEmailAsync(userDTO.Email);
            var checkPassword = await _userManager.CheckPasswordAsync(findUser, userDTO.Password);
            if (findUser != null && checkPassword)
            {

                var claims = new[]{
                    new Claim(JwtRegisteredClaimNames.Sub,_config["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                     new Claim("UserId", findUser.Id.ToString()),
                     new Claim("Firstname", findUser.Firstname.ToString()),
                     new Claim("Lastname", findUser.Lastname.ToString()),
                     new Claim("Email", findUser.Email.ToString()),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn
                    );

                var writeToken = new JwtSecurityTokenHandler().WriteToken(token);

                res.Value = new { status=200,message=writeToken };
                return res;
            }
            res.Value = new { status = 403, message = "Email ve ya parol yanlişdir" };

            return res;

        }
        //var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
        //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, findUser.Id));
        //identity.AddClaim(new Claim(ClaimTypes.Name, findUser.UserName));
        //await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
        //new ClaimsPrincipal(identity));

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
