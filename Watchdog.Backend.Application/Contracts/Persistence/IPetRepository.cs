using Watchdog.Backend.Domain.Entities;

namespace Watchdog.Backend.Application.Contracts.Persistence;

public interface IPetRepository : IAsyncRepository<Pet>
{
    
}