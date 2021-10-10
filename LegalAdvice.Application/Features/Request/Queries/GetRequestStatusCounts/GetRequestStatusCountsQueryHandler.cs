using System.Threading;
using System.Threading.Tasks;
using LegalAdvice.Application.Contracts.Persistence;
using MediatR;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestStatusCounts
{
    public class GetRequestStatusCountsQueryHandler : IRequestHandler<GetRequestStatusCountsQuery, RequestStatusCountsVm>
    {
        private readonly IRequestRepository _requestRepository;

        public GetRequestStatusCountsQueryHandler(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<RequestStatusCountsVm> Handle(GetRequestStatusCountsQuery request, CancellationToken cancellationToken)
        {
            var requestStatusCountsVm = await _requestRepository.GetRequestStatusCountsAsync().ConfigureAwait(false);
            return requestStatusCountsVm;
        }
    }
}
