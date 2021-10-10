using AutoMapper;
using LegalAdvice.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestDetails
{
    public class GetRequestDetailsQueryHandler : IRequestHandler<GetRequestDetailsQuery, RequestDetailsVm>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public GetRequestDetailsQueryHandler(IMapper mapper,IRequestRepository requestRepository)
        {
            _mapper = mapper;
            _requestRepository = requestRepository;
        }

        public async Task<RequestDetailsVm> Handle(GetRequestDetailsQuery request, CancellationToken cancellationToken)
        {
            //var requestById = await _requestRepository.GetByIdAsync(request.Id).ConfigureAwait(false);
            var requestDetails = await _requestRepository.GetRequestDetailsAsync(request.Id).ConfigureAwait(false);

            return _mapper.Map<RequestDetailsVm>(requestDetails);
        }
    }
}
