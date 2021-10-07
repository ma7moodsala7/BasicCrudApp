using System;

namespace LegalAdvice.Application.Features.Request.Queries.GetPageRequests
{
    public class RequestsForPageDto
    {
        public Guid RequestId { get; set; }

        public string Description { get; set; }
    }
}
