using Microsoft.AspNetCore.Identity;

namespace lesson5_EmailSender.Models
{
    public class User : IdentityUser
    {
        public int Age { get; set; }
        public string Country { get; set; }
    }
}
