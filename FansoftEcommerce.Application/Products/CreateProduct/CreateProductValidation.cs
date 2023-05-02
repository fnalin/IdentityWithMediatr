using FluentValidation;

namespace FansoftEcommerce.Application.Products.CreateProduct;

public class CreateProductValidation : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .MinimumLength(10);

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0.1M);

        RuleFor(x => x.Sku)
            .NotEmpty()
            .Length(15);
    }
}