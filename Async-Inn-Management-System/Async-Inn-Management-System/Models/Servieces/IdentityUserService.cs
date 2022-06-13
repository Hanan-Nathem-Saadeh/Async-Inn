using Async_Inn_Management_System.Models.DTO;
using Async_Inn_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Servieces
{
    public class IdentityUserService  : IUserService
    {
        private UserManager<ApplicationUser> _UserManager;
        private JwtTokenService tokenService;
        public IdentityUserService(UserManager<ApplicationUser> userManager, JwtTokenService jwtTokenService)
        {
            _UserManager = userManager;
            tokenService = jwtTokenService;
        }

        public async Task<UserDto> Authenticate(string username, string password)
        {
            var user = await _UserManager.FindByNameAsync(username);
            if (user != null)
            {
                if (await _UserManager.CheckPasswordAsync(user, password))
                {
                    var userDto = new UserDto
                    {
                        Username = user.UserName,
                        Id = user.Id,
                        Token = await tokenService.GetToken(user,System.TimeSpan.FromMinutes(1000000)),
                    };
                    return userDto;
                }
            }

            //return  (user and password not matching)
            return null;
        }

        public async Task<UserDto> Register(RegisterDto data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
                Gender=data.Gender
            };

            var result = await _UserManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                UserDto userDto = new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15))

                };
                return userDto;
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
               
                    error.Code.Contains("Password") ? "Password Issue" :
                    error.Code.Contains("Email") ? "Email Issue" :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }
            return null;
        }
        public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await _UserManager.GetUserAsync(principal);
            return new UserDto
            {
                Id = user.Id,
                Username = user.UserName
            };
        }

    }
}
