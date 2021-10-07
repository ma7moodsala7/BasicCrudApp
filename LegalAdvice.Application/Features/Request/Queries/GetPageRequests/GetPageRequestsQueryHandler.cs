using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LegalAdvice.Application.Contracts.Persistence;
using MediatR;

namespace LegalAdvice.Application.Features.Request.Queries.GetPageRequests
{
    public class GetPageRequestsQueryHandler : IRequestHandler<GetPageRequestsQuery, PageRequestsVm>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public GetPageRequestsQueryHandler(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public async Task<PageRequestsVm> Handle(GetPageRequestsQuery request, CancellationToken cancellationToken)
        {
            var requests = await _requestRepository.GetPageRequestsAsync(request.Page, request.Size).ConfigureAwait(false);
            var requestsForPageDtos = _mapper.Map<List<RequestsForPageDto>>(requests);

            int count= await _requestRepository.GetTotalCountForRequestsAsync().ConfigureAwait(false);

            return new PageRequestsVm()
            {
                Count = count,
                RequestsForPage = requestsForPageDtos,
                Page = request.Page,
                Size = request.Size
            };
        }
    }
}
