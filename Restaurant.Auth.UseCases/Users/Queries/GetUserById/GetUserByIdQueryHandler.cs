using AutoMapper;
using MediatR;
using Restaurant.Auth.Contracts;
using Restaurant.Auth.UseCases.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Auth.UseCases.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsDto>
    {
        private readonly IMainRepository _repository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IMainRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDetailsDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.Users.GetById(request.Id);
            var userDto = _mapper.Map<UserDetailsDto>(user);

            return userDto;
        }
    }
}
