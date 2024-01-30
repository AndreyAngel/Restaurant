using Restaurant.Auth.Core.Enums;

namespace Restaurant.Auth.Core
{
    public class Role
    {
        public Guid Id { get; set; }

        public RoleName Name { get; set; }
    }
}
