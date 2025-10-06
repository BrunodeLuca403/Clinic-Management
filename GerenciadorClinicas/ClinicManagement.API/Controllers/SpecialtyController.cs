using ClinicManagement.API.Context;
using ClinicManagement.Application.Commands.Service.DeleteService;
using ClinicManagement.Application.Commands.Speciality.CreateSpeciality;
using ClinicManagement.Application.Common;
using ClinicManagement.Application.Query.Service.ListService;
using ClinicManagement.Application.Query.Speciality.DetailsSpeciality;
using ClinicManagement.Application.Query.Speciality.ListSpeciality;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ClinicManagement.API.Controllers
{
    [ApiController]
    [Route("v1/api/Specialty")]
    public class SpecialtyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SpecialtyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/list-specialtys")]
        public async Task<IActionResult> ListSpecialtys(ListSpecialityQuery query)
        {
            var specialtys = await _mediator.DispatchAsync<ListSpecialityQuery, ResultViewModel<List<ListSpecialityQueryHandler>>>(query);

            if (specialtys == null)
                return NotFound();

            return Ok(specialtys);
        }

        [HttpGet("/specialty-{id}")]
        public async Task<IActionResult> GetByIdSpecialty(DetailsSpecialityQuery query)
        {
            var specialty = await _mediator.DispatchAsync<DetailsSpecialityQuery, ResultViewModel<DetailsSpecialityQueryHandler>>(query);

            if (specialty == null)
                return NotFound();

            return Ok(specialty);
        }

        [HttpPost("/create-specialty")]
        public async Task<IActionResult> CreateSpecialty(CreateSpecialityCommand command)
        {
            var create = await _mediator.DispatchAsync<CreateSpecialityCommand, ResultViewModel<CreateSpecialityCommandHandler>>(command);

            if (create == null)
                return BadRequest();

            return Ok(create);
        }

        [HttpDelete("/delete-specialty-{id}")]
        public async Task<IActionResult> DeleteSpecialty(DeleteServiceCommand command)
        {
            var Sepeciality = await _mediator.DispatchAsync<DeleteServiceCommand, ResultViewModel<DeleteServiceCommandHandler>>(command);

            if (Sepeciality == null)
                return NotFound();

            return Ok(Sepeciality);
        }
    }
}
