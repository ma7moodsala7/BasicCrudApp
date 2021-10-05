using LegalAdvice.Domain.Entities;

namespace LegalAdvice.Application.Contracts.Persistence
{
    public interface IClientRepository : IAsyncRepository<Client>
    {
    }
}
