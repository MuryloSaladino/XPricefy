using MediatR;

namespace Server.Application.Features.Users.Create;

public sealed record CreateUserRequest(
    string Username,
    string Password
) : IRequest<CreateUserResponse>;