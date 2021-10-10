using FluentValidation;
using LegalAdvice.Domain.Enums;

namespace LegalAdvice.Application.Features.Request.Commands.UpdateRequestStatus
{
    public class UpdateRequestStatusCommandValidator : AbstractValidator<UpdateRequestStatusCommand>
    {
        public UpdateRequestStatusCommandValidator()
        {
            RuleFor(p => p.RequestId)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.Status)
                .NotNull()
                .Must(r =>
                    r == RequestStatus.Approved ||
                    r == RequestStatus.Rejected ||
                    r == RequestStatus.Closed);
        }
    }
}
