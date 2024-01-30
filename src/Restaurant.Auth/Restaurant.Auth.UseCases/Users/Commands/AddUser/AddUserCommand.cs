using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Auth.UseCases.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<Guid>
    {
        public UserModel Model { get; }

        public AddUserCommand(UserModel model)
        {
            Model = model;
        }
    }
}
