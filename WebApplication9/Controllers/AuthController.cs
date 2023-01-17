using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication9.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {

        [HttpPost("Login")]

        public async Task<IActionResult> Login(string username, string password)
        {
            if (Person.Username == username)
            {
                if (Person.Password != password) throw new Exception("meesage");
            }

            var token = Token.CreateToken(Person.Username, Person.Role);
            Person.Token = token;
            return Ok(Person.Token);
        }

        [HttpGet("getadmin")]
        [Authorize(Roles ="Admin,User")]
        public async Task<IActionResult> GetAdmin()
        {
            return Ok(Person.Role);
        }


        [HttpGet("getuser")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUser()
        {
            return Ok(Person.Role);
        }


        [HttpPost("Update")]

        public async Task<IActionResult> UpdateUser(string username, string password,string role)
        {
            Person.Username = username;
            Person.Password = password;
            Person.Role = role; 
            return Ok(true);
        }

    }
}
