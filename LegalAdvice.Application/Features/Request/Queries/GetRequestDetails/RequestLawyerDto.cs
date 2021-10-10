using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestDetails
{
    public class RequestLawyerDto
    {
        public Guid LawyerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
