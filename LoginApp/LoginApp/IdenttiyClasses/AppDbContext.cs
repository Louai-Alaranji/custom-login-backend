using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoginApp.IdenttiyClasses
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) :
        IdentityDbContext<MyUser>(options)
    {
    }
}
