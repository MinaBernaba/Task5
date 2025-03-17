using BooksProject.Application.ResponseBase;
using MediatR;

namespace BooksProject.Application.Features.Books.Commands.Models
{
    public class AddBookCommand : IRequest<Response<string>>
    {
        public string Title { get; set; } = null!;
    }
}
