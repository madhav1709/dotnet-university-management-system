using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.ViewModels;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Apps.WebApi.Mappings
{
    public class RunMappingProfile : Profile
    {
        public RunMappingProfile()
        {
            CreateMap<RunViewModel, Run>();

            CreateMap<Run, RunViewModel>();
        }
    }
}