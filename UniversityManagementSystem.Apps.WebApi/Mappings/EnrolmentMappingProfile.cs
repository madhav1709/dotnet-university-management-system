using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.ViewModels;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Apps.WebApi.Mappings
{
    public class EnrolmentMappingProfile : Profile
    {
        public EnrolmentMappingProfile()
        {
            CreateMap<EnrolmentViewModel, Enrolment>();

            CreateMap<Enrolment, EnrolmentViewModel>();
        }
    }
}