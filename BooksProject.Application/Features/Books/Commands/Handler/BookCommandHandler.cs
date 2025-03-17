using AutoMapper;
using BooksProject.Application.Features.Books.Commands.Models;
using BooksProject.Application.ResponseBase;
using BooksProject.Application.ServiceInterfaces;
using BooksProject.Data.Entities;
using MediatR;

namespace BooksProject.Application.Features.Books.Commands.Handler
{
    public class BookCommandHandler(IBookService _bookService, IMapper _mapper) : ResponseHandler,
        IRequestHandler<AddBookCommand, Response<string>>,
        IRequestHandler<UpdateBookCommand, Response<string>>,
        IRequestHandler<DeleteBookCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);

            if (!await _bookService.AddBookAsync(book))
                return BadRequest<string>("Failed to add book");


            return Created<string>($"Book with ID: {book.BookId} added successfully");

        }

        public async Task<Response<string>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);

            if (!await _bookService.UpdateBookAsync(book))
                return BadRequest<string>($"Failed to update book with ID: {book.BookId}");

            return Updated<string>($"Book with ID: {book.BookId} updated successfully");

        }

        public async Task<Response<string>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            if (!await _bookService.IsExistAsync(request.BookId))
                return NotFound<string>($"Book with ID: {request.BookId} not found");

            if (!await _bookService.DeleteBookAsync(request.BookId))
                return BadRequest<string>($"Failed to delete book with ID: {request.BookId}");

            return Deleted<string>($"Book with ID: {request.BookId} deleted successfully");

        }
    }
}
