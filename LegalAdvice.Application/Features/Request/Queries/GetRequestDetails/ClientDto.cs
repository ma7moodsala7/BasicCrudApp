using System;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestDetails
{
    public class ClientDto
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
    }
}
