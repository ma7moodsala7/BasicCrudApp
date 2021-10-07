using LegalAdvice.Application.Contracts.Persistence;
using LegalAdvice.Domain.Entities;

namespace LegalAdvice.Persistence.Repositories
{
    public class RequestRepository : BaseRepository<Request>, IRequestRepository
    {
        public RequestRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
