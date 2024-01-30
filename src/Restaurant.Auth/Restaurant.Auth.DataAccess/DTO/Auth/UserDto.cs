namespace Restaurant.Auth.DataAccess.DTO.Auth
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public DateTime RegistrationDT { get; set; }

        public string Password { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public List<UserToRoleDto> Roles { get; set; } = new();
    }
}
