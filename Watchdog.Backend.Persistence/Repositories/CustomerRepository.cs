using Microsoft.EntityFrameworkCore;
using Watchdog.Backend.Application.Contracts.Persistence;
using Watchdog.Backend.Domain.Entities;

namespace Watchdog.Backend.Persistence.Repositories;

public class CustomerRepository(AppDbContext dbContext) : BaseRepository<Customer>(dbContext), ICustomerRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<bool> IsCustomerEmailUnique(string email)
    {
        return !(await _dbContext.Customers.AnyAsync(c => c.Email == email));
    }
}