using Microsoft.AspNetCore.Identity;

namespace HomeworkPustok.Models
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
    }
}
