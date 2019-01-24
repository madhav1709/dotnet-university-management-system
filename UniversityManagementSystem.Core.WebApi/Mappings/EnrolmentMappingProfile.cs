using AutoMapper;
using UniversityManagementSystem.Core.Data.Entities;
using UniversityManagementSystem.Core.WebApi.ViewModels;

namespace UniversityManagementSystem.Core.WebApi.Mappings
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