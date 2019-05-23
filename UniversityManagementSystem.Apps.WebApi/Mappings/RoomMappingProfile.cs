using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.ViewModels;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Apps.WebApi.Mappings
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile()
        {
            CreateMap<RoomViewModel, Room>();

            CreateMap<Room, RoomViewModel>();
        }
    }
}