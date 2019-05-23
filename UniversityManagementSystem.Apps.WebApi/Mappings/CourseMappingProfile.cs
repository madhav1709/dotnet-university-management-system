using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.ViewModels;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Apps.WebApi.Mappings
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<CourseViewModel, Course>();

            CreateMap<Course, CourseViewModel>();
        }
    }
}