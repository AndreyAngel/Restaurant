using Restaurant.Auth.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Auth.UseCases.Abstractions
{
    public interface IUserRepository
    {
        IAsyncEnumerable<User> GetAll();

        Task<User?> GetById(Guid id);

        Task<List<User>> GetByName(string name);

        Task<Guid> Add(User user);
    }
}
