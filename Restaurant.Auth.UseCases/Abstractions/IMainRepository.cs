using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Auth.UseCases.Abstractions
{
    public interface IMainRepository
    {
        IUserRepository Users { get; }

        Task SaveChanges();
    }
}
