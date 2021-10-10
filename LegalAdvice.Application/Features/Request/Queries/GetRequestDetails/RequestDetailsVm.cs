using System;
using System.Collections.Generic;
using LegalAdvice.Domain.Entities;
using LegalAdvice.Domain.Enums;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestDetails
{
    public class RequestDetailsVm
    {
        public Guid RequestId { get; set; }

        public string Subject { get; set; }

        public string Details { get; set; }

        public RequestStatus Status { get; set; }

        public RequestType Type { get; set; }

        public RequestStandard Standard { get; set; }

        public RequestClientDto Client { get; set; }

        public RequestLawyerDto Lawyer { get; set; }

        public List<RequestCommentDto> Comments { get; set; }
    }
}
