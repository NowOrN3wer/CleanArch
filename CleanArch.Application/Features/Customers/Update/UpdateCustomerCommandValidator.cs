using CleanArch.Application.Features.Customers.Update;
using FluentValidation;

namespace CleanArch.Application.Features.Customers.Update;

public sealed class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(p => p.id).NotEmpty().WithMessage("Id cannot be empty");
        RuleFor(p => p.taxnumber).NotEmpty().WithMessage("Tax number is required").MinimumLength(10)
            .WithMessage("Tax number minimum 10 char").MaximumLength(11).WithMessage("Tax number maximum 11 char");
    }
}