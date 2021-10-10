using System.Collections.Generic;
using AutoMapper;
using LegalAdvice.Application.Contracts.Persistence;
using LegalAdvice.Domain.Entities;
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
            Domain.Entities.Request requestDetails = await _requestRepository.GetRequestDetailsAsync(request.Id).ConfigureAwait(false);

            var requestDetailsVm = _mapper.Map<RequestDetailsVm>(requestDetails);

            requestDetailsVm.Client = _mapper.Map<ClientDto>(requestDetails.Client);
            requestDetailsVm.Lawyer = _mapper.Map<LawyerDto>(requestDetails.Lawyer);
            requestDetailsVm.Comments = _mapper.Map<List<CommentDetailsDto>>(requestDetails.Comments);

            return requestDetailsVm;
        }
    }
}
