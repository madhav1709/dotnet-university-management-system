using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.ViewModels;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Apps.WebApi.Mappings
{
    public class ResultMappingProfile : Profile
    {
        public ResultMappingProfile()
        {
            CreateMap<ResultViewModel, Result>();

            CreateMap<Result, ResultViewModel>();
        }
    }
}