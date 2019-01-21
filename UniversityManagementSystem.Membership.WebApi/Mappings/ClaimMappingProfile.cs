using System.Security.Claims;
using AutoMapper;
using UniversityManagementSystem.Membership.WebApi.ViewModels;

namespace UniversityManagementSystem.Membership.WebApi.Mappings
{
    public class ClaimMappingProfile : Profile
    {
        public ClaimMappingProfile()
        {
            CreateMap<ClaimViewModel, Claim>();

            CreateMap<Claim, ClaimViewModel>();
        }
    }
}