using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.ViewModels;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Apps.WebApi.Mappings
{
    public class GraduationMappingProfile : Profile
    {
        public GraduationMappingProfile()
        {
            CreateMap<GraduationViewModel, Graduation>();

            CreateMap<Graduation, GraduationViewModel>();
        }
    }
}