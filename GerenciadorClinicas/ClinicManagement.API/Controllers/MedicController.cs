using ClinicManagement.API.Context;
using ClinicManagement.Application.Commands.Medic.RegisterMedic;
using ClinicManagement.Application.Commands.Medic.UpdateMedic;
using ClinicManagement.Application.Common;
using ClinicManagement.Application.Query.Medic.DetailsMedic;
using ClinicManagement.Application.Query.Medic.ListMedic;
using ClinicManagement.Core.Entitys;
using ClinicManagement.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ClinicManagement.API.Controllers
{
    [ApiController]
    [Route("v1/api/Medic")]
    public class MedicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/list-medics")]
        public async Task<IActionResult> ListMedics(ListMedicQuery query)
        {
            var medics = await _mediator.DispatchAsync<ListMedicQuery, List<ResultViewModel<ListMedicQueryHandler>>>(query);

            if (medics == null)
                return NotFound();

            return Ok(medics);
        }

        [HttpGet("/medic-{id}")] 
        public async Task<IActionResult> GetByIdMedic(DetailsMedicQuery query)
        {
            var medics = await _mediator.DispatchAsync<DetailsMedicQuery, List<ResultViewModel<DetailsMedicQuery>>>(query);


            if (medics == null)
                return NotFound();

            return Ok(medics);
        }

        [HttpPost("/create-medic")]
        public async Task<IActionResult> CreateMedic(RegisterMedicCommand  command)
        {
            var create = await _mediator.DispatchAsync<RegisterMedicCommand, ResultViewModel<Guid>>(command);
            if (!create.IsSuccess)
            {
                return BadRequest(create.Error);
            }
            return Ok(create);


        }

        [HttpPut("/update-medic")]
        public async Task<IActionResult> UpdateMedic(UpdateMedicCommand command)
        {

            var id = await _mediator.DispatchAsync<UpdateMedicCommand, ResultViewModel<Guid>>(command);

            if (id == null)
                return NotFound();

            return Ok(command);
        }

        //[HttpDelete("/delete-medic")]
        //public async Task<IActionResult> DeleteMedic(Medic medic)
        //{
        //    medic.SetAsDelete();

        //    var id = await _medicRepository.UpdateMedicAsync(medic);

        //    if (id == null)
        //        return NotFound();

        //    return Ok(medic);
        //}

    }
}
