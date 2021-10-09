using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace LegalAdvice.Application.Features.Request.Commands.UpdateRequest
{
    public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand>
    {
        public Task<Unit> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
