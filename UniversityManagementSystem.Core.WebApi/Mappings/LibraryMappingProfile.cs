using AutoMapper;
using UniversityManagementSystem.Core.Data.Entities;
using UniversityManagementSystem.Core.WebApi.ViewModels;

namespace UniversityManagementSystem.Core.WebApi.Mappings
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