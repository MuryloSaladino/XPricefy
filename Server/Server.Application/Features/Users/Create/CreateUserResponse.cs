namespace Server.Application.Features.Users.Create;

public sealed record CreateUserResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Username
);