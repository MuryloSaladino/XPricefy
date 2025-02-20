using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Users.Create;

namespace Server.API.Controllers;

[ApiController]
[Route("/users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> CreateUser(
        CreateUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created("/users", response);
    }
}