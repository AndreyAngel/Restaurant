﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Restaurant.Auth.Core;
using Restaurant.Auth.DataAccess.DTO.Auth;
using Restaurant.Auth.UseCases.Abstractions;

namespace Restaurant.Auth.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UmContext _context;
        private readonly IMapper _mapper;

        public UserRepository(UmContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Add(User user)
        {
            var userDto = _mapper.Map<UserDto>(user);
            await _context.Users.AddAsync(userDto);

            return userDto.Id;
        }

        public IAsyncEnumerable<User> GetAll()
        {
            return _context.Users.AsQueryable()
                .ProjectTo<User>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .AsAsyncEnumerable();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.AsQueryable()/*.Include(user => user.Roles)*/
                .ProjectTo<User>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetById(Guid id)
        {
            var domain = await _context.Users.Include(user => user.Roles)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            var userDto = _mapper.Map<User>(domain);
            return userDto;
        }

        public async Task<List<User>> GetByName(string name)
        {
            return await _context.Users.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ProjectTo<User>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
