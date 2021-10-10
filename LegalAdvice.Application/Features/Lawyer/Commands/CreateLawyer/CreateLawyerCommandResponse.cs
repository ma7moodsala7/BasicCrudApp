using System;
using LegalAdvice.Application.Responses;

namespace LegalAdvice.Application.Features.Lawyer.Commands.CreateLawyer
{
    public class CreateLawyerCommandResponse : BaseResponse
    {
        public Guid LawyerId { get; set; }
    }
}
