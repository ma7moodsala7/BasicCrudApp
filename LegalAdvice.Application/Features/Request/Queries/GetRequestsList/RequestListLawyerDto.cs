using System;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestsList
{
    public class RequestListLawyerDto
    {
        public Guid LawyerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}