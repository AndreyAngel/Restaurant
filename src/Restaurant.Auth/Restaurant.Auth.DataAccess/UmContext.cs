using Microsoft.EntityFrameworkCore;
using Restaurant.Auth.DataAccess.Config;
using Restaurant.Auth.DataAccess.DTO.Auth;

namespace Restaurant.Auth.DataAccess
{
    public class UmContext : DbContext
    {
        public DbSet<UserDto> Users { get; set; }

        public DbSet<RoleDto> Roles { get; set; }

        public UmContext(DbContextOptions<UmContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserToRoleConfig());
        }
    }
}
