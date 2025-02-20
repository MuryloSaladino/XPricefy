using FluentValidation;

namespace Server.Application.Features.Users.Create;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.Username).MinimumLength(3);
        RuleFor(u => u.Password).MinimumLength(8);
    }
}