using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LegalAdvice.Application.Contracts.Persistence;
using LegalAdvice.Application.Exceptions;
using MediatR;

namespace LegalAdvice.Application.Features.Lawyer.Commands.CreateLawyer
{
    public class CreateLawyerCommandHandler : IRequestHandler<CreateLawyerCommand, CreateLawyerCommandResponse>
    {
        private readonly ILawyerRepository _lawyerRepository;
        private readonly IMapper _mapper;

        public CreateLawyerCommandHandler(ILawyerRepository lawyerRepository, IMapper mapper)
        {
            _lawyerRepository = lawyerRepository;
            _mapper = mapper;
        }

        public async Task<CreateLawyerCommandResponse> Handle(CreateLawyerCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateLawyerCommandResponse();

            var validator = new CreateLawyerCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var newLawyer = _mapper.Map<Domain.Entities.Lawyer>(request);
                
            //TODO: Update Created By property
            newLawyer = await _lawyerRepository.AddAsync(newLawyer).ConfigureAwait(false);
            response.LawyerId = newLawyer.LawyerId;

            return response;
        }
    }
}
