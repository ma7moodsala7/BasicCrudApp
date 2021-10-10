using System;
using LegalAdvice.Domain.Common;

namespace LegalAdvice.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public Guid CommentId { get; set; }

        public string Details { get; set; }


    }
}