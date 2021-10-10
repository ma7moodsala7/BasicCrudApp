using System;
using MediatR;

namespace LegalAdvice.Application.Features.Request.Commands.DeleteRequest
{
    public class DeleteRequestCommand : IRequest
    {
        public Guid RequestId { get; set; }
    }
}
