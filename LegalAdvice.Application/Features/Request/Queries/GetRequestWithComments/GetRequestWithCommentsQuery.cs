using System;
using MediatR;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestWithComments
{
    public class GetRequestWithCommentsQuery : IRequest<RequestWithCommentsVm>
    {
        public Guid Id { get; set; }

    }
}
