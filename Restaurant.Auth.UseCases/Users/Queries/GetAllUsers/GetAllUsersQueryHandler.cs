using AutoMapper;
using MediatR;
using Restaurant.Auth.Contracts;
using Restaurant.Auth.UseCases.Abstractions;
using System.Runtime.CompilerServices;

namespace Restaurant.Auth.UseCases.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IStreamRequestHandler<GetAllUsersQuery, UserDto>
    {
        private readonly IMainRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IMainRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async IAsyncEnumerable<UserDto> Handle(GetAllUsersQuery request, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            await foreach (var user in _repository.Users.GetAll())
            {
                yield return _mapper.Map<UserDto>(user);
            }
        }
    }
}
