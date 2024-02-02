using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Auth.Core;
using Restaurant.Auth.DataAccess.DTO.Auth;

namespace Restaurant.Auth.DataAccess
{
    public class MappigProfiles : Profile
    {
        public MappigProfiles()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.RegistrationDT, opt => opt.MapFrom(x => x.RegistrationDT))
                .ForMember(x => x.Password, opt => opt.MapFrom(x => x.Password))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(x => x.IsActive));

            CreateMap<UserDto, User>()
                .ConstructUsing(x => new User(
                    x.Id,
                    x.Email,
                    x.Name,
                    x.RegistrationDT,
                    x.Password,
                    x.IsActive,
                    x.Roles.Select(x => new Role(x.Id, x.Name, null)).ToList()));

            CreateMap<Role, RoleDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(opt => opt.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(opt => opt.Name));

            CreateMap<RoleDto, Role>()
                .ConstructUsing(x => new Role(
                    x.Id,
                    x.Name,
                    x.Users.Select(x => new User(x.Id, x.Email, x.Name, x.RegistrationDT, x.Password, x.IsActive, null)).ToList()));
        }
    }
}
