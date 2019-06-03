using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.Models;

namespace UniversityManagementSystem.Apps.WebApi.Profiles
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<School, Data.Entities.School>();

            CreateMap<Data.Entities.School, School>();
        }
    }
}