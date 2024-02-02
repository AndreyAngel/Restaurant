namespace Restaurant.Auth.DataAccess.DTO.Auth
{
    public class RoleDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<UserDto>? Users { get; } = new ();
    }
}
