using AutoMapper;
using MediatR;
using Watchdog.Backend.Application.Contracts.Persistence;
using Watchdog.Backend.Application.Exceptions;
using Watchdog.Backend.Domain.Entities;

namespace Watchdog.Backend.Application.Contracts.Features.Customers.Commands.RegisterCustomer;

public class RegisterCustomerCommandHandler (ICustomerRepository customerRepository, IMapper mapper)
    : IRequestHandler<RegisterCustomerCommand, Guid>
{
    public async Task<Guid> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        var newCustomer = mapper.Map<Customer>(request);
        
        var validator = new RegisterCustomerCommandValidator(customerRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }

        await customerRepository.AddAsync(newCustomer);
        
        return newCustomer.CustomerId;
    }
}