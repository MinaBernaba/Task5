using BooksProject.api.Base;
using BooksProject.Application.Features.Authorization.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AuthorizationController(IMediator _mediator) : AppControllerBase
    {
        [HttpPost("SetRolesToUser")]
        public async Task<IActionResult> SetRolesToUser(SetRolesToUserCommand command)
            => NewResult(await _mediator.Send(command));

    }
}
