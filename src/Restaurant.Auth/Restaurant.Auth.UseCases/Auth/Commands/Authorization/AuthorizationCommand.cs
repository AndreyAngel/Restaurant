using MediatR;

namespace Restaurant.Auth.UseCases.Auth.Commands.Authorization
{
    public class AuthorizationCommand : IRequest<string?>
    {
        public string Email { get; }

        public string Password { get; }

        public AuthorizationCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
