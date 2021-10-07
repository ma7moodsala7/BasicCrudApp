using LegalAdvice.Domain.Common;
using System;

namespace LegalAdvice.Domain.Entities
{
    public class Request : AuditableEntity
    {
        public Guid RequestId { get; set; }

        public string Description { get; set; }

        public Guid ClientId { get; set; }

        public Client Client { get; set; }

        public Guid LawyerId { get; set; }

        public Lawyer Lawyer { get; set; }
    }
}
