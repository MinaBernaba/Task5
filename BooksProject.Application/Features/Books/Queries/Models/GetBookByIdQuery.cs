using BooksProject.Application.Features.Books.Queries.Responses;
using BooksProject.Application.ResponseBase;
using MediatR;

namespace BooksProject.Application.Features.Books.Queries.Models
{
    public class GetBookByIdQuery : IRequest<Response<BookMainInfoResponse>>
    {
        public int BookId { get; set; }
    }
}