using FluentValidation;

namespace Server.Application.Features.Products.Find;

public class FindProductValidator : AbstractValidator<FindProductRequest>
{
    public FindProductValidator()
    {
        RuleFor(r => r.Id).Must(id => Guid.TryParse(id, out _));
    }
}