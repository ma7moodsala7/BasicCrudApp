using System;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestsList
{
    public class RequestLawyerDto
    {
        public Guid LawyerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
    }
}