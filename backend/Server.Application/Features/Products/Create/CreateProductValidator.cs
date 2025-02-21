using FluentValidation;

namespace Server.Application.Features.Products.Create;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name).MinimumLength(3).MaximumLength(25);
        RuleFor(p => p.AnnualPrice).GreaterThan(0);
        RuleFor(p => p.ClientsNumber).GreaterThan(0);
        RuleFor(p => p.YearsToPay).GreaterThan(0).LessThan(6);
    }
}