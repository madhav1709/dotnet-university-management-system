using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.Models;

namespace UniversityManagementSystem.Apps.WebApi.Profiles
{
    public class CampusProfile : Profile
    {
        public CampusProfile()
        {
            CreateMap<Campus, Data.Entities.Campus>();

            CreateMap<Data.Entities.Campus, Campus>();
        }
    }
}