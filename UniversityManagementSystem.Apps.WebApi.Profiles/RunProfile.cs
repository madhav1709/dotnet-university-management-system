using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.Models;

namespace UniversityManagementSystem.Apps.WebApi.Profiles
{
    public class RunProfile : Profile
    {
        public RunProfile()
        {
            CreateMap<Run, Data.Entities.Run>();

            CreateMap<Data.Entities.Run, Run>();
        }
    }
}