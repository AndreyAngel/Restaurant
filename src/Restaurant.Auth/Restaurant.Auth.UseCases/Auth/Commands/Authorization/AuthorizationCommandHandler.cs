using MediatR;
using Microsoft.Extensions.Configuration;
using Restaurant.Auth.Core.Helpers;
using Restaurant.Auth.UseCases.Abstractions;
using System.Security.Claims;

namespace Restaurant.Auth.UseCases.Auth.Commands.Authorization
{
    public class AuthorizationCommandHandler : IRequestHandler<AuthorizationCommand, string?>
    {
        private readonly IMainRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthorizationCommandHandler(IMainRepository repository, IConfiguration configuration) 
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<string?> Handle(AuthorizationCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.Users.GetByEmail(request.Email);

            if (user == null)
            {
                return null;
            }

            if (!PasswordHelper.Verify(_configuration, request.Password, user.Password))
            {
                return null;
            }

            string token = GenerateAccessToken(_configuration, user.Id, user.Email);
            return token;
        }

        private static string GenerateAccessToken(IConfiguration configuration, Guid userId, string email)
        {
            return JwtTokenHelper.GenerateTokenForUser(
                configuration,
                new List<Claim>()
                {
                    new Claim("Id", userId.ToString()),
                    new Claim("Email", email)
                });
        }
    }
}
