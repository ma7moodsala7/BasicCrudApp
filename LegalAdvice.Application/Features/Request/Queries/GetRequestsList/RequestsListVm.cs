using System.Collections.Generic;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestsList
{
    public class RequestsListVm
    {
        public int Count { get; set; }
        public List<RequestListDto> RequestsDtos { get; set; }
        public int? Page { get; set; }
        public int? Size { get; set; }
    }
}