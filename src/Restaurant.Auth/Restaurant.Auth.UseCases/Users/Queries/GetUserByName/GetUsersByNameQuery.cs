using MediatR;
using Restaurant.Auth.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Auth.UseCases.Users.Queries.GetUserByName
{
    public class GetUsersByNameQuery : IRequest<List<UserDto>>
    {
        public string Name { get; }
        public GetUsersByNameQuery(string name)
        {
            Name = name;
        }
    }
}
