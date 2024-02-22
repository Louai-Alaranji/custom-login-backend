using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace LoginApp.IdenttiyClasses
{
    public class MyUser : IdentityUser
    {
        public string? Fullname {get; set;}
        public int Contact { get; set;}
        public string? Address { get; set;}

    }
}
