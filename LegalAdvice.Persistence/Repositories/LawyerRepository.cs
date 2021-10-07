using LegalAdvice.Application.Contracts.Persistence;
using LegalAdvice.Domain.Entities;

namespace LegalAdvice.Persistence.Repositories
{
    public class LawyerRepository : BaseRepository<Lawyer>, ILawyerRepository
    {
        public LawyerRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
