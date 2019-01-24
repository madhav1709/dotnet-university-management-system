using AutoMapper;
using UniversityManagementSystem.Core.Data.Entities;
using UniversityManagementSystem.Core.WebApi.ViewModels;

namespace UniversityManagementSystem.Core.WebApi.Mappings
{
    public class CampusMappingProfile : Profile
    {
        public CampusMappingProfile()
        {
            CreateMap<CampusViewModel, Campus>();

            CreateMap<Campus, CampusViewModel>();
        }
    }
}