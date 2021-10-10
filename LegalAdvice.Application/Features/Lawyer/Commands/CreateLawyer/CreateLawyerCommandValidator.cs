using FluentValidation;

namespace LegalAdvice.Application.Features.Lawyer.Commands.CreateLawyer
{
    public class CreateLawyerCommandValidator :AbstractValidator<CreateLawyerCommand>
    {
        public CreateLawyerCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}
