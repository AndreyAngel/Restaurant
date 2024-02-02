using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Auth.Core
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public DateTime RegistrationDT { get; set; }

        public string Password {  get; set; }

        public bool IsActive { get; set; }

        public List<Role?> Roles { get; set; }

        public User(string email, string name, string password, List<Role?>? roles = null) :
            this(Guid.NewGuid(), email, name, DateTime.UtcNow, password, true, roles)
        { }

        public User(Guid id, string email, string name, DateTime registrationDT, string password, bool isActive, List<Role?>? roles = null) 
        { 
            Id = id;
            Email = email;
            Name = name;
            RegistrationDT = registrationDT;
            Password = password;
            IsActive = isActive;
            Roles = roles ?? new();
        }
    }
}
