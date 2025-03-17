using BooksProject.Application.Features.Authorization.Models;
using BooksProject.Application.ResponseBase;
using BooksProject.Data.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BooksProject.Application.Features.Authorization.Handler
{
    public class AuthorizationCommandHandler(UserManager<User> _userManager) : ResponseHandler,
        IRequestHandler<SetRolesToUserCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(SetRolesToUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == request.UserId);

            var result = await _userManager.AddToRolesAsync(user, request.Roles);

            if (!result.Succeeded)
            {
                var errors = string.Join("\n", result.Errors.Select(e => e.Description));
                return BadRequest<string>(errors);
            }

            return Success($"Roles added successfully to the given user ID: {user.Id}.");
        }
    }
}
