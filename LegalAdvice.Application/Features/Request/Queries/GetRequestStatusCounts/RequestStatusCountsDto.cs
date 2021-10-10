namespace LegalAdvice.Application.Features.Request.Queries.GetRequestStatusCounts
{
    public class RequestStatusCountsDto
    {
        public int StatusKey { get; set; }

        public string StatusName { get; set; }

        public int RequestsCount { get; set; }
    }
}
