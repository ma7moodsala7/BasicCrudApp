using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalAdvice.Application.Contracts.Persistence;
using LegalAdvice.Application.Features.Request.Queries.GetRequestStatusCounts;
using LegalAdvice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LegalAdvice.Persistence.Repositories
{
    public class RequestRepository : BaseRepository<Request>, IRequestRepository
    {
        public RequestRepository(AppDbContext dbContext) : base(dbContext)
        {
        }


        public Task<Request> GetRequestDetailsAsync(Guid id)
        {
            return DbContext.Requests
                .Include(r => r.Comments)
                .Include(r => r.Client)
                .Include(r => r.Lawyer)
                .FirstOrDefaultAsync(r => r.RequestId == id);
        }
        

        public Task<Request> GetRequestWithCommentsAsync(Guid id)
        {
            return DbContext.Requests
                .Include(r => r.Comments)
                .FirstOrDefaultAsync(r => r.RequestId == id);
        }


        public async Task<List<Request>> GetRequestsListAsync(int? page, int? size)
        {
            if (page != null)
            {
                if (size != null)
                {
                    return await (DbContext.Requests
                            .Include(r => r.Client)
                            .Include(r => r.Lawyer)
                            .Skip(((int)page - 1) * (int)size)
                            .Take((int)size)
                            .ToListAsync()
                        ).ConfigureAwait(false);
                }
            }

            return await (DbContext.Requests
                .Include(r => r.Client)
                .Include(r => r.Lawyer)
                .ToListAsync()).ConfigureAwait(false);
        }

        public async Task<RequestStatusCountsVm> GetRequestStatusCountsAsync()
        {
            var queryable = await (DbContext.Requests.GroupBy(r => r.Status)
                .Select(g => new{ StatusKey = g.Key, RequestsCount = g.Count()}).ToListAsync()).ConfigureAwait(false);


            var requestsStatisticsVm = new RequestStatusCountsVm();

            foreach (var item in queryable)
            {
                requestsStatisticsVm.StatusCountsDtos.Add(new RequestStatusCountsDto
                {
                    StatusKey = (int)item.StatusKey,
                    StatusName = item.StatusKey.ToString(),
                    RequestsCount = item.RequestsCount
                });
            }

            return requestsStatisticsVm;
        }
    }
}
