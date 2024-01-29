namespace Restaurant.Auth.DataAccess.DTO.Auth { 
    public class UserToRoleDto
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }
    }
}
