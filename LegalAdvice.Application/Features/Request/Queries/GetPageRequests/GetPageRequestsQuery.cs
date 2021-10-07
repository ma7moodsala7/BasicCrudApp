using MediatR;

namespace LegalAdvice.Application.Features.Request.Queries.GetPageRequests
{
    public class GetPageRequestsQuery : IRequest<PageRequestsVm>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
