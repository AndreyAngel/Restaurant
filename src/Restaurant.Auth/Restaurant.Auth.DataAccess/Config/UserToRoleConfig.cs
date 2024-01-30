using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Auth.DataAccess.DTO.Auth;

namespace Restaurant.Auth.DataAccess.Config
{
    internal class UserToRoleConfig : IEntityTypeConfiguration<UserToRoleDto>
    {
        public void Configure(EntityTypeBuilder<UserToRoleDto> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoleId });
            builder.HasOne<UserDto>()
                .WithMany()
                .HasForeignKey(x => x.UserId);
            builder.HasOne<RoleDto>()
                .WithMany()
                .HasForeignKey(x=> x.RoleId);
        }
    }
}
