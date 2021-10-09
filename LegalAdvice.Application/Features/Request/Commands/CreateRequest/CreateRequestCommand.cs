using MediatR;
using System;
using System.Collections.Generic;
using LegalAdvice.Domain.Entities;
using LegalAdvice.Domain.Enums;

namespace LegalAdvice.Application.Features.Request.Commands.CreateRequest
{
    public class CreateRequestCommand : IRequest<CreateRequestCommandResponse>
    {
        public string Subject { get; set; }

        public string Details { get; set; }

        public RequestType Type { get; set; }

        public RequestStandard Standard { get; set; }

        public List<CommentDto> Comments { get; set; }

        public Guid ClientId { get; set; }
    }
}
