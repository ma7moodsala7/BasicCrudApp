using System;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestWithComments
{
    public class RequestCommentDto
    {
        public string Details { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}