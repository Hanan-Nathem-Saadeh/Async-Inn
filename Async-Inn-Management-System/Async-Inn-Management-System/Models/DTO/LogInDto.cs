using System.ComponentModel.DataAnnotations;

namespace Async_Inn_Management_System.Models.DTO
{
    public class LogInDto
    {
        [Required(ErrorMessage = "The Username is required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The password is required!")]
        public string Password { get; set; }
    }
}
