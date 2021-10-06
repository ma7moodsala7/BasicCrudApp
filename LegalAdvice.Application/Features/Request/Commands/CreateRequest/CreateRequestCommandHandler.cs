using AutoMapper;
using LegalAdvice.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LegalAdvice.Application.Features.Request.Commands.CreateRequest
{
    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, Guid>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;


        public CreateRequestCommandHandler(IRequestRepository requestRepository, IClientRepository clientRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {

            var newRequest = _mapper.Map<Domain.Entities.Request>(request);

            newRequest = await _requestRepository.AddAsync(newRequest);

            return newRequest.RequestId;
        }
    }
}
