using System;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestDetails
{
    public class RequestDetailsVm
    {
        public Guid RequestId { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public ClientDto Client { get; set; }
    }
}
