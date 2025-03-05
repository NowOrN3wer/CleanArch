using FluentValidation;

namespace CleanArch.Application.Features.Customers.Add;

public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(p => p.taxnumber).NotEmpty().WithMessage("Tax number is required").MinimumLength(10)
            .WithMessage("Tax number minimum 10 char").MaximumLength(11).WithMessage("Tax number maximum 11 char");
    }
}