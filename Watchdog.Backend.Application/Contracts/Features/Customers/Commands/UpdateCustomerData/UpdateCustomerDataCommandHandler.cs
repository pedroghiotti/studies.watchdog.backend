using AutoMapper;
using MediatR;
using Watchdog.Backend.Application.Contracts.Persistence;

namespace Watchdog.Backend.Application.Contracts.Features.Customers.Commands.UpdateCustomerData;

public class UpdateCustomerDataCommandHandler (ICustomerRepository customerRepository, IMapper mapper)
    : IRequestHandler<UpdateCustomerDataCommand>
{
    public async Task Handle(UpdateCustomerDataCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(request.CustomerId);
        
        mapper.Map(request, customer);
        
        await customerRepository.UpdateAsync(customer);
    }
}