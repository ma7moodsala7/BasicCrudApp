﻿using System.Collections.Generic;
using AutoMapper;
using LegalAdvice.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestsList
{
    // The message handler class that is going to be triggered when this message "GetRequestsListQuery" is being sent
    // And that is going to contain the actual business logic
    // that handler will be triggered by MediatR

    /// <summary>
    /// Handle GetEventsListQuery message
    /// returning the list of EventListVMs
    /// </summary>
    public class GetRequestsListQueryHandler : IRequestHandler<GetRequestsListQuery, List<RequestListVm>>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;


        public GetRequestsListQueryHandler(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }


        // when the message "GetEventsListQuery" is received, this method will be called
        public async Task<List<RequestListVm>> Handle(GetRequestsListQuery request, CancellationToken cancellationToken)
        {

            var allRequests = await _requestRepository.GetRequestsListAsync().ConfigureAwait(false);
            //var allRequests = (await _requestRepository.ListAllAsync().ConfigureAwait(false)).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<RequestListVm>>(allRequests);
        }
    }
}
