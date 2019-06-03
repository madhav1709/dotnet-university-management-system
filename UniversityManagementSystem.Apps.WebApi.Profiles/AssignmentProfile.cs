using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.Models;

namespace UniversityManagementSystem.Apps.WebApi.Profiles
{
    public class AssignmentProfile : Profile
    {
        public AssignmentProfile()
        {
            CreateMap<Assignment, Data.Entities.Assignment>();

            CreateMap<Data.Entities.Assignment, Assignment>();
        }
    }
}