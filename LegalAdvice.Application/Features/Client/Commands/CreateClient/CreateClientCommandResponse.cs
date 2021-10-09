using System;
using LegalAdvice.Application.Responses;

namespace LegalAdvice.Application.Features.Client.Commands.CreateClient
{
    public class CreateClientCommandResponse : BaseResponse
    {
        public Guid ClientId { get; set; }
    }
}
