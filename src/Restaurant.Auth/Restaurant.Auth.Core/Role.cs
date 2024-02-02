using Restaurant.Auth.Core.Enums;

namespace Restaurant.Auth.Core
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<User?> Users { get; set; }

        public Role(string name, List<User?>? users = null) : 
            this(Guid.NewGuid(), name, users) 
        { }

        public Role(Guid id, string name, List<User?>? users = null)
        {
            Id = id;
            Name = name;
            Users = users ?? new();
        }
    }
}
