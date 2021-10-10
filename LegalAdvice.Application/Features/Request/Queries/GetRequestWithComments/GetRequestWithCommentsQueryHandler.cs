using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LegalAdvice.Application.Contracts.Persistence;
using MediatR;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestWithComments
{
    public class GetRequestWithCommentsQueryHandler : IRequestHandler<GetRequestWithCommentsQuery, RequestWithCommentsVm>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public GetRequestWithCommentsQueryHandler(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public async Task<RequestWithCommentsVm> Handle(GetRequestWithCommentsQuery request, CancellationToken cancellationToken)
        {
            var requestWithComments = await _requestRepository.GetRequestWithCommentsAsync(request.Id).ConfigureAwait(false);
            var vm = _mapper.Map<RequestWithCommentsVm>(requestWithComments);
            return vm;
        }
    }
}
