using MediatR;
using Restaurant.Auth.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Auth.UseCases.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDetailsDto>
    {
        public Guid Id { get; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
