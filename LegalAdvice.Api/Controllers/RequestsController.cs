using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalAdvice.Application.Features.Request.Commands.CreateRequest;
using LegalAdvice.Application.Features.Request.Queries.GetRequestDetails;
using LegalAdvice.Application.Features.Request.Queries.GetRequestsList;
using MediatR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LegalAdvice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<RequestListVm>>> GetAllRequests()
        {
            var dtos = await _mediator.Send(new GetRequestsListQuery()).ConfigureAwait(false);
            return dtos;
        }

        // GET api/<RequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestDetailsVm>> GetRequestById(Guid id)
        {
            var getRequestDetailsQuery = new GetRequestDetailsQuery() { Id = id};
            var requestDetailsVm = await _mediator.Send(getRequestDetailsQuery).ConfigureAwait(false);
            return requestDetailsVm;
        }

        // POST api/<RequestsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRequestCommand createRequestCommand)
        {
            var response = await _mediator.Send(createRequestCommand).ConfigureAwait(false);
            return StatusCode(201, response);
        }

        // PUT api/<RequestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RequestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
