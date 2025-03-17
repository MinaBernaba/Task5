using BooksProject.Application.Features.Authentication.Responses;
using BooksProject.Data.Identity;

namespace BooksProject.Application.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        Task<JwtAuthResponse> LoginUser(User user);
        Task<JwtAuthResponse?> RenewTokensAsync(string refreshToken);
        Task<bool> RevokeRefreshTokenAsync(string refreshToken);
    }
}
