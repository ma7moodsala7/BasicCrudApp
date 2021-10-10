using AutoMapper;
using LegalAdvice.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using LegalAdvice.Application.Exceptions;
using LegalAdvice.Domain.Enums;

namespace LegalAdvice.Application.Features.Request.Commands.CreateRequest
{
    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, CreateRequestCommandResponse>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;


        public CreateRequestCommandHandler(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public async Task<CreateRequestCommandResponse> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateRequestCommandResponse();

            var validator = new CreateRequestCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var newRequest = _mapper.Map<Domain.Entities.Request>(request);

            newRequest.Status = RequestStatus.New;

            //TODO: Update the Auditable properties after adding authentication
            //newRequest.CreatedBy = 
                
            newRequest = await _requestRepository.AddAsync(newRequest).ConfigureAwait(false);
            response.RequestId = newRequest.RequestId;


            return response;
        }
    }
}
