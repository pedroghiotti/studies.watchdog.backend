using AutoMapper;
using MediatR;
using Watchdog.Backend.Application.Contracts.Infrastructure;
using Watchdog.Backend.Application.Contracts.Persistence;
using Watchdog.Backend.Application.Exceptions;
using Watchdog.Backend.Application.Features.Customers.Queries.GetCustomerDetail;
using Watchdog.Backend.Application.Models.Mail;
using Watchdog.Backend.Domain.Entities;

namespace Watchdog.Backend.Application.Features.Customers.Commands.RegisterCustomer;

public class RegisterCustomerCommandHandler (ICustomerRepository customerRepository, IMapper mapper, IEmailService emailService)
    : IRequestHandler<RegisterCustomerCommand, RegisterCustomerCommandResponse>
{
    public async Task<RegisterCustomerCommandResponse> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        var newCustomer = mapper.Map<Customer>(request);

        var validator = new RegisterCustomerCommandValidator(customerRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return new RegisterCustomerCommandResponse
            {
                Success = false,
                Message = "Customer registration failed.",
                ValidationErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
            };
        }

        await customerRepository.AddAsync(newCustomer);
        
        await SendCustomerRegisteredWelcomeEmail(request);

        return new RegisterCustomerCommandResponse
        {
            Success = true,
            Message = "Customer registered successfully.",
            Customer = mapper.Map<CustomerDetailDto>(newCustomer)
        };
    }

    private async Task SendCustomerRegisteredWelcomeEmail(RegisterCustomerCommand request)
    {
        var email = new Email
        {
            To = request.Email,
            Subject = "Welcome to Watchdog",
            Body = $"Hello {request.Name},\n\nThank you for registering with Watchdog!"
        };

        try
        {
            await emailService.SendEmailAsync(email);
        }
        catch (Exception) { /* ignored */}
    }
}