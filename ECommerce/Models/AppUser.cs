using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models
{
    public class AppUser : IdentityUser
    {
        public string Occupation { get; set; }
    }
}
