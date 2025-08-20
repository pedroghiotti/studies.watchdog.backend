using AutoMapper;
using MediatR;
using Watchdog.Backend.Application.Contracts.Persistence;
using Watchdog.Backend.Domain.Entities;

namespace Watchdog.Backend.Application.Contracts.Features.Customers.Commands.RegisterCustomer;

public class RegisterCustomerCommandHandler (ICustomerRepository customerRepository, IMapper mapper)
    : IRequestHandler<RegisterCustomerCommand, Guid>
{
    public async Task<Guid> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        var newCustomer = mapper.Map<Customer>(request);

        await customerRepository.AddAsync(newCustomer);
        
        return newCustomer.CustomerId;
    }
}