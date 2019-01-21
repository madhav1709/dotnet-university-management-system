using AutoMapper;
using UniversityManagementSystem.Membership.Data.Entities;
using UniversityManagementSystem.Membership.WebApi.ViewModels;

namespace UniversityManagementSystem.Membership.WebApi.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserViewModel, ApplicationUser>();

            CreateMap<ApplicationUser, UserViewModel>();
        }
    }
}