using MediatR;

namespace Restaurant.Auth.UseCases.Auth.Commands.Registration
{
    public class RegistrationCommand : IRequest<Guid?>
    {
        public string Email { get; }

        public string Name { get; }

        public string Password { get;}

        public string ConfirmPassword { get; }


        public RegistrationCommand(string email, string name, string password, string confirmPassword)
        {
            Email = email;
            Name = name;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
