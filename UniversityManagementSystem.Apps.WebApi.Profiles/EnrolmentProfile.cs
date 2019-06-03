using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.Models;

namespace UniversityManagementSystem.Apps.WebApi.Profiles
{
    public class EnrolmentProfile : Profile
    {
        public EnrolmentProfile()
        {
            CreateMap<Enrolment, Data.Entities.Enrolment>();

            CreateMap<Data.Entities.Enrolment, Enrolment>();
        }
    }
}