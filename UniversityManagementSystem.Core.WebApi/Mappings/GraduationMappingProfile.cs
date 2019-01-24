using AutoMapper;
using UniversityManagementSystem.Core.Data.Entities;
using UniversityManagementSystem.Core.WebApi.ViewModels;

namespace UniversityManagementSystem.Core.WebApi.Mappings
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