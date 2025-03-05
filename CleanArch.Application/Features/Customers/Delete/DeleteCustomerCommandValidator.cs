using FluentValidation;

namespace CleanArch.Application.Features.Customers.Delete;

public sealed class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(p => p.id).NotEmpty().WithMessage("Id cannot be empty");
    }
}