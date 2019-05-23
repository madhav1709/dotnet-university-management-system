using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Apps.WebApi.ViewModels;
using UniversityManagementSystem.Data.Entities;
using UniversityManagementSystem.Services;

namespace UniversityManagementSystem.Apps.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize]
    public class LibrariesController : ControllerBase<Library, LibraryViewModel>
    {
        public LibrariesController(ILibraryService libraryService, IMapper mapper) : base(libraryService)
        {
            LibraryService = libraryService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private ILibraryService LibraryService { get; }

        #region /Libraries

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<LibraryViewModel>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{libraryId}", Name = "GetLibraryByLibraryId")]
        public override async Task<ActionResult<LibraryViewModel>> GetAsync(int libraryId)
        {
            return await base.GetAsync(libraryId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] LibraryViewModel libraryViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var library = Mapper.Map<Library>(libraryViewModel);

            await LibraryService.AddAsync(library);

            return CreatedAtRoute(
                "GetLibraryByLibraryId",
                new {libraryId = library.Id},
                Mapper.Map<LibraryViewModel>(library)
            );
        }

        [HttpPut("{libraryId}")]
        public override async Task<ActionResult> PutAsync(int libraryId, [FromBody] LibraryViewModel libraryViewModel)
        {
            if (libraryId != libraryViewModel.Id) return BadRequest();

            return await base.PutAsync(libraryId, libraryViewModel);
        }

        [HttpDelete("{libraryId}")]
        public override async Task<ActionResult> DeleteAsync(int libraryId)
        {
            return await base.DeleteAsync(libraryId);
        }

        #endregion
    }
}