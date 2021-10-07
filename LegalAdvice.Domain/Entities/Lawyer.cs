using System;
using System.Collections.Generic;
using LegalAdvice.Domain.Common;

namespace LegalAdvice.Domain.Entities
{
    public class Lawyer : AuditableEntity
    {
        public Guid LawyerId { get; set; }

        public string Name { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}
