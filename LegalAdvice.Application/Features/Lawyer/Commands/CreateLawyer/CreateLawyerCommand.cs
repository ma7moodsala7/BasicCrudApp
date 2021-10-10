using MediatR;

namespace LegalAdvice.Application.Features.Lawyer.Commands.CreateLawyer
{
    public class CreateLawyerCommand : IRequest<CreateLawyerCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
