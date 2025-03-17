using BooksProject.Application.Features.Books.Queries.Responses;
using BooksProject.Application.ResponseBase;
using MediatR;

namespace BooksProject.Application.Features.Books.Queries.Models
{
    public class GetAllBooksQuery : IRequest<Response<List<BookMainInfoResponse>>>
    {
    }
}
