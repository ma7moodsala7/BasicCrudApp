using System.Threading;
using System.Threading.Tasks;
using LegalAdvice.Application.Contracts.Persistence;
using LegalAdvice.Application.Exceptions;
using MediatR;

namespace LegalAdvice.Application.Features.Request.Commands.UpdateRequestStatus
{
    public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand>
    {
        private readonly IRequestRepository _requestRepository;

        public UpdateRequestCommandHandler(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<Unit> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            var requestToUpdate = await _requestRepository.GetByIdAsync(request.RequestId)
                .ConfigureAwait(false);


            if (requestToUpdate == null)
                throw new NotFoundException(nameof(Domain.Entities.Request), request.RequestId);
            

            var validator = new UpdateRequestCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);

            //TODO: Make it a function to initialize the base response with the validation error
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);


            requestToUpdate.Status = request.Status;
            await _requestRepository.UpdateAsync(requestToUpdate).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
