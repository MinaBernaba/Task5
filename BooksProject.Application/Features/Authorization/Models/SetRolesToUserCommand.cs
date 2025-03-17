using BooksProject.Application.ResponseBase;
using MediatR;

namespace BooksProject.Application.Features.Authorization.Models
{
    public class SetRolesToUserCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public string[] Roles { get; set; } = null!;
    }
}
