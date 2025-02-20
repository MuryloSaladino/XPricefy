using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Auth.Login;

namespace Server.API.Controllers;

[ApiController]
[Route("/auth")]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<LoginResponse>> Login(
        LoginRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}