using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.Models;

namespace UniversityManagementSystem.Apps.WebApi.Profiles
{
    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap<Result, Data.Entities.Result>();

            CreateMap<Data.Entities.Result, Result>();
        }
    }
}