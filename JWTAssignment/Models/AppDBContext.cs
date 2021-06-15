

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWTAssignment.Models
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public AppDBContext()
        {

        }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData( new Role { Name = "Admin", NormalizedName = "ADMIN" }, new Role { Name = "Normal", NormalizedName = "NORMAL" });
         
        }
    }
}
