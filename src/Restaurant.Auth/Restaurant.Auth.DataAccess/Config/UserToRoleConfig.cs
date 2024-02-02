using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Auth.DataAccess.DTO.Auth;

namespace Restaurant.Auth.DataAccess.Config
{
    internal class UserToRoleConfig : IEntityTypeConfiguration<UserDto>
    {
        public void Configure(EntityTypeBuilder<UserDto> builder)
        {
            builder.HasMany(r => r.Roles)
                .WithMany(u => u.Users);
        }
    }
}
