using System.Threading;
using System.Threading.Tasks;
using LegalAdvice.Application.Contracts.Persistence;
using LegalAdvice.Application.Exceptions;
using LegalAdvice.Domain.Enums;
using MediatR;

namespace LegalAdvice.Application.Features.Request.Commands.AssignRequest
{
    public class AssignRequestCommandHandler : IRequestHandler<AssignRequestCommand>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly ILawyerRepository _lawyerRepository;

        public AssignRequestCommandHandler(IRequestRepository requestRepository, ILawyerRepository lawyerRepository)
        {
            _requestRepository = requestRepository;
            _lawyerRepository = lawyerRepository;
        }

        public async Task<Unit> Handle(AssignRequestCommand request, CancellationToken cancellationToken)
        {
            var requestToAssign = await _requestRepository.GetByIdAsync(request.RequestId).ConfigureAwait(false);
            if (requestToAssign == null)
                throw new NotFoundException(nameof(Domain.Entities.Request), request.RequestId);

            var lawyer = await _lawyerRepository.GetByIdAsync(request.LawyerId).ConfigureAwait(false);
            if (lawyer == null)
                throw new NotFoundException(nameof(Domain.Entities.Lawyer), request.LawyerId);


            requestToAssign.Lawyer = lawyer;
            requestToAssign.Status = RequestStatus.Assigned;
            await _requestRepository.UpdateAsync(requestToAssign).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
