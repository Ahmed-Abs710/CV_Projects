using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Education_Platform.Models
{
    public class AppDbContext : IdentityDbContext<Users,Roles,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }
    }
}
