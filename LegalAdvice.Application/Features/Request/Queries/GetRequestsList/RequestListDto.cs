using System;
using LegalAdvice.Domain.Enums;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestsList
{
    public class RequestListDto
    {
        public Guid RequestId { get; set; }

        public string Subject { get; set; }

        public string Details { get; set; }

        public RequestStatus Status { get; set; }

        public RequestType Type { get; set; }

        public RequestStandard Standard { get; set; }

        public RequestListClientDto Client { get; set; }

        public RequestListLawyerDto Lawyer { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}