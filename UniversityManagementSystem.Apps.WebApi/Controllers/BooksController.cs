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
    public class BooksController : ControllerBase<Book, Models.Book>
    {
        public BooksController(IBookService bookService, IMapper mapper) : base(bookService)
        {
            BookService = bookService;
            Mapper = mapper;
        }

        protected override IMapper Mapper { get; }

        private IBookService BookService { get; }

        #region /Books

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Models.Book>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{bookId}", Name = "GetBookByBookId")]
        public override async Task<ActionResult<Models.Book>> GetAsync(int bookId)
        {
            return await base.GetAsync(bookId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] Models.Book model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var entity = Mapper.Map<Book>(model);

            await BookService.AddAsync(entity);

            return CreatedAtRoute(
                "GetBookByBookId",
                new {bookId = entity.Id},
                Mapper.Map<Models.Book>(entity)
            );
        }

        [HttpPut("{bookId}")]
        public override async Task<ActionResult> PutAsync(int bookId, [FromBody] Models.Book model)
        {
            if (bookId != model.Id) return BadRequest();

            return await base.PutAsync(bookId, model);
        }

        [HttpDelete("{bookId}")]
        public override async Task<ActionResult> DeleteAsync(int bookId)
        {
            return await base.DeleteAsync(bookId);
        }

        #endregion
    }
}