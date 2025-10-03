using FluentValidation;
using SimplesPDV.Communication.Request;

namespace SimplesPDV.Application.Services.Product.Create;

public class ProductValidator : AbstractValidator<RequestProductJson>
{
    public ProductValidator()
    {
        RuleFor(p =>  p.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(p=>p.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        RuleFor(p => p.Quantity)
            .GreaterThanOrEqualTo(1).WithMessage("Quantity must be at least 1")
            .LessThanOrEqualTo(9999).WithMessage("Quantity must be less than or equal to 9999");
    }
}