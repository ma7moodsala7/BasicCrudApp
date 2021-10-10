using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LegalAdvice.Domain.Entities;

namespace LegalAdvice.Application.Contracts.Persistence
{
    public interface IRequestRepository : IAsyncRepository<Request>
    {

        Task<List<Request>> GetPageRequestsAsync(int page, int size);
        Task<int> GetTotalCountForRequestsAsync();
        Task<Request> GetRequestDetailsAsync(Guid id);
        Task<Request> GetRequestWithCommentsAsync(Guid id);
        Task<List<Request>> GetRequestsListAsync();
    }
}
