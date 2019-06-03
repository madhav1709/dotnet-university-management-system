using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.Models;

namespace UniversityManagementSystem.Apps.WebApi.Profiles
{
    public class RentalProfile : Profile
    {
        public RentalProfile()
        {
            CreateMap<Rental, Data.Entities.Rental>();

            CreateMap<Data.Entities.Rental, Rental>();
        }
    }
}