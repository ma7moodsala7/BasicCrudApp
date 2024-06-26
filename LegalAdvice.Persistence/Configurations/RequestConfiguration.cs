﻿using LegalAdvice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LegalAdvice.Persistence.Configurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.Property(e => e.Subject)
                .IsRequired();

            builder.Property(e => e.Details)
                .IsRequired();

        }
    }
}
