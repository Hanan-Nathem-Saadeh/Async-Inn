using Async_Inn_Management_System.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Async_Inn_Management_System.Models.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> Register(RegisterDto data, ModelStateDictionary modelState);
        public Task<UserDto> Authenticate(string username, string password);
    }
}
