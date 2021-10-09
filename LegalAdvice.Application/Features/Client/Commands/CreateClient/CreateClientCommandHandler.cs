using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LegalAdvice.Application.Contracts.Persistence;
using MediatR;

namespace LegalAdvice.Application.Features.Client.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CreateClientCommandResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<CreateClientCommandResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateClientCommandResponse();

            var validator = new CreateClientCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                    response.ValidationErrors.Add(error.ErrorMessage);
            }

            if (response.Success)
            {
                var newClient = _mapper.Map<Domain.Entities.Client>(request);
                newClient = await _clientRepository.AddAsync(newClient).ConfigureAwait(false);
                response.ClientId = newClient.ClientId;
            }

            return response;
        }
    }
}
