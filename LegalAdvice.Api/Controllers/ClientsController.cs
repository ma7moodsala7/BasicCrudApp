using System.Threading.Tasks;
using AutoMapper;
using LegalAdvice.Application.Features.Client.Commands.CreateClient;
using LegalAdvice.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LegalAdvice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClientCommand createClientCommand)
        {
            var response = await _mediator.Send(createClientCommand).ConfigureAwait(false);
            return StatusCode(201, response);
        }
    }
}
