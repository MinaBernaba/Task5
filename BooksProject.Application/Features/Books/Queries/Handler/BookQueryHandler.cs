using BooksProject.Application.Features.Books.Queries.Models;
using BooksProject.Application.Features.Books.Queries.Responses;
using BooksProject.Application.ResponseBase;
using BooksProject.Application.ServiceInterfaces;
using MediatR;

namespace BooksProject.Application.Features.Books.Queries.Handler
{
    public class BookQueryHandler(IBookService _bookService) : ResponseHandler,
        IRequestHandler<GetAllBooksQuery, Response<List<BookMainInfoResponse>>>,
        IRequestHandler<GetBookByIdQuery, Response<BookMainInfoResponse>>
    {

        public async Task<Response<List<BookMainInfoResponse>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookService.GetAllBooksAsync();
            return Success(books);
        }

        public async Task<Response<BookMainInfoResponse>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            if (!await _bookService.IsExistAsync(request.BookId))
                return NotFound<BookMainInfoResponse>($"Book with ID: {request.BookId} not found");

            var book = await _bookService.GetBookByIdAsync(request.BookId);
            return Success(book);
        }
    }
}
