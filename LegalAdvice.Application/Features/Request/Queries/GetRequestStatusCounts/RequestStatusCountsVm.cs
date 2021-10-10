using System.Collections.Generic;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestStatusCounts
{
    public class RequestStatusCountsVm
    {
        public RequestStatusCountsVm()
        {
            StatusCountsDtos = new List<RequestStatusCountsDto>();
        }
        public List<RequestStatusCountsDto> StatusCountsDtos { get; set; }
    }
}
