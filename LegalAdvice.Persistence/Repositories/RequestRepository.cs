using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalAdvice.Application.Contracts.Persistence;
using LegalAdvice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LegalAdvice.Persistence.Repositories
{
    public class RequestRepository : BaseRepository<Request>, IRequestRepository
    {
        public RequestRepository(AppDbContext dbContext) : base(dbContext)
        {
        }


        public Task<List<Request>> GetPageRequestsAsync(int page, int size)
        {
            return DbContext.Requests.Skip((page - 1) * size).Take(size).ToListAsync();
        }

        public Task<int> GetTotalCountForRequestsAsync()
        {
            return DbContext.Requests.CountAsync();
        }

        public Task<Request> GetRequestDetailsAsync(Guid id)
        {
            return DbContext.Requests
                    .Include(r => r.Comments)
                    .Include(r => r.Client)
                    .Include(r => r.Lawyer)
                    .FirstOrDefaultAsync(r => r.RequestId == id);
        }

        public async Task<Request> GetRequestWithCommentsAsync(Guid id)
        {
            return await DbContext.Requests
                .Include(r => r.Comments)
                .FirstOrDefaultAsync(r => r.RequestId == id);
        }
    }
}
