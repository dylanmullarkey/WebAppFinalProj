using Microsoft.EntityFrameworkCore;
using WebAppFinalProj.Models;

namespace WebAppFinalProj
{
    public class UserInfoContext : DbContext
    {
        public UserInfoContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
    }
}
