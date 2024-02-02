using AutoMapper;
using Restaurant.Auth.Contracts;
using Restaurant.Auth.Core;
using Restaurant.Auth.UseCases.Auth.Commands.Registration;
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

            CreateMap<RegistrationCommand, User>()
                .ConstructUsing(x => new User(
                    x.Email,
                    x.Name,
                    x.Password,
                    null));

            CreateMap<User, UserDto>();

            CreateMap<User, UserDetailsDto>()
                .ConstructUsing(x => new UserDetailsDto(
                    x.Id,
                    x.Email,
                    x.Name,
                    x.RegistrationDT,
                    x.IsActive,
                    x.Roles.ConvertAll(x => new RoleDto(x.Id, x.Name))));

            CreateMap<Role, RoleDto>()
                .ConstructUsing(x => new RoleDto(x.Id, x.Name));
        }
    }
}
