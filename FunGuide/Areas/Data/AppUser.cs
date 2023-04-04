using Microsoft.AspNetCore.Identity;
using FunGuide.Models;

namespace FunGuide.Areas.Data
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public List<Activities> Activities { get; set; } = new();
        public List<UserActivities>? UserActivities { get; set; } = new();
    }
}
