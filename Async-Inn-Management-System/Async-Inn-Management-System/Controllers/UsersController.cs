using Async_Inn_Management_System.Models;
using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _UserService;


        public UsersController(IUserService userService)
        {
            _UserService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto data)
        {
            try { 
            await _UserService.Register(data, this.ModelState);
            if (ModelState.IsValid)
            {
                return Ok("Registered done");

            }
            return BadRequest(new ValidationProblemDetails(ModelState));
          
        }
            catch (Exception e)
            {

                return BadRequest(e.Message);
    }

}
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>>LogIn([FromBody] LogInDto login)

        {
            try
            {
               await _UserService.Authenticate(login.Username, login.Password);
                if (ModelState.IsValid)
                {
                    return Ok("Welcome To your Page :)");

                }
                else
                {
                    return BadRequest("Please Regester First...");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

            }
}
