using System.Threading;
using System.Threading.Tasks;
using LegalAdvice.Application.Contracts.Persistence;
using LegalAdvice.Application.Exceptions;
using MediatR;

namespace LegalAdvice.Application.Features.Request.Commands.DeleteRequest
{
    public class DeleteRequestCommandHandler : IRequestHandler<DeleteRequestCommand>
    {
        private readonly IRequestRepository _requestRepository;

        public DeleteRequestCommandHandler(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<Unit> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
        {
            var requestToDelete = await _requestRepository.GetByIdAsync(request.RequestId)
                .ConfigureAwait(false);

            if (requestToDelete == null)
                throw new NotFoundException(nameof(Domain.Entities.Request), request.RequestId);

            await _requestRepository.DeleteAsync(requestToDelete).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
