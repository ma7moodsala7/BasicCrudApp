using System.Collections.Generic;
using System.Threading.Tasks;
using LegalAdvice.Domain.Entities;

namespace LegalAdvice.Application.Contracts.Persistence
{
    public interface IClientRepository : IAsyncRepository<Client>
    {
        Task<List<Client>> GetClientsWithRequestsAsync();
    }
}
