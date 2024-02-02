using Restaurant.Auth.Core;

namespace Restaurant.Auth.Contracts
{
    public sealed record UserDetailsDto(Guid id, string email, string name, DateTime registrationDT, bool isActive, List<RoleDto?> roles);
}
