
using System;
using System.Collections.Generic;

namespace LegalAdvice.Domain.Entities
{
    public class Client
    {
        public Guid ClientId { get; set; }

        public string Name { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}
