using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegalAdvice.Application.Features.Lawyer.Commands.CreateLawyer;
using MediatR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LegalAdvice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawyersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LawyersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        #region Queries

        // GET: api/<LawyersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LawyersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        #endregion

        #region Commands

        // POST api/<LawyersController>
        [HttpPost]
        public async Task<IActionResult> AddLawyer([FromBody] CreateLawyerCommand createLawyerCommand)
        {
            var response = await _mediator.Send(createLawyerCommand).ConfigureAwait(false);
            return StatusCode(201, response);
        }

        // PUT api/<LawyersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LawyersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #endregion
    }
}
