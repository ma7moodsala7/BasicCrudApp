﻿using System;

namespace LegalAdvice.Application.Features.Request.Queries.GetRequestDetails
{
    public class ClientDto
    {
        public Guid ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
