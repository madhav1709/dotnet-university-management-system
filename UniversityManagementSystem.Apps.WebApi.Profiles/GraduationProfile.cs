using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.Models;

namespace UniversityManagementSystem.Apps.WebApi.Profiles
{
    public class GraduationProfile : Profile
    {
        public GraduationProfile()
        {
            CreateMap<Graduation, Data.Entities.Graduation>();

            CreateMap<Data.Entities.Graduation, Graduation>();
        }
    }
}