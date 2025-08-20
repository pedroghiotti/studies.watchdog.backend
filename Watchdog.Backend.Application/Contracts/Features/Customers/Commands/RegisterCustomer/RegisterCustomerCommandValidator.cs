using FluentValidation;
using Watchdog.Backend.Application.Contracts.Persistence;

namespace Watchdog.Backend.Application.Contracts.Features.Customers.Commands.RegisterCustomer;

public class RegisterCustomerCommandValidator : AbstractValidator<RegisterCustomerCommand>
{
    public RegisterCustomerCommandValidator(ICustomerRepository customerRepository)
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Customer name is required.")
            .MaximumLength(100).WithMessage("Customer name must not exceed 100 characters.");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters.")
            .MustAsync(async (email, cancellation) => await customerRepository.IsCustomerEmailUnique(email));

        RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Length(11).WithMessage("Phone number must be exactly 11 digits.");
    }
}