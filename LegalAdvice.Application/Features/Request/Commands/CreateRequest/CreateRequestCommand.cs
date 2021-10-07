﻿using MediatR;
using System;

namespace LegalAdvice.Application.Features.Request.Commands.CreateRequest
{
    public class CreateRequestCommand : IRequest<CreateRequestCommandResponse>
    {
        public Guid RequestId { get; set; }

        public string Description { get; set; }

        public Guid ClientId { get; set; }
    }
}
