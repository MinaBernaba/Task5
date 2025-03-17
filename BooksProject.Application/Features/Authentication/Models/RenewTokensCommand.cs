using BooksProject.Application.Features.Authentication.Responses;
using BooksProject.Application.ResponseBase;
using MediatR;

namespace BooksProject.Application.Features.Authentication.Models
{
    public class RenewTokensCommand : IRequest<Response<JwtAuthResponse>>
    {
        public string RefreshToken { get; set; } = null!;
    }
}
