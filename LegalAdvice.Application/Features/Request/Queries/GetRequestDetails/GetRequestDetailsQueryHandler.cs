﻿using AutoMapper;
using LegalAdvice.Application.Contracts.Persistence;
using LegalAdvice.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestDetails
{
    public class GetRequestDetailsQueryHandler : IRequestHandler<GetRequestDetailsQuery, RequestDetailsVm>
    {
        private readonly IAsyncRepository<Domain.Entities.Request> _requestRepository;
        private readonly IAsyncRepository<Client> _ClientRepository;
        private readonly IMapper _mapper;

        public GetRequestDetailsQueryHandler(
            IMapper mapper, 
            IAsyncRepository<Domain.Entities.Request> requestRepository, 
            IAsyncRepository<Client> clientRepository)
        {
            _mapper = mapper;
            _requestRepository = requestRepository;
            _ClientRepository = clientRepository;
        }

        public async Task<RequestDetailsVm> Handle(GetRequestDetailsQuery request, CancellationToken cancellationToken)
        {
            var requestById = await _requestRepository.GetByIdAsync(request.Id);
            var requestDetailsVm = _mapper.Map<RequestDetailsVm>(requestById);

            var client = await _ClientRepository.GetByIdAsync(requestById.ClientId);

            requestDetailsVm.Client = _mapper.Map<ClientDto>(client);

            return requestDetailsVm;
        }
    }
}