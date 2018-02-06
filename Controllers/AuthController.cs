using System.Threading.Tasks;
using Helper.API.Data;
using Helper.API.Dtos;
using Helper.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helper.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Username))
                ModelState.AddModelError("username", "Już istnieje");

            // validate request
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);


            var useToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var userToCreate = await _repo.Register(useToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }        
    }
}