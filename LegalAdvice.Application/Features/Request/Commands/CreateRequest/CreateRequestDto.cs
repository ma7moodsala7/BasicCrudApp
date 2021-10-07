using System;

namespace LegalAdvice.Application.Features.Request.Commands.CreateRequest
{
    public class CreateRequestDto
    {
        public Guid RequestId { get; set; }

        public string Description { get; set; }
    }
}