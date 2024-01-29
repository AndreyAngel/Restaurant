using AutoMapper;
using Restaurant.Auth.Contracts;
using Restaurant.Auth.Core;
using Restaurant.Auth.UseCases.Users.Commands.AddUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Auth.UseCases.Config
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AddUserCommand, User>()
                .ConstructUsing(x => new User(
                    x.Model.Email,
                    x.Model.Name,
                    x.Model.Password,
                    null));

            CreateMap<User, UserDto>();

            CreateMap<User, UserDetailsDto>()
                .ConstructUsing(x => new UserDetailsDto(
                    x.Id,
                    x.Email,
                    x.Name,
                    x.RegistrationDT,
                    x.IsActive));
        }
    }
}
