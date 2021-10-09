
using System;
using System.Collections.Generic;

namespace LegalAdvice.Domain.Entities
{
    public class Client
    {
        public Guid ClientId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}
