using AutoMapper;
using UniversityManagementSystem.Core.Data.Entities;
using UniversityManagementSystem.Core.WebApi.ViewModels;

namespace UniversityManagementSystem.Core.WebApi.Mappings
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