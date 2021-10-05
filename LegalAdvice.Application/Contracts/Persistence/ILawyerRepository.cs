using LegalAdvice.Domain.Entities;

namespace LegalAdvice.Application.Contracts.Persistence
{
    public interface ILawyerRepository : IAsyncRepository<Lawyer>
    {
    }
}
