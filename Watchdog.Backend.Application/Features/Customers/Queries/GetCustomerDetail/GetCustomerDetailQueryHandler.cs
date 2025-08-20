using AutoMapper;
using MediatR;
using Watchdog.Backend.Application.Contracts.Persistence;

namespace Watchdog.Backend.Application.Features.Customers.Queries.GetCustomerDetail;

public class GetCustomerDetailQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    : IRequestHandler<GetCustomerDetailQuery, CustomerDetailDto>
{
    public Task<CustomerDetailDto> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
    {
        var customer = customerRepository.GetByIdAsync(request.CustomerId);
        
        if (customer == null)
        {
            throw new KeyNotFoundException($"Customer with ID {request.CustomerId} not found.");
        }

        return Task.FromResult(mapper.Map<CustomerDetailDto>(customer));
        
    }
}