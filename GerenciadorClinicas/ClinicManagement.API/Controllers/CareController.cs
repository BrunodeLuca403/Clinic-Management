using ClinicManagement.Application.Commands.Care.CreateCare;
using ClinicManagement.Application.Commands.Care.DeleteCare;
using ClinicManagement.Application.Commands.Care.UpdateCare;
using ClinicManagement.Application.Common;
using ClinicManagement.Application.DTO.ViewModel.Care;
using ClinicManagement.Application.Query.Care.DetailsCare;
using ClinicManagement.Application.Query.Care.ListCare;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers
{
    [ApiController]
    [Route("v1/api/Care")]
    public class CareController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CareController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/list-cares")]
        public async Task<ActionResult<List<ListCareDto>>> ListCares([FromQuery]ListCareQuery command)
        {
            var cares = await _mediator.DispatchAsync<ListCareQuery, ResultViewModel<List<ListCareDto>>>(command);
            if (!cares.IsSuccess)
            {
                return BadRequest(cares.Error);
            }
            return Ok(cares);
        }

        [HttpGet("/details-cares")]
        public async Task<ActionResult<DetailsCareDto>> GetByIdCares([FromQuery] DetailsCareQuery command)
        {
            var cares = await _mediator.DispatchAsync<DetailsCareQuery, ResultViewModel<DetailsCareDto>>(command);
            if (!cares.IsSuccess)
            {
                return BadRequest(cares.Error);
            }
            return Ok(cares);
        }

        [HttpPost("/create-care")]
        public async Task<ActionResult> CreateCare([FromBody] CreateCareCommand command)
        {
            var create = await _mediator.DispatchAsync<CreateCareCommand, ResultViewModel<Guid>>(command);
            if (!create.IsSuccess)
            {
                return BadRequest(create.Error);
            }
            return Ok(create);

        }

        [HttpPut("/update-care")]
        public async Task<ActionResult> UpdateCare([FromBody] UpdateCareCommand command)
        {
            var delete = await _mediator.DispatchAsync<UpdateCareCommand, ResultViewModel<Guid>>(command);


            if (delete == null)
                return BadRequest();

            return Ok(delete);
        }

        [HttpDelete("/delete-care")]
        public async Task<ActionResult> DeleteCare([FromBody] DeleteCareCommand command)
        {
            var delete = await _mediator.DispatchAsync<DeleteCareCommand, ResultViewModel<Guid>>(command);
          
            if (!delete.IsSuccess)
                return BadRequest(delete.Error);

            return Ok(delete);
        }
    }
}
