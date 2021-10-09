using System;
using LegalAdvice.Application.Responses;

namespace LegalAdvice.Application.Features.Request.Commands.CreateRequest
{
    public class CreateRequestCommandResponse : BaseResponse
    {
        public Guid RequestId { get; set; }
    }
}
