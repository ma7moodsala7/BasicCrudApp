using FluentValidation;

namespace LegalAdvice.Application.Features.Client.Commands.CreateClient
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
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
