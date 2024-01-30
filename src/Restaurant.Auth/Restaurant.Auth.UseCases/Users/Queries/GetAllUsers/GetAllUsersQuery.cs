using MediatR;
using Restaurant.Auth.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Auth.UseCases.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IStreamRequest<UserDto> { }
}
