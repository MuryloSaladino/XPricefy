using FluentValidation;

namespace Server.Application.Features.Users.Find;

public class FindUserValidator : AbstractValidator<FindUserRequest>
{
    public FindUserValidator()
    {
        RuleFor(r => r.Id).Must(id => Guid.TryParse(id, out _));
    }
}