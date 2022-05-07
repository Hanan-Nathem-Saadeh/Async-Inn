using System.ComponentModel.DataAnnotations;

namespace Async_Inn_Management_System.Models.DTO
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Gender { get; set; }  
    }
}
