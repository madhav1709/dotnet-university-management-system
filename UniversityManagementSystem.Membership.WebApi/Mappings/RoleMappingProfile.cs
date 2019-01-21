using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UniversityManagementSystem.Membership.WebApi.ViewModels;

namespace UniversityManagementSystem.Membership.WebApi.Mappings
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<RoleViewModel, IdentityRole>();

            CreateMap<IdentityRole, RoleViewModel>();
        }
    }
}