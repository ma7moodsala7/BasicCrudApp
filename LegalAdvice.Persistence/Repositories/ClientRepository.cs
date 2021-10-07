using System.Collections.Generic;
using System.Threading.Tasks;
using LegalAdvice.Application.Contracts.Persistence;
using LegalAdvice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LegalAdvice.Persistence.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Client>> GetClientsWithRequestsAsync()
        {
            var query = DbContext.Clients.Include(c => c.Requests);

            List<Client> allClientsWithRequests = await query.ToListAsync().ConfigureAwait(false);

            return allClientsWithRequests;
        }
    }
}
