using Microsoft.AspNetCore.Identity;

namespace Async_Inn_Management_System.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Gender { get; set; }
    }
}
