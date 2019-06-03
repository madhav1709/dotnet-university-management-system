using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.Models;

namespace UniversityManagementSystem.Apps.WebApi.Profiles
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<Building, Data.Entities.Building>();

            CreateMap<Data.Entities.Building, Building>();
        }
    }
}