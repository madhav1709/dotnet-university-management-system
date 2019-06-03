using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Data.Entities;
using UniversityManagementSystem.Services;

namespace UniversityManagementSystem.Apps.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize]
    public class LibrariesController : ControllerBase<Library, Models.Library>
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
        public override async Task<ActionResult<IEnumerable<Models.Library>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{libraryId}", Name = "GetLibraryByLibraryId")]
        public override async Task<ActionResult<Models.Library>> GetAsync(int libraryId)
        {
            return await base.GetAsync(libraryId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Library model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Library>(model);

            await LibraryService.AddAsync(entity);

            return CreatedAtRoute(
                "GetLibraryByLibraryId",
                new {libraryId = entity.Id},
                Mapper.Map<Models.Library>(entity)
            );
        }

        [HttpPut("{libraryId}")]
        public override async Task<ActionResult> PutAsync(int libraryId, [FromBody] Models.Library model)
        {
            if (libraryId != model.Id) return BadRequest();

            return await base.PutAsync(libraryId, model);
        }

        [HttpDelete("{libraryId}")]
        public override async Task<ActionResult> DeleteAsync(int libraryId)
        {
            return await base.DeleteAsync(libraryId);
        }

        #endregion
    }
}