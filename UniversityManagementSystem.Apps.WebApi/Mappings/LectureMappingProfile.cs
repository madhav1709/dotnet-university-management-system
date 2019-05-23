using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.ViewModels;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Apps.WebApi.Mappings
{
    public class LectureMappingProfile : Profile
    {
        public LectureMappingProfile()
        {
            CreateMap<LectureViewModel, Lecture>();

            CreateMap<Lecture, LectureViewModel>();
        }
    }
}