using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.API.Middlewares.Authenticate;
using Server.Application.Features.Users.Create;
using Server.Application.Features.Users.Find;

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

    [HttpGet]
    [Route("{id}")]
    [Authenticate]
    public async Task<ActionResult<FindUserResponse>> FindUser(
        [FromRoute] string id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindUserRequest(id), cancellationToken);
        return Ok(response);
    }
}