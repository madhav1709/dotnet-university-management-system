using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.Models;

namespace UniversityManagementSystem.Apps.WebApi.Profiles
{
    public class LectureProfile : Profile
    {
        public LectureProfile()
        {
            CreateMap<Lecture, Data.Entities.Lecture>();

            CreateMap<Data.Entities.Lecture, Lecture>();
        }
    }
}