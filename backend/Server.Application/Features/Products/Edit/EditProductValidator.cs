using FluentValidation;

namespace Server.Application.Features.Products.Edit;

public class EditProductValidator : AbstractValidator<EditProductRequest>
{
    public EditProductValidator()
    {
        RuleFor(p => p.Id).Must(id => Guid.TryParse(id, out _));
        RuleFor(p => p.Name).MinimumLength(3).MaximumLength(25);
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.ClientsNumber).GreaterThan(0);
        RuleFor(p => p.YearsToPay).GreaterThan(0).LessThan(6);
    }
}