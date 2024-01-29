using AutoMapper;
using MediatR;
using Restaurant.Auth.Contracts;
using Restaurant.Auth.UseCases.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Auth.UseCases.Users.Queries.GetUserByName
{
    public class GetUsersByNameQueryHandler : IRequestHandler<GetUsersByNameQuery, List<UserDto>>
    {
        private readonly IMainRepository _repository;
        private readonly IMapper _mapper;

        public GetUsersByNameQueryHandler(IMainRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetUsersByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Users.GetByName(request.Name);
            return _mapper.Map<List<UserDto>>(result);
        }
    }
}
