using System.Collections.Generic;

namespace LegalAdvice.Application.Features.Request.Queries.GetPageRequests
{
    public class PageRequestsVm
    {
        public int Count { get; set; }
        public ICollection<RequestsForPageDto> RequestsForPage { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
