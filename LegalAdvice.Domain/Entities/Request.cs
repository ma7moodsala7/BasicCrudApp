using LegalAdvice.Domain.Common;
using System;
using System.Collections.Generic;
using LegalAdvice.Domain.Enums;

namespace LegalAdvice.Domain.Entities
{
    public class Request : AuditableEntity
    {
        public Guid RequestId { get; set; }

        public string Subject { get; set; }

        public string Details { get; set; }

        public RequestType Type { get; set; }

        public RequestStandard Standard { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Guid ClientId { get; set; }

        public Client Client { get; set; }

        public Guid? LawyerId { get; set; }

        public Lawyer Lawyer { get; set; }
    }
}
