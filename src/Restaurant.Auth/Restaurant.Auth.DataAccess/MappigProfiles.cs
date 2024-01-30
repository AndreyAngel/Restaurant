using AutoMapper;
using Restaurant.Auth.Core;
using Restaurant.Auth.DataAccess.DTO.Auth;

namespace Restaurant.Auth.DataAccess
{
    public class MappigProfiles : Profile
    {
        public MappigProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}
