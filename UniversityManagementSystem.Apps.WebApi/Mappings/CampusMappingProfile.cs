using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.ViewModels;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Apps.WebApi.Mappings
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