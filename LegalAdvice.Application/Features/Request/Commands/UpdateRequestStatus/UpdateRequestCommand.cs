using System;
using LegalAdvice.Domain.Enums;
using MediatR;

namespace LegalAdvice.Application.Features.Request.Commands.UpdateRequestStatus
{
    public class UpdateRequestCommand : IRequest<Unit>
    {
        public Guid RequestId { get; set; }

        public RequestStatus Status { get; set; }
    }
}
