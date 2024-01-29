using AutoMapper;
using MediatR;
using Restaurant.Auth.Core;
using Restaurant.Auth.UseCases.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Auth.UseCases.Users.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Guid>
    {
        private readonly IMainRepository _repository;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IMainRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _repository.Users.Add(user);

            await _repository.SaveChanges();

            return user.Id;
        }
    }
}
