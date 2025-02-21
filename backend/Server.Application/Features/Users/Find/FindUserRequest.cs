using MediatR;

namespace Server.Application.Features.Users.Find;

public sealed record FindUserRequest(
    string Id
) : IRequest<FindUserResponse>;