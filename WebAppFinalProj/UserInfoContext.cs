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
        public DbSet<FavoriteCar> FavoriteCars { get; set; }
        public DbSet<FavoriteFood> FavoriteFoods { get; set; }
    }
}
