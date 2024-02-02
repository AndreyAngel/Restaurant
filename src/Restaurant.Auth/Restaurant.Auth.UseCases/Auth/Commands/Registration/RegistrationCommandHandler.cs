using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Restaurant.Auth.Core.Helpers;
using Restaurant.Auth.Core;
using Restaurant.Auth.UseCases.Abstractions;

namespace Restaurant.Auth.UseCases.Auth.Commands.Registration
{
    internal class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, Guid?>
    {
        private readonly IMainRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public RegistrationCommandHandler(IMainRepository repository, IConfiguration configuration, IMapper mapper) 
        {
            _repository = repository;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<Guid?> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            if (request.Password != request.ConfirmPassword)
            {
                return null;
            }

            user.Password = PasswordHelper.Encrypt(_configuration, request.Password);

            await _repository.Users.Add(user);
            await _repository.SaveChanges();

            return user.Id;
        }
    }
}
