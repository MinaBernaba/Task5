using BooksProject.Application.ResponseBase;
using MediatR;

namespace BooksProject.Application.Features.Books.Commands.Models
{
    public class UpdateBookCommand : IRequest<Response<string>>
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
    }
}
