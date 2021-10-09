using System;
using LegalAdvice.Domain.Common;

namespace LegalAdvice.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Details { get; set; }


    }
}