using AutoMapper;
using UniversityManagementSystem.Apps.WebApi.ViewModels;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Apps.WebApi.Mappings
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile()
        {
            CreateMap<LibraryViewModel, Library>();

            CreateMap<Library, LibraryViewModel>();
        }
    }
}