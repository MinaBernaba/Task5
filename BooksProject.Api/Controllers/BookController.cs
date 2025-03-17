using BooksProject.api.Base;
using BooksProject.Application.Features.Books.Commands.Models;
using BooksProject.Application.Features.Books.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController(IMediator _mediator) : AppControllerBase
    {


        [Authorize(Roles = "Admin,Editor,Viewer")]
        [HttpGet("GetAllBooksAsync")]
        public async Task<IActionResult> GetAllBooks() => NewResult(await _mediator.Send(new GetAllBooksQuery()));



        [Authorize(Roles = "Admin,Editor,Viewer")]
        [HttpGet("GetBookById/{id}")]
        public async Task<IActionResult> GetBookById(int id) => NewResult(await _mediator.Send(new GetBookByIdQuery() { BookId = id }));



        [Authorize(Roles = "Admin,Editor")]
        [HttpPost("AddNewBook/")]
        public async Task<IActionResult> AddNewBook(AddBookCommand addBook) => NewResult(await _mediator.Send(addBook));



        [Authorize(Roles = "Admin,Editor")]
        [HttpPut("UpdateBook/")]
        public async Task<IActionResult> UpdateBook(UpdateBookCommand updateBook) => NewResult(await _mediator.Send(updateBook));


        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id) => NewResult(await _mediator.Send(new DeleteBookCommand() { BookId = id }));

    }
}
