using MediatR;

namespace Server.Application.Features.Auth.Login;

public sealed record LoginRequest(
    string Username,
    string Password
) : IRequest<LoginResponse>;