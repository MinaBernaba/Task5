using BooksProject.Application.ResponseBase;
using MediatR;

namespace BooksProject.Application.Features.Books.Commands.Models
{
    public class DeleteBookCommand : IRequest<Response<string>>
    {
        public int BookId { get; set; }
    }
}
