using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Auth.UseCases.Auth.Commands.Authorization
{
    public class AuthorizationCommand : IRequest
    {
        public string Login { get; }

        public string Password { get; }

        public AuthorizationCommand(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
