using System;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestsList
{
    public class RequestListVm
    {
        public Guid RequestId { get; set; }

        public string Description { get; set; }
    }
}
