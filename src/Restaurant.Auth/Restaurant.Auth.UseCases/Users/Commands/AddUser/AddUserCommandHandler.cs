using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Restaurant.Auth.Core;
using Restaurant.Auth.Core.Helpers;
using Restaurant.Auth.UseCases.Abstractions;

namespace Restaurant.Auth.UseCases.Users.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Guid>
    {
        private readonly IMainRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IMainRepository repository, IConfiguration configuration, IMapper mapper)
        {
            _repository = repository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user.Password = PasswordHelper.Encrypt(_configuration, request.Model.Password);
            await _repository.Users.Add(user);

            await _repository.SaveChanges();

            return user.Id;
        }
    }
}
