using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.ViewModels;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Apps.WebApi.Mappings
{
    public class HallMappingProfile : Profile
    {
        public HallMappingProfile()
        {
            CreateMap<HallViewModel, Hall>();

            CreateMap<Hall, HallViewModel>();
        }
    }
}