using AuthenticationAuthorization.Authentication;
using AuthenticationAuthorization.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationAuthorization.Generics
{
    public class AutoMapper: Profile
    {
        public AutoMapper() 
        {
            CreateMap<IdentityRole, RoleDto>();
            CreateMap<ApplicationUser, UserDto>();
        }
    }
}
