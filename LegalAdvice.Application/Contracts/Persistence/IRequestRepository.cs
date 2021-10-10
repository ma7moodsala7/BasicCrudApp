using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LegalAdvice.Application.Features.Request.Queries.GetRequestStatusCounts;
using LegalAdvice.Domain.Entities;

namespace LegalAdvice.Application.Contracts.Persistence
{
    public interface IRequestRepository : IAsyncRepository<Request>
    {
        Task<Request> GetRequestDetailsAsync(Guid id);
        Task<List<Request>> GetRequestsListAsync(int? page, int? size);
        Task<RequestStatusCountsVm> GetRequestStatusCountsAsync();
    }
}
