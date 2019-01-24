using AutoMapper;
using UniversityManagementSystem.Core.Data.Entities;
using UniversityManagementSystem.Core.WebApi.ViewModels;

namespace UniversityManagementSystem.Core.WebApi.Mappings
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