using System;
using System.Collections.Generic;
using LegalAdvice.Domain.Common;

namespace LegalAdvice.Domain.Entities
{
    public class Lawyer : AuditableEntity
    {
        public Guid LawyerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
