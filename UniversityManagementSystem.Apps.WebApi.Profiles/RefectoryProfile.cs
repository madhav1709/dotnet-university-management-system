using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.Models;

namespace UniversityManagementSystem.Apps.WebApi.Profiles
{
    public class RefectoryProfile : Profile
    {
        public RefectoryProfile()
        {
            CreateMap<Refectory, Data.Entities.Refectory>();

            CreateMap<Data.Entities.Refectory, Refectory>();
        }
    }
}