using AutoMapper;
using MediatR;
using Watchdog.Backend.Application.Contracts.Persistence;

namespace Watchdog.Backend.Application.Features.Customers.Queries.GetCustomerDetail;

public class GetCustomerDetailQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    : IRequestHandler<GetCustomerDetailQuery, GetCustomerDetailQueryResponse>
{
    public async Task<GetCustomerDetailQueryResponse> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(request.CustomerId);
        
        if (customer == null)
        {
            return new GetCustomerDetailQueryResponse
            {
                Success = false,
                Message = $"Customer with ID {request.CustomerId} not found."
            };
        }

        return new GetCustomerDetailQueryResponse
        {
            Success = true,
            Message = "Customer detail retrieved successfully.",
            Customer = mapper.Map<CustomerDetailDto>(customer)
        };
    }
}