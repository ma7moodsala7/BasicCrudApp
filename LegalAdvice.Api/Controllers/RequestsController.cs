using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LegalAdvice.Application.Features.Request.Commands.AssignRequest;
using LegalAdvice.Application.Features.Request.Commands.CreateRequest;
using LegalAdvice.Application.Features.Request.Commands.DeleteRequest;
using LegalAdvice.Application.Features.Request.Commands.UpdateRequestStatus;
using LegalAdvice.Application.Features.Request.Queries.GetRequestDetails;
using LegalAdvice.Application.Features.Request.Queries.GetRequestsList;
using LegalAdvice.Application.Features.Request.Queries.GetRequestStatusCounts;
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

        #region OLd 2 endpoints "Get All Requests By Paging And Without it"

        //[HttpGet]
        //public async Task<ActionResult<List<RequestListVm>>> GetAllRequests()
        //{
        //    var dtos = await _mediator.Send(new GetRequestsListQuery()).ConfigureAwait(false);
        //    return dtos;
        //}

        //[HttpGet("{page}/{size}")]
        //public async Task<ActionResult<PageRequestsVm>> GetPageRequests(int page, int size)
        //{
        //    var getPageRequests = new GetPageRequestsQuery() {Page = page, Size = size};
        //    var dtos = await _mediator.Send(getPageRequests).ConfigureAwait(false);
        //    return Ok(dtos);
        //}

        #endregion

        // GET api/<RequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestDetailsVm>> GetRequestById(Guid id)
        {
            var getRequestDetailsQuery = new GetRequestDetailsQuery() { Id = id };
            var requestDetailsVm = await _mediator.Send(getRequestDetailsQuery).ConfigureAwait(false);
            return requestDetailsVm;
        }

        [HttpGet]
        public async Task<ActionResult<RequestsListVm>> GetAllRequests(int? page, int? size)
        {
            var requestsListQuery = new GetRequestsListQuery { Page = page, Size = size};
            var dtos = await _mediator.Send(requestsListQuery).ConfigureAwait(false);

            return Ok(dtos);
        }


        // For statistics 
        [HttpGet("dashboard")]
        public async Task<ActionResult<RequestStatusCountsVm>> GetRequestStatusCounts()
        {
            var requestStatusCountsVm = await _mediator.Send(new GetRequestStatusCountsQuery()).ConfigureAwait(false);
            return requestStatusCountsVm;
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
        public async Task<IActionResult> AssignRequestToLawyer(Guid id, Guid lawyerId)
        {
            await _mediator.Send(new AssignRequestCommand
            {
                RequestId = id,
                LawyerId = lawyerId
            }).ConfigureAwait(false);

            return NoContent();
        }

        [HttpPut("{id}/{statusId}")]
        public async Task<IActionResult> UpdateRequestStatus(Guid id, int statusId)
        {
            await _mediator.Send(new UpdateRequestStatusCommand
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
