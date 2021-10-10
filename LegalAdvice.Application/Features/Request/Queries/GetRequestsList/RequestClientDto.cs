using System;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestsList
{
    public class RequestClientDto
    {
        public Guid ClientId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
    }
}