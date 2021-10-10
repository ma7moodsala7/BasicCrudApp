using System;
using MediatR;

namespace LegalAdvice.Application.Features.Request.Commands.AssignRequest
{
    public class AssignRequestCommand : IRequest
    {
        public Guid RequestId { get; set; }

        public Guid LawyerId { get; set; }
    }
}
