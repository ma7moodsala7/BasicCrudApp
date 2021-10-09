using System;
using MediatR;

namespace LegalAdvice.Application.Features.Client.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<CreateClientCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
