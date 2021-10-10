using System.Collections.Generic;
using LegalAdvice.Domain.Enums;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestWithComments
{
    public class RequestWithCommentsVm
    {

        public string Subject { get; set; }

        public string Details { get; set; }

        public RequestStatus Status { get; set; }

        public RequestType Type { get; set; }

        public RequestStandard Standard { get; set; }

        public List<RequestCommentDto> Comments { get; set; }
    }
}
