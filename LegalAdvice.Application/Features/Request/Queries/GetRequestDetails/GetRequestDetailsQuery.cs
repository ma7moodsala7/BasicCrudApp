using MediatR;
using System;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestDetails
{
    public class GetRequestDetailsQuery : IRequest<RequestDetailsVm>
    {
        /// detect which request detail do i need to fetch
        public Guid Id { get; set; }
    }
}
