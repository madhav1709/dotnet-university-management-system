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
    public class BooksController : ControllerBase<Book, BookViewModel>
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
        public override async Task<ActionResult<IEnumerable<BookViewModel>>> GetAsync()
        {
            return await base.GetAsync();
        }

        [HttpGet("{bookId}", Name = "GetBookByBookId")]
        public override async Task<ActionResult<BookViewModel>> GetAsync(int bookId)
        {
            return await base.GetAsync(bookId);
        }

        [HttpPost]
        public override async Task<ActionResult> PostAsync([FromBody] BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var book = Mapper.Map<Book>(bookViewModel);

            await BookService.AddAsync(book);

            return CreatedAtRoute(
                "GetBookByBookId",
                new {bookId = book.Id},
                Mapper.Map<BookViewModel>(book)
            );
        }

        [HttpPut("{bookId}")]
        public override async Task<ActionResult> PutAsync(int bookId, [FromBody] BookViewModel bookViewModel)
        {
            if (bookId != bookViewModel.Id) return BadRequest();

            return await base.PutAsync(bookId, bookViewModel);
        }

        [HttpDelete("{bookId}")]
        public override async Task<ActionResult> DeleteAsync(int bookId)
        {
            return await base.DeleteAsync(bookId);
        }

        #endregion
    }
}