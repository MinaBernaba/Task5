using BooksProject.Application.Features.Authentication.Responses;
using BooksProject.Application.ResponseBase;
using MediatR;

namespace BooksProject.Application.Features.Authentication.Models
{
    public class LoginUserCommand : IRequest<Response<JwtAuthResponse>>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
