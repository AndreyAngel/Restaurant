using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Auth.UseCases.Auth.Commands.Registration
{
    public class RegistrationCommand : IRequest
    {
        public string Login { get; }

        public string Password { get; }

        public string ConfirmPassword { get; }

        public RegistrationCommand(string login, string password, string confirmPassword)
        {
            Login = login;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
