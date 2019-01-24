using AutoMapper;
using UniversityManagementSystem.Core.Data.Entities;
using UniversityManagementSystem.Core.WebApi.ViewModels;

namespace UniversityManagementSystem.Core.WebApi.Mappings
{
    public class ModuleMappingProfile : Profile
    {
        public ModuleMappingProfile()
        {
            CreateMap<ModuleViewModel, Module>();

            CreateMap<Module, ModuleViewModel>();
        }
    }
}