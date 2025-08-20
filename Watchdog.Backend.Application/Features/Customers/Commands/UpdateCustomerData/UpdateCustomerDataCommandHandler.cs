using AutoMapper;
using MediatR;
using Watchdog.Backend.Application.Contracts.Persistence;
using Watchdog.Backend.Application.Exceptions;

namespace Watchdog.Backend.Application.Features.Customers.Commands.UpdateCustomerData;

public class UpdateCustomerDataCommandHandler (ICustomerRepository customerRepository, IMapper mapper)
    : IRequestHandler<UpdateCustomerDataCommand>
{
    public async Task Handle(UpdateCustomerDataCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(request.CustomerId);
        
        if (customer == null)
        {
            throw new NotFoundException("Customer", request.CustomerId);
        }
        
        mapper.Map(request, customer);
        
        await customerRepository.UpdateAsync(customer);
    }
}