using BooksProject.Application.ResponseBase;
using MediatR;

namespace BooksProject.Application.Features.Authentication.Models
{
    public class RevokeRefreshTokenCommand : IRequest<Response<string>>
    {
        public string RefreshToken { get; set; } = null!;
    }
}
