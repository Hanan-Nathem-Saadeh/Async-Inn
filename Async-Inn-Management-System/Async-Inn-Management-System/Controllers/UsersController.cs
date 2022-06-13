using Async_Inn_Management_System.Models;
using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<UserDto>> Login(UserDto user)
        {
            UserDto userDto = await _UserService.Authenticate(user.Username, user.Password);
            if (userDto != null)
            {
                return Ok(userDto);

            }
            return BadRequest("user and password not matching");


        }
        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<UserDto>> Me()
        {
            // Following the [Authorize] phase, this.User will be ... you.
            // Put a breakpoint here and inspect to see what's passed to our getUser method
            return await _UserService.GetUser(this.User);
        }






    }
}
