using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LegalAdvice.Application.Features.Request.Commands.AssignRequest;
using LegalAdvice.Application.Features.Request.Commands.CreateRequest;
using LegalAdvice.Application.Features.Request.Commands.DeleteRequest;
using LegalAdvice.Application.Features.Request.Commands.UpdateRequestStatus;
using LegalAdvice.Application.Features.Request.Queries.GetPageRequests;
using LegalAdvice.Application.Features.Request.Queries.GetRequestDetails;
using LegalAdvice.Application.Features.Request.Queries.GetRequestsList;
using LegalAdvice.Application.Features.Request.Queries.GetRequestWithComments;
using LegalAdvice.Domain.Enums;
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

        #region Queries

        [HttpGet]
        public async Task<ActionResult<List<RequestListVm>>> GetAllRequests()
        {
            var dtos = await _mediator.Send(new GetRequestsListQuery()).ConfigureAwait(false);
            return dtos;
        }

        [HttpGet("{page}/{size}")]
        public async Task<ActionResult<PageRequestsVm>> GetPageRequests(int page, int size)
        {
            var getPageRequests = new GetPageRequestsQuery() {Page = page, Size = size};
            var dtos = await _mediator.Send(getPageRequests).ConfigureAwait(false);

            return Ok(dtos);
        }

        // GET api/<RequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestDetailsVm>> GetRequestById(Guid id)
        {
            var getRequestDetailsQuery = new GetRequestDetailsQuery() {Id = id};
            var requestDetailsVm = await _mediator.Send(getRequestDetailsQuery).ConfigureAwait(false);
            return requestDetailsVm;
        }

        /// Request History for the client
        [HttpGet("{id}/comments")]
        public async Task<ActionResult<RequestWithCommentsVm>> GetRequestWithComments(Guid id)
        {
            var getRequestWithCommentsQuery = new GetRequestWithCommentsQuery() { Id = id };
            var requestWithCommentsVm = await _mediator.Send(getRequestWithCommentsQuery).ConfigureAwait(false);
            return requestWithCommentsVm;
        }

        #endregion


        #region Commands

        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestCommand createRequestCommand)
        {
            var response = await _mediator.Send(createRequestCommand).ConfigureAwait(false);
            return StatusCode(201, response);
        }

        [HttpPost("{id}/{LawyerId}")]
        public async Task<IActionResult> UpdateRequestStatus(Guid id, Guid LawyerId)
        {
            var unit = await _mediator.Send(new AssignRequestCommand
            {
                RequestId = id,
                LawyerId = LawyerId
            }).ConfigureAwait(false);

            return NoContent();
        }

        [HttpPut("{id}/{statusId}")]
        public async Task<IActionResult> UpdateRequestStatus(Guid id, int statusId)
        {
            var unit = await _mediator.Send(new UpdateRequestCommand
            {
                RequestId = id, Status = (RequestStatus) statusId
            }).ConfigureAwait(false);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(Guid id)
        {
            var deleteRequestCommand = new DeleteRequestCommand() {RequestId = id};
            await _mediator.Send(deleteRequestCommand).ConfigureAwait(false);

            return NoContent();
        }
        #endregion
        
    }

}
